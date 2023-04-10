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
        private Cardreader cardreader;

        private Thread getWeightThread;
        private Thread getDeviceInfoThread;
        private BackgroundWorker measureWorker;

        private bool scaleConnectCheck;
        private bool sensorConnectCheck;
        private bool controllerConnectCheck;
        private bool cardreaderConnectCheck;

        private float weight;
        private bool motorRun = false;

        const int MEASURE_TIME = 5; //측정시간
        const int DOWN_TIME = 30; //측정시간
        const int UP_TIME = 30; //측정시간

        public Form1()
        {
            InitializeComponent();
            getWeightThread = new Thread(refreshWeight);
            getDeviceInfoThread = new Thread(getDeviceInfo);
            scaleConnectCheck = false;
            cardreaderConnectCheck = false;

            measureWorker = new BackgroundWorker();
            //measureWorker.WorkerReportsProgress = true;
            //measureWorker.WorkerSupportsCancellation = true;
            measureWorker.DoWork += new DoWorkEventHandler(measure);
            //measureWorker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            measureWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(measure_complete);
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

        private void getDeviceInfo()
        {
            while (true)
            {
                controller.sendCommand("get_info");
                Thread.Sleep(2000);
            }
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
                        measureWorker.RunWorkerAsync();
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

                cbScalePort.DataSource = portnames.Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains(n))).ToList();
                cbControlPort.DataSource = portnames.Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains(n))).ToList();
                cbSensorPort.DataSource = portnames.Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains(n))).ToList();
                cbCardreaderPort.DataSource = portnames.Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains(n))).ToList();
            }
        }

        private void btnConnectSensor_Click(object sender, EventArgs e)
        {
            ShowMessageDelegate del = showMessage;
            string str = (cbSensorPort.Text).Split('-')[0];
            str = str.Replace(" ", "");
            sensor = new Sensor(str, del);
        }
        
        private void btnConnectScale_Click(object sender, EventArgs e)
        {
            ShowMessageDelegate del = showMessage;
            string str = (cbScalePort.Text).Split('-')[0];
            str = str.Replace(" ", "");
            scale = new Scale(str, del);
            scale.setSerialPort();
            getWeightThread.Start();
        }

        private void btnConnectController_Click(object sender, EventArgs e)
        {
            ShowMessageDelegate del1 = showMessage;
            MonitorControllerDataDelegate del2 = monitorControllerData;
            string str = (cbControlPort.Text).Split('-')[0];
            str = str.Replace(" ", "");
            controller = new Controller(str, del2, del1);
        }

        private void btnConnectCardreader_Click(object sender, EventArgs e)
        {
            ShowMessageDelegate del = showMessage;
            string str = (cbCardreaderPort.Text).Split('(')[1];
            str = str.Replace(" ", "");
            str = str.Replace(")", "");
            cardreader = new Cardreader(str, del);
            cardreader.setSerialPort();
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

                if (str == "카드리더가 연결되었습니다.\r\n")
                {
                    cbCardreaderPort.Enabled = false;
                    btnConnectCardreader.Enabled = false;
                    cardreaderConnectCheck = true;
                }

                if (str == "센서가 연결되었습니다.\r\n")
                {
                    cbSensorPort.Enabled = false;
                    btnConnectSensor.Enabled = false;
                    sensorConnectCheck = true;
                }

                if (str == "사육상자 번호를 인식하였습니다.\r\n")
                {
                    tbBoxCode.Text = cardreader.getCardNumber();
                    controller.sendCommand("motor_run");
                }
            }));
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
            if (e.KeyChar == 'a' || e.KeyChar == 'A')
            {
                if(motorRun)
                { 
                    cardreader.read();
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            motorRun = false;
            controller.sendCommand("motor_stop");
            controller.sendCommand("measure_up");
            btnStart.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            motorRun = true;
            if (!getDeviceInfoThread.IsAlive)
            {
                getDeviceInfoThread.Start();
            }
            btnStart.Enabled = false;
        }

        private void measure(object sender, DoWorkEventArgs e)
        {
            if (DeviceState.getMeasureState() == DeviceState.MeasureState.NewBox)
            {
                Thread.Sleep(3000);
                this.Invoke(new Action(delegate () {
                    camera.makeSnapshot();
                }));
                Thread.Sleep(2000);
                this.Invoke(new Action(delegate () {
                    tbLog.Text += "이미지데이터 수집 완료\r\n";
                }));
                controller.sendCommand("measure_down");
                this.Invoke(new Action(delegate () {
                    tbLog.Text += "센서 하강 시작\r\n";
                }));
                DeviceState.setMeasureState(DeviceState.MeasureState.Measuring);
                Thread.Sleep(DOWN_TIME * 1000);
                this.Invoke(new Action(delegate () {
                    tbLog.Text += "센서 하강 완료\r\n";
                    tbLog.Text += "측정시작\r\n";
                }));

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

                this.Invoke(new Action(delegate () {
                    tbLog.Text += "측정완료\r\n";
                }));
                controller.sendCommand("measure_up");
                this.Invoke(new Action(delegate () {
                    tbLog.Text += "센서 상승 시작\r\n";
                }));
                Thread.Sleep(UP_TIME * 1000);
                this.Invoke(new Action(delegate () {
                    tbLog.Text += "센서 상승 완료\r\n";
                }));
            }
        }

        void measure_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            // 에러가 있는지 체크
            if (e.Error != null)
            {
                tbLog.Text += e.Error.Message;
                return;
            }

            DeviceState.setMeasureState(DeviceState.MeasureState.Finish);
            DeviceState.setMeasureState(DeviceState.MeasureState.End);
            this.Invoke(new Action(delegate () {
                tbLog.Text += "상자를 이동합니다.\r\n";
            }));
            controller.sendCommand("motor_run");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (getWeightThread.IsAlive)
            {
                getWeightThread.Abort();
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
