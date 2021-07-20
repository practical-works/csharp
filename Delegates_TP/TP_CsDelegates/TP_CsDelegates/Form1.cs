using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TP_CsDelegates
{
    class Zone
    {
        public string Name { get; private set; }
        public double ChargePercentage { get; private set; }
        public bool IsRisky { get; private set; }
        public Zone(string name, double chargePercentage, bool isRisky = false)
        {
            this.Name = name;
            this.ChargePercentage = chargePercentage;
            this.IsRisky = isRisky;
        }
        public double GetFees(double itemPrice)
        {
            double fees = itemPrice * (ChargePercentage / 100);
            return (IsRisky) ? fees : fees + 25;
        }
    }

    public partial class Form1 : Form
    {
        private Zone zone1, zone2, zone3, zone4;

        public Form1()
        {
            InitializeComponent();
            comboBox_zone.SelectedIndex = 0;
            zone1 = new Zone("zone1", 25);
            zone2 = new Zone("zone2", 12, isRisky:true);
            zone3 = new Zone("zone3", 8);
            zone4 = new Zone("zone4", 4, isRisky:true);
        }

        private void button_calculate_Click(object sender, EventArgs e)
        {
            double itemPrice = 0;
            if (comboBox_zone.SelectedIndex != -1 && double.TryParse(textBox_itemPrice.Text.Trim(), out itemPrice))
            {
                switch (comboBox_zone.SelectedItem.ToString().ToLower())
                {
                    case "zone1":
                        textBox_result.Text = zone1.GetFees(itemPrice).ToString() + " $";
                        break;
                    case "zone2":
                        textBox_result.Text = zone2.GetFees(itemPrice).ToString() + " $";
                        break;
                    case "zone3":
                        textBox_result.Text = zone3.GetFees(itemPrice).ToString() + " $";
                        break;
                    case "zone4":
                        textBox_result.Text = zone4.GetFees(itemPrice).ToString() + " $";
                        break;
                    default:
                        textBox_result.Text = "Input errors";
                        break;
                }
            }
            else
            {
                textBox_result.Text = "Input errors";
            }
        }
    }
}
