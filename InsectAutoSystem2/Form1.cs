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
        Thread readSonsorThread;
        Thread feedThread;

        private bool scaleConnectCheck;
        private bool sensorConnectCheck;
        private float weight;
        private String controllerData;
        private FeedState feedState;
        private double targetFeedWeight = 6;

        enum FeedState
        {
            None,
            NewBox,
            Feeding,
            Full,
            End
        }

        public Form1()
        {
            InitializeComponent();
            readSonsorThread = new Thread(readSensor);
            getWeightThread = new Thread(refreshWeight);
            scaleThread = new Thread(readScale);
            feedThread = new Thread(feed);
            scaleConnectCheck = false;
            sensorConnectCheck = false;
            weight = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowVideoFrameDelegate del = showVideoFrame;
            ShowMessageDelegate del1 = showMessage;
            camera = new Camera(del, del1);
            setSerialPort();
            feedState = FeedState.None;
        }

        private void monitorControllerData(String strData)
        {
            var responseValues = strData.Split(',');
            if (Int32.Parse(responseValues[3])==1) //센서1에 물체가 감지되면
            {
                if(feedState == FeedState.None)
                {
                    feedState = FeedState.NewBox;
                    feedThread.Start();
                }
            }
        }

        private void setSerialPort()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'"))
            {
                var portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());
                cbScalePort.DataSource = portnames.Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains(n))).ToList();
                cbSensorPort.DataSource = portnames.Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains(n))).ToList();
                cbControlPort.DataSource = portnames.Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains(n))).ToList();
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

        private void btnConnectSensor_Click(object sender, EventArgs e)
        {
            ShowMessageDelegate del = showMessage;
            string str = (cbSensorPort.Text).Split('-')[0];
            str = str.Replace(" ", "");
            sensor = new Sensor(str, del);
            readSonsorThread.Start();
        }

        private void refreshWeight()
        {
            while(true) {
                weight = scale.getWeight();
                Thread.Sleep(100);
            }
        }

        private void readSensor()
        {
            double[] sensorValue = new double[4];
            for(int i=1; i<=120; i++)
            {
                int[] values = sensor.read();
                sensorValue[0] = sensorValue[0] + (values[0] / 100.0 - 55.0); //온도저장
                sensorValue[1] = sensorValue[1] + (values[3] / 100.0); //습도저장
                sensorValue[2] = sensorValue[2] + values[7]; //이산화탄소
                sensorValue[3] = sensorValue[3] + values[8]; //암모니아

                this.Invoke(new Action(delegate ()
                {
                    tbTemperature.Text = Math.Round((sensorValue[0] / i),2).ToString();
                    tbHumidity.Text = Math.Round((sensorValue[1] / i), 2).ToString();
                    tbCO2.Text = Math.Round((sensorValue[2] / i), 2).ToString();
                    tbNH3.Text = Math.Round((sensorValue[3] / i), 2).ToString();
                }));

                Thread.Sleep(1000);
            }

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbBoxCode.Text += e.KeyChar.ToString();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            controller.sendCommand("motor_stop");
            controller.sendCommand("shuttle_stop");
        }

        private void btnConnectController_Click(object sender, EventArgs e)
        {
            MonitorControllerDataDelegate del2 = monitorControllerData;
            ShowMessageDelegate del = showMessage;
            string str = (cbControlPort.Text).Split('-')[0];
            str = str.Replace(" ", "");
            controller = new Controller(str, del2);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            controller.sendCommand("motor_run");
        }

        private void feed()
        {
            if (weight < targetFeedWeight)
            {
                controller.sendCommand("shuttle_run");
                feedState = FeedState.Feeding;
                while (weight < targetFeedWeight && feedState == FeedState.Feeding) {
                    Console.WriteLine("무게 : " + weight);
                }
                controller.sendCommand("shuttle_stop");
                feedState = FeedState.Full;
                controller.sendCommand("motor_run");
                feedState = FeedState.None;
            }
        }
    }
}
