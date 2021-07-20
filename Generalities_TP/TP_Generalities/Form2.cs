using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TP_Generalities
{
    public partial class FormMain : Form
    {
        private event EventHandler HiSaid;

        public FormMain()
        {
            InitializeComponent();

            this.Click += new EventHandler(FormMain_Click);
            this.Click += FormMain_Click;
            this.Click += delegate(object sender, EventArgs e)
                {
                    MessageBox.Show("[FormMain.Click] Event Handled by : \n\nAnonymous function");
                };
            this.Click += (sender, e) =>
                {
                    MessageBox.Show("[FormMain.Click] Event Handled by : \n\nLambda expression");
                };


            this.HiSaid += (sender, e) =>
                {
                    if (textBox1.Text == "hi")
                    {
                        button1.Text = "hello there ^^";
                        button1.Enabled = textBox1.Enabled = false;
                    }
                };

            button1.Click += (sender, e) =>
                {
                    this.HiSaid(new object(), new EventArgs());
                };
        }

        void FormMain_Click(object sender, EventArgs e)
        {
            MessageBox.Show("[FormMain.Click] Event Handled by : \n\n[FormMain_Click] function");
        }
    }
}
