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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace InsectAutoSystem2
{
    delegate void ShowVideoFrameDelegate(Bitmap videoFrame);
    delegate void ShowMessageDelegate(String Str);

    public partial class Form1 : Form
    {
        private Camera camera;
        private Scale scale;
        private Sensor sensor;
        private Controller controller;
        Thread scaleThread;
        Thread getWeightThread;
        Thread readSonsorThread;
        private bool scaleConnectCheck;
        private bool sensorConnectCheck;
        private float weight;

        public Form1()
        {
            InitializeComponent();
            readSonsorThread = new Thread(readSensor);
            getWeightThread = new Thread(refreshWeight);
            scaleThread = new Thread(readScale);
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
        }

        private void setSerialPort()
        {
            cbScalePort.DataSource = SerialPort.GetPortNames();
            cbSensorPort.DataSource = SerialPort.GetPortNames();
            cbControlPort.DataSource = SerialPort.GetPortNames();
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
            scale = new Scale(cbScalePort.Text, del);
            scaleThread.Start();
            getWeightThread.Start();
        }

        private void btnConnectSensor_Click(object sender, EventArgs e)
        {
            ShowMessageDelegate del = showMessage;
            sensor = new Sensor(cbSensorPort.Text,del);
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
            Console.WriteLine(e.KeyChar);
            tbBoxCode.Text += e.KeyChar.ToString();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            controller.sendCommand("motor_stop");
        }

        private void btnConnectController_Click(object sender, EventArgs e)
        {
            controller = new Controller(cbControlPort.Text);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            controller.sendCommand("motor_run");
        }
    }
}
