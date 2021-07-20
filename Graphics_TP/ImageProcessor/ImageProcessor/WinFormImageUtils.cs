using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageProcessor
{
    public class WinFormImageUtils
    {
        public static string ImageFilesFilter
        {
            get
            {
                return "Image Files|*bmp; *png; *jpg; *jpeg; *gif";
            }
        }
        public static string LastOpenImageFilePath
        {
            get
            {
                return Properties.Settings.Default.LastOpenImageFilePath;
            }
        }

        public static Image GetImageFromFileDialog(OpenFileDialog openFileDialog, out string imageFileName)
        {
            imageFileName = string.Empty;
            if (openFileDialog == null)
            {
                return null;
            }
            openFileDialog.Filter = ImageFilesFilter;
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageFileName = openFileDialog.SafeFileName;
                SaveImagePathToSettings(openFileDialog.FileName);
                return Image.FromFile(openFileDialog.FileName);
            }
            return null;
        }

        public static void SaveImagePathToSettings(string imageFilePath)
        {
            Properties.Settings.Default.LastOpenImageFilePath = imageFilePath;
            Properties.Settings.Default.Save();
        }

        public static void SetImageToPictureBox(Image image, PictureBox pictureBox, string imageFileName = "", TextBox textBox = null)
        {
            if (image != null && pictureBox != null)
            {
                pictureBox.Image = image;
                if (textBox != null && imageFileName != string.Empty)
                {
                    textBox.Text = imageFileName;
                }
            }
        }

        public static bool SaveImageFromFileDialog(Image image, SaveFileDialog saveFileDialog)
        {
            if (saveFileDialog == null)
            {
                return false;
            }
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "jpg";
            saveFileDialog.FileName = "";
            saveFileDialog.Filter = ImageFilesFilter;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                image.Save(saveFileDialog.FileName);
                return true;
            }
            return false;
        }
    }
}
