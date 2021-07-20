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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            NumberGenerator numGen = new NumberGenerator();
            buttonOK.Click += (sender, e) => 
                textBoxRandomNum.Text = numGen.GetRandomNumber(textBoxUpperNum.Text);

            numGen.upperNumberIsNotANumber += (sender, e) =>
                {
                    NumberGenerator sender_ = (NumberGenerator)sender;
                    NumberGeneratorEvenArgs e_ = (NumberGeneratorEvenArgs)e;
                    MessageBox.Show(e_.Input + " is not a number.");
                };
        }
    }
}
