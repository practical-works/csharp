using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsManipulator
{
    public static class FXGraphics
    {
        public static int Val { get; set; }
        public static Random Rand { get; set; }
        public static Graphics Graph { get; set; }

        static FXGraphics()
        {
            Val = 0;
            Rand = new Random();
        }

        public static void DrawRandomPolygon(Control ctrl)
        {
            Graph = ctrl.CreateGraphics();
            Point[] points = new Point[Rand.Next(4, 4)];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(Rand.Next(0, ctrl.Width), Rand.Next(0, ctrl.Height));
            }
            Task drawingTask = new Task(() => Graph.FillPolygon(new SolidBrush(GetRandomColor()), points));
            drawingTask.Start();
        }

        public static void DrawRandomRectangle(Control ctrl)
        {
            Graph = ctrl.CreateGraphics();
            Rectangle rect = new Rectangle(
                Rand.Next(0, ctrl.Width),       // X
                Rand.Next(0, ctrl.Height),      // Y
                Rand.Next(16, 128),             // Width
                Rand.Next(16, 128)              // Height
            );
            Color color = Color.FromArgb(Rand.Next());
            Pen pen = new Pen(color, Rand.Next(1, 3));
            Task drawingTask = new Task(() => Graph.FillRectangle(pen.Brush, rect));
            drawingTask.Start();
        }

        public static Color GetRandomColor()
        {
            return Color.FromArgb((new Random()).Next());
        }

        public static void DrawGrowableCircle(Control ctrl, int x = 0, int y = 0)
        {
            Graph = ctrl.CreateGraphics();
            Val += 3;
            Task drawingTask = new Task(delegate()
            {
                Graph.DrawEllipse(
                    new Pen(GetRandomColor(), 1),
                    new Rectangle(
                        x,              // X
                        y,              // Y
                        Val,            // Width
                        Val             // Height
                    )
                );
            });
            drawingTask.Start();
        }

        public static void DrawCenterPoint(Control ctrl)
        {
            Graph = ctrl.CreateGraphics();
            Bitmap bitmap = new Bitmap(1, 1);
            bitmap.SetPixel(0, 0, Color.Red);
            Point centerPoint = new Point(ctrl.Width / 2, ctrl.Height / 2);
            Graph.DrawImageUnscaled(bitmap, centerPoint);
        }

        public static void DrawPlusGrid(Control ctri)
        {
            Graph = ctri.CreateGraphics();
            Point horizontalLineStart = new Point(0, ctri.Height / 2);
            Point horizontalLineEnd = new Point(ctri.Width, ctri.Height / 2);
            Point verticalLineStart = new Point(ctri.Width / 2, 0);
            Point verticalLineEnd = new Point(ctri.Width / 2, ctri.Height);
            Pen pen = new Pen(Color.Blue, 2);
            Graph.DrawLine(pen, horizontalLineStart, horizontalLineEnd);
            Graph.DrawLine(pen, verticalLineStart, verticalLineEnd);
        }

        public static void ClearCanvas(Control ctrl)
        {
            ctrl.CreateGraphics().Clear(Color.White);
        }
    }
}
