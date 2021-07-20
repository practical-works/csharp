using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ImageProcessor
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = "";
            Image image = WinFormImageUtils.GetImageFromFileDialog(openFileDialog1, out name);
            WinFormImageUtils.SetImageToPictureBox(image, pictureBox1, name, textBox1);
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                WinFormImageUtils.SaveImageFromFileDialog(pictureBox1.Image, saveFileDialog1);
            }
        }

        private void contentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                (new FormCompare(pictureBox1.Image, ImageProcessor.ImageComparisonType.Content, textBox1.Text)).ShowDialog(this);
            }
        }

        private void areaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                (new FormCompare(pictureBox1.Image, ImageProcessor.ImageComparisonType.Area, textBox1.Text)).ShowDialog(this);
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            openImageToolStripMenuItem_Click(sender, e);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (File.Exists(WinFormImageUtils.LastOpenImageFilePath))
            {
                pictureBox1.Image = Image.FromFile(WinFormImageUtils.LastOpenImageFilePath);
                textBox1.Text = Path.GetFileName(WinFormImageUtils.LastOpenImageFilePath);
            }
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null && !backgroundWorker1.IsBusy)
            {
                label1.Visible = true;
                backgroundWorker1.RunWorkerAsync(sender);
            }
        }

        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null && !backgroundWorker1.IsBusy)
            {
                label1.Visible = true;
                backgroundWorker1.RunWorkerAsync(sender);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument.Equals(grayToolStripMenuItem))
            {
                pictureBox1.Image = ImageProcessor.ImageToGray(pictureBox1.Image);
            }
            else
            {
                pictureBox1.Image = ImageProcessor.ImageToNegative(pictureBox1.Image);
            }
            label1.Visible = false;
        }
    }
}
