using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsectAutoSystem2
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideo;
        private VideoCaptureDeviceForm captureDevice = new VideoCaptureDeviceForm();
        private Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in VideoCaptureDevices)
            {
                comboBox1.Items.Add(device);
            }
            captureDevice = new VideoCaptureDeviceForm();
            comboBox1.SelectedIndex = 2;

            FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[comboBox1.SelectedIndex].MonikerString);
            FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);


        }

        private void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if(pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            FinalVideo.VideoResolution = FinalVideo.VideoCapabilities[8];
            FinalVideo.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (FinalVideo.IsRunning == true)
            {
                FinalVideo.Stop();
                /*                pictureBox.Image = null;
                                pictureBox.Invalidate();*/
                pictureBox1.Image = null;
                pictureBox1.Invalidate();
            }
        }

        private void btnSnapshot_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)pictureBox1.Image.Clone();
            bitmap.Save("d:\\TestImage.jpg", ImageFormat.Jpeg);
            bitmap.Dispose();
            MessageBox.Show("찍었다!!");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalVideo.IsRunning == true)
            {
                FinalVideo.Stop();
                Application.Exit();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
