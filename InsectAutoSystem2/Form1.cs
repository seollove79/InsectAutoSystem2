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
    delegate void ShowVideoFrameDelegate(Bitmap videoFrame);

    public partial class Form1 : Form
    {
        Camera camera;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowVideoFrameDelegate del = showVideoFrame;
            camera = new Camera(del);
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
/*            if (FinalVideo != null && FinalVideo.IsRunning == true)
            {
                FinalVideo.Stop();
                pictureBox1.Image = null;
                pictureBox1.Invalidate();
                Application.Exit();
            }
            else
            {
                Application.Exit();
            }*/
        }
    }
}
