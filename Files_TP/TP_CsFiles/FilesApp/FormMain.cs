using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FilesApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (FolderManager.CreateFolder(textBox1.Text))
                {
                    textBoxLog.Text = "Folder [" + textBox1.Text + "] created.";
                }
                else
                {
                    textBoxLog.Text = "Folder already exists.";
                }
            }
            catch (Exception exp)
            {
                textBoxLog.Text = exp.Message;
            }
            finally
            {
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (FolderManager.DeleteFolder(textBox1.Text))
                {
                    textBoxLog.Text = "Folder [" + textBox1.Text + "] deleted.";
                }
                else
                {
                    textBoxLog.Text = "Folder doesn't exist.";
                }
            }
            catch (Exception exp)
            {
                textBoxLog.Text = exp.Message;
            }
            finally
            {
                textBox1.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (FolderManager.CopyFolder(textBox1.Text, textBox2.Text))
                {
                    textBoxLog.Text = "Folder [" + textBox1.Text + "] copied to [" +
                        textBox2.Text + "].";
                }
                else
                {
                    textBoxLog.Text = "Folder to copy doesn't exist.";
                }
            }
            catch (Exception exp)
            {
                textBoxLog.Text = exp.Message;
            }
            finally
            {
                textBox1.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (FolderManager.MoveFolder(textBox1.Text, textBox2.Text))
                {
                    textBoxLog.Text = "Folder [" + textBox1.Text + "] moved to [" +
                        textBox2.Text + "].";
                }
                else
                {
                    textBoxLog.Text = "Folder to move doesn't exist.";
                }
            }
            catch (Exception exp)
            {
                textBoxLog.Text = exp.Message;
            }
            finally
            {
                textBox1.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileManager.CreateFile(textBox1.Text))
                {
                    textBoxLog.Text = "File [" + textBox1.Text + "] created.";
                }
                else
                {
                    textBoxLog.Text = "File already exist.";
                }
            }
            catch (Exception exp)
            {
                textBoxLog.Text = exp.Message;
            }
            finally
            {
                textBox1.Focus();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exp)
            {
                textBoxLog.Text = exp.Message;
            }
            finally
            {
                textBox1.Focus();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exp)
            {
                textBoxLog.Text = exp.Message;
            }
            finally
            {
                textBox1.Focus();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exp)
            {
                textBoxLog.Text = exp.Message;
            }
            finally
            {
                textBox1.Focus();
            }
        }
        
    }
}
