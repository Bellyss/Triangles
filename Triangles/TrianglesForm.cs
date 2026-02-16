using System;
using System.Drawing;
using System.Windows.Forms;

namespace Triangles
{
    public partial class TrianglesForm : Form
    {
        public TrianglesForm()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.WindowState = FormWindowState.Maximized;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            PointF p1 = new PointF(100, 100);
            PointF p2 = new PointF(500, 100);
            PointF p3 = new PointF(300, 446);

            DrawTriangleRecursive(e.Graphics, p1, p2, p3);
        }

        private void DrawTriangleRecursive(Graphics g, PointF p1, PointF p2, PointF p3)
        {
            // Stop condition: if triangle is too small
            if (Distance(p1, p2) < 1)
                return;

            // Draw current triangle
            g.DrawPolygon(Pens.Black, new PointF[] { p1, p2, p3 });

            // Calculate midpoints
            PointF m1 = Midpoint(p1, p2);
            PointF m2 = Midpoint(p2, p3);
            PointF m3 = Midpoint(p3, p1);

            // Recursive call for inner triangle
            DrawTriangleRecursive(g, m1, m2, m3);
        }

        private PointF Midpoint(PointF a, PointF b)
        {
            return new PointF((a.X + b.X) / 2, (a.Y + b.Y) / 2);
        }

        private float Distance(PointF a, PointF b)
        {
            return (float)Math.Sqrt(
                Math.Pow(a.X - b.X, 2) +
                Math.Pow(a.Y - b.Y, 2));
        }
    }
}
