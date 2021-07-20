using System;
using System.Windows.Forms;

namespace GraphicsManipulator
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            FXGraphics.DrawPlusGrid(panel1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //FXGraphics.DrawRandomRectangle(panel1);
            //FXGraphics.DrawRandomPolygon(panel1);
            FXGraphics.DrawGrowableCircle(panel1);
            FXGraphics.DrawGrowableCircle(panel1, 0, panel1.Height);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            FXGraphics.Val = 0;
            panel1.Refresh();
        }
    }
}
