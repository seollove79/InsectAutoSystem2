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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int cameraIndex=-1;
            int i = 0;
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo device in VideoCaptureDevices)
            {
                if(device.Name == "See3CAM_CU135")
                {
                    cameraIndex = i;
                }
                i++;
            }

            if (cameraIndex != -1)
            {
                captureDevice = new VideoCaptureDeviceForm();
                FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[cameraIndex].MonikerString);
                FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);

                FinalVideo.VideoResolution = FinalVideo.VideoCapabilities[4];
                FinalVideo.Start();
            }
            else
            {
                MessageBox.Show("카메라가 없습니다.\n카메라를 연결을 확인해 주세요.");
            }

            /*
            // 해상도 확인 코드
            for (int i=0; i< FinalVideo.VideoCapabilities.Length; i++)
            {
                Console.WriteLine(FinalVideo.VideoCapabilities[i].FrameSize.ToString());
            }*/
        }

        private void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            FinalVideo.VideoResolution = FinalVideo.VideoCapabilities[4];
            FinalVideo.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (FinalVideo.IsRunning == true)
            {
                FinalVideo.Stop();
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
            if (FinalVideo != null && FinalVideo.IsRunning == true)
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
