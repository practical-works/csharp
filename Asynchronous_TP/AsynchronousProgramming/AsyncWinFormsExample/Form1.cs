using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using AsyncConsoleExample;

namespace AsyncWinFormsExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = ThreadInfos.CurrentThreadInfos;
        }

        private void button_msgSync_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MAIN THREAD", ThreadInfos.CurrentThreadInfos, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void button_msgAsync_Click(object sender, EventArgs e)
        {
            Action asyncMessageBoxShow = delegate()
            {
                MessageBox.Show("BACKGROUND THREAD", ThreadInfos.CurrentThreadInfos, MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            
            // Method 1 : BeginEnd Pattern
            //asyncMessageBoxShow.BeginInvoke(null, null);
            
            // Method 2 : Tasks
            //Task task = (new Task(asyncMessageBoxShow)).Start();
            //task.Start();

            // Method 3 : BackgroundWorker
            if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            MessageBox.Show("BACK THREAD", ThreadInfos.CurrentThreadInfos, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_loadImage_Click(object sender, EventArgs e)
        {
            string url = textBox_url.Text.Trim();
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                errorProvider1.SetError(textBox_url, "Invalid URL");
            }
            else
            {
                errorProvider1.Clear();
                button_loadImage.Enabled = false;
                label_imageName.Text = "Loading image ...";
                pictureBox_image.Image = Properties.Resources.Loading;
                backgroundWorker2.RunWorkerAsync(url);
            }
        }

        private void button_clearImage_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker2.IsBusy)
            {
                pictureBox_image.Image = null;
                label_imageName.Text = "";
            }
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string url = (string)e.Argument;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    pictureBox_image.Image = Image.FromStream(responseStream);
                    label_imageName.Text = Path.GetFileName(url);
                    button_loadImage.Enabled = true;
                }
            }
        }
    }
}
