using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessor
{
    public partial class FormCompare : Form
    {
        public ImageProcessor.ImageComparisonType ComparisonType { get; set; }
        public string ImageName1 { get; set; }
        public string ImageName2 { get; set; }

        public FormCompare()
        {
            InitializeComponent();
            ImageName2 = "...";
        }
        public FormCompare(Image image, ImageProcessor.ImageComparisonType comparisonType, string imageFileName = "") : this()
        {
            ImageName1 = imageFileName;
            ComparisonType = comparisonType;
            pictureBox1.Image = image;
            VSMessage();
        }

        private void VSMessage(string midMsg = "")
        {
            midMsg = midMsg == "" ? " VS " : midMsg;
            textBox1.Text = string.Format("[{0}] {1} [{2}]", ImageName1, midMsg, ImageName2);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string name = "";
            Image image = WinFormImageUtils.GetImageFromFileDialog(openFileDialog1, out name);
            ImageName2 = name;
            WinFormImageUtils.SetImageToPictureBox(image, pictureBox2, name, textBox1);
            VSMessage();
            button1.Visible = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            textBox1.Text = "Checking ...";
            pictureBox2.Enabled = false;
            switch (ComparisonType)
            {
                case ImageProcessor.ImageComparisonType.Area:
                    int result = ImageProcessor.CompareImagesByArea(pictureBox1.Image, pictureBox2.Image);
                    if (result == 0) VSMessage(" has the same area as ");
                    else if (result > 0) VSMessage(" is larger than ");
                    else VSMessage(" is smaller than ");
                    break;
                case ImageProcessor.ImageComparisonType.Content:
                    int ratio = ImageProcessor.ImageIsPieceOfAnotherImage(pictureBox2.Image, pictureBox1.Image);
                    textBox1.Text = (100 * ratio) + "% Matching.";
                    break;
                default:
                    break;
            }
            button1.Visible = true;
            pictureBox2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
