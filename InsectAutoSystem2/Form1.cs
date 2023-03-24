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

namespace InsectAutoSystem2
{
    delegate void ShowVideoFrameDelegate(Bitmap videoFrame);
    delegate void ShowMessageDelegate(String Str);

    public partial class Form1 : Form
    {
        private Camera camera;
        private static Scale scale;
        Thread scaleThread = new Thread(readScale);
        private bool scaleConnectCheck = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowVideoFrameDelegate del = showVideoFrame;
            ShowMessageDelegate del1 = showMessage;
            camera = new Camera(del, del1);
            setScaleSerialPort();
        }

        private void setScaleSerialPort()
        {
            cbScalePort.DataSource = SerialPort.GetPortNames();
        }

        private static void readScale()
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
                    btnConnectScale.Enabled = false;
                    scaleConnectCheck = true;
                }
            }));
        }

        private void btnConnectScale_Click(object sender, EventArgs e)
        {
            ShowMessageDelegate del = showMessage;
            scale = new Scale(cbScalePort.Text, del);
            scaleThread.Start();
        }
    }
}
