using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace InsectAutoSystem2
{
    delegate void ShowVideoFrameDelegate(Bitmap videoFrame);
    delegate void ShowMessageDelegate(String Str);
    delegate void MonitorControllerDataDelegate(String strData);


    public partial class Form1 : Form
    {
        private Camera camera;
        private Scale scale;
        private Sensor sensor;
        private Controller controller;
        Thread scaleThread;
        Thread getWeightThread;
        Thread runThread;
        Thread measureThread;
        //Thread readSensorThread;



        private bool scaleConnectCheck = false;
        private bool sensorConnectCheck = false;
        private bool controllerConnectCheck = false;
        private float weight;
        private String controllerData;
        private String rfidCode;
        private bool runThreadEnable = false;
        private bool motorRun = false;

        const int MEASURE_TIME = 10; //측정시간
        const int DOWN_TIME = 35; //측정시간
        const int UP_TIME = 35; //측정시간

        public Form1()
        {
            InitializeComponent();
            getWeightThread = new Thread(refreshWeight);
            scaleThread = new Thread(readScale);
            runThread = new Thread(run);
            measureThread = new Thread(measure);
            scaleConnectCheck = false;
        }

        private void init()
        {
            //초기화
            DeviceState.setMeasureState(DeviceState.MeasureState.None);
            weight = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowVideoFrameDelegate del = showVideoFrame;
            ShowMessageDelegate del1 = showMessage;
            camera = new Camera(del, del1);
            setSerialPort();
            init();
        }

        private void monitorControllerData(String strData)
        {
            var responseValues = strData.Split(',');
            if (Int32.Parse(responseValues[3]) == 1) //센서1에 물체가 감지되면
            {
                if(Int32.Parse(responseValues[1]) == 0) //컨베이어가 멈춰 있으면
                {
                    if (DeviceState.getMeasureState() == DeviceState.MeasureState.None)
                    {
                        DeviceState.setMeasureState(DeviceState.MeasureState.NewBox);
                    }
                }
            }
            else if (Int32.Parse(responseValues[3]) == 0) //1번 센서에 물체가 없으면
            {
                DeviceState.setMeasureState(DeviceState.MeasureState.None);
            }
        }

        private void setSerialPort()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'"))
            {
                var portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());

                //TODO 자동연결 되도록 처리해야함
/*                foreach (string port in ports)
                {
                    if (port.Contains("Silicon Labs CP210x USB to UART Bridge"))
                    {
                        ShowMessageDelegate del1 = showMessage;
                        MonitorControllerDataDelegate del2 = monitorControllerData;
                        string str = port.Split('(')[1];
                        str = str.Replace(" ", "");
                        str = str.Replace(")", "");
                        controller = new Controller(str, del2, del1);
                    }

                    if (port.Contains("Prolific USB"))
                    {
                        ShowMessageDelegate del = showMessage;
                        string str = port.Split('(')[1];
                        str = str.Replace(" ", "");
                        str = str.Replace(")", "");
                        scale = new Scale(str, del);
                        scaleThread.Start();
                        getWeightThread.Start();
                    }
                }*/

                cbScalePort.DataSource = portnames.Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains(n))).ToList();
                cbControlPort.DataSource = portnames.Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains(n))).ToList();
                cbSensorPort.DataSource = portnames.Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains(n))).ToList();
            }
        }

        private void readScale()
        {
            scale.setSerialPort();
        }

        private void btnSnapshot_Click(object sender, EventArgs e)
        {
            camera.makeSnapshot();
        }

        private void btnConnectSensor_Click(object sender, EventArgs e)
        {
            ShowMessageDelegate del = showMessage;
            string str = (cbSensorPort.Text).Split('-')[0];
            str = str.Replace(" ", "");
            sensor = new Sensor(str, del);
            //readSensorThread.Start();
        }

        private void showVideoFrame(Bitmap videoFrame)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = videoFrame;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            camera.clear();
            pictureBox1.Image = null;
            pictureBox1.Invalidate();
            Application.Exit();
        }

        private void showMessage(string str)
        {
            this.Invoke(new Action(delegate () {
                tbLog.Text += str + "\n";
                if (str == "저울이 연결되었습니다.\r\n")
                {
                    cbScalePort.Enabled = false;
                    btnConnectScale.Enabled = false;
                    scaleConnectCheck = true;
                }

                if (str == "제어기가 연결되었습니다.\r\n")
                {
                    cbControlPort.Enabled = false;
                    btnConnectController.Enabled = false;
                    controllerConnectCheck = true;
                }

                if (str == "센서가 연결되었습니다.\r\n")
                {
                    cbSensorPort.Enabled = false;
                    btnConnectSensor.Enabled = false;
                    sensorConnectCheck = true;
                }
            }));
        }

        private void btnConnectScale_Click(object sender, EventArgs e)
        {
            ShowMessageDelegate del = showMessage;
            string str = (cbScalePort.Text).Split('-')[0];
            str = str.Replace(" ", "");
            scale = new Scale(str, del);
            scaleThread.Start();
            getWeightThread.Start();
        }

        private void refreshWeight()
        {
            while (true)
            {
                weight = scale.getWeight();
                this.Invoke(new Action(delegate () {
                    tbWeight.Text = weight.ToString();
                }));
                Thread.Sleep(2000);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (e.KeyChar != '#')
            {
                rfidCode += e.KeyChar;
            }
            else
            {
                if (rfidCode != tbBoxCode.Text)
                {
                    tbBoxCode.Text = rfidCode;
                }
                rfidCode = "";
            }*/
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            motorRun = false;
            controller.sendCommand("motor_stop");
            controller.sendCommand("shuttle_stop");
        }

        private void btnConnectController_Click(object sender, EventArgs e)
        {
            ShowMessageDelegate del1 = showMessage;
            MonitorControllerDataDelegate del2 = monitorControllerData;
            string str = (cbControlPort.Text).Split('-')[0];
            str = str.Replace(" ", "");
            controller = new Controller(str, del2, del1);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DeviceState.setMeasureState(DeviceState.MeasureState.None);
            motorRun = true;
            if (!runThread.IsAlive)
            {
                runThread.Start();
            }
            if (!measureThread.IsAlive)
            {
                measureThread.Start();
            }
        }

        private void measure()
        {
            while (true)
            {
                if (DeviceState.getMeasureState() == DeviceState.MeasureState.NewBox)
                {
                    Thread.Sleep(3000);
                    Console.WriteLine("이미지데이터 수집 완료");
                    this.Invoke(new Action(delegate () {
                        camera.makeSnapshot();
                    }));
                    controller.sendCommand("measure_down");
                    Console.WriteLine("다운시작");
                    DeviceState.setMeasureState(DeviceState.MeasureState.Measuring);
                    Thread.Sleep(DOWN_TIME * 1000);
                    Console.WriteLine("다운완료");
                    Console.WriteLine("측정시작");

                    double[] sensorValue = new double[4];
                    for (int i = 1; i <= MEASURE_TIME; i++)
                    {
                        int[] values = sensor.read();
                        sensorValue[0] = sensorValue[0] + (values[0] / 100.0 - 55.0); //온도저장
                        sensorValue[1] = sensorValue[1] + (values[3] / 100.0); //습도저장
                        sensorValue[2] = sensorValue[2] + values[7]; //이산화탄소
                        sensorValue[3] = sensorValue[3] + values[8]; //암모니아

                        this.Invoke(new Action(delegate ()
                        {
                            tbTemperature.Text = Math.Round((sensorValue[0] / i), 2).ToString();
                            tbHumidity.Text = Math.Round((sensorValue[1] / i), 2).ToString();
                            tbCO2.Text = Math.Round((sensorValue[2] / i), 2).ToString();
                            tbNH3.Text = Math.Round((sensorValue[3] / i), 2).ToString();
                        }));

                        Thread.Sleep(1000);
                    }

                    Console.WriteLine("측정완료");
                    controller.sendCommand("measure_up");
                    Console.WriteLine("업시작");
                    Thread.Sleep(UP_TIME * 1000);
                    Console.WriteLine("업완료");
                    DeviceState.setMeasureState(DeviceState.MeasureState.Finish);
                    DeviceState.setMeasureState(DeviceState.MeasureState.End);
                }
            }
        }

        private void run()
        {
            while (true)
            {
                if (motorRun == true && (DeviceState.getMeasureState() == DeviceState.MeasureState.None || DeviceState.getMeasureState() == DeviceState.MeasureState.End))
                {
                    controller.sendCommand("motor_run");
                }
                Thread.Sleep(2000);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (scaleThread.IsAlive)
            {
                scaleThread.Abort();
            }
            if (getWeightThread.IsAlive)
            {
                getWeightThread.Abort();
            }
            if (runThread.IsAlive)
            {
                runThread.Abort();
            }
        }

        private void readSensor()
        {
            double[] sensorValue = new double[4];
            for (int i = 1; i <= MEASURE_TIME; i++)
            {
                int[] values = sensor.read();
                sensorValue[0] = sensorValue[0] + (values[0] / 100.0 - 55.0); //온도저장
                sensorValue[1] = sensorValue[1] + (values[3] / 100.0); //습도저장
                sensorValue[2] = sensorValue[2] + values[7]; //이산화탄소
                sensorValue[3] = sensorValue[3] + values[8]; //암모니아

                this.Invoke(new Action(delegate ()
                {
                    tbTemperature.Text = Math.Round((sensorValue[0] / i), 2).ToString();
                    tbHumidity.Text = Math.Round((sensorValue[1] / i), 2).ToString();
                    tbCO2.Text = Math.Round((sensorValue[2] / i), 2).ToString();
                    tbNH3.Text = Math.Round((sensorValue[3] / i), 2).ToString();
                }));

                Thread.Sleep(1000);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //measureDownWorker.RunWorkerAsync();
        }
    }
}
