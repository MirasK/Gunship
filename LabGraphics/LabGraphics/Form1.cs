using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picture
{
    public partial class Form1 : Form
    {
        Graphics gfx;
        Pen pen = new Pen(Color.Black, 1);

        public Form1()
        {
            InitializeComponent();
            gfx = CreateGraphics();
        }

        private void Paint_form(object sender, PaintEventArgs e)
        {
            DrawBackGround(800, 500);

            DrawStars(50, 90, 15);
            DrawStars(300, 70, 15);
            DrawStars(500, 120, 15);
            DrawStars(720, 200, 15);
            DrawStars(65, 390, 15);
            DrawStars(280, 370, 15);
            DrawStars(620, 300, 15);
            DrawStars(710, 440, 15);
            DrawStars(400, 300, 15);

            DrawAsteroid(150, 170, 1.2);
            DrawAsteroid(180, 330, 1.2);
            DrawAsteroid(650, 160, 1.2);
            DrawAsteroid(530, 400, 1.2);

            DrawSpaceship(370, 260, 1.2);
            DrawBullet(410, 190, 1);

            DrawInfo(550, 10, 220, 40);
        }

        private void DrawBullet(float x, float y, float e)
        {
            float k = (float)e;

            PointF[] p = { new PointF(x, y),
                          new PointF(x + 8 * k, y + 4 * k),
                          new PointF(x + 12 * k, y + 12 * k),
                          new PointF(x + 16 * k, y + 4 * k),
                          new PointF(x + 24 * k, y),
                          new PointF(x + 16 * k, y - 4 * k),
                          new PointF(x + 12 * k, y - 12 * k),
                          new PointF(x + 8 * k, y - 4 * k) };

            gfx.FillPolygon(Brushes.Black, p);
        }

        private void DrawInfo(float x, float y, float dx, float dy)
        {
            gfx.FillRectangle(Brushes.White, new RectangleF(new PointF(x, y), new SizeF(dx, dy)));

            pen.Width = 3;
            pen.Color = Color.Green;

            gfx.DrawRectangle(pen, x, y, dx, dy);

            string info = "Level: 1 Score: 200 Live: ***";
            x += 4;
            y += 10;
            gfx.DrawString(info, new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, x, y);
        }

        private void DrawBackGround(float x, float y)
        {
            gfx.FillRectangle(Brushes.BlueViolet, new RectangleF(new Point(0, 0), new SizeF(x, y)));

            pen.Width = 9;
            gfx.DrawRectangle(pen, 0, 0, x, y);
        }

        private void DrawStars(float x, float y, double e)
        {
            float radius = (float)e;

            RectangleF r = new RectangleF(x, y, 2 * radius, 2 * radius);

            gfx.FillEllipse(Brushes.Pink, r);
        }

        private void DrawAsteroid(float x, float y, double e)
        {
            float k = (float)e;

            PointF[] p = { new PointF(x, y),
                           new PointF(x + 13 * k, y),
                           new PointF(x + 21 * k, y + 9 * k),
                           new PointF(x + 29 * k, y),
                           new PointF(x + 42 * k, y),
                           new PointF(x + 36 * k, y - 9 * k),
                           new PointF(x + 42 * k, y - 18 * k),
                           new PointF(x + 29 * k, y - 18 * k),
                           new PointF(x + 21 * k, y - 27 * k),
                           new PointF(x + 13 * k, y - 18 * k),
                           new PointF(x, y - 18 * k),
                           new PointF(x + 6 * k, y - 12 * k) };

            gfx.FillPolygon(Brushes.LightCyan, p);
        }

        private void DrawSpaceship(float x, float y, double e)
        {
            float k = (float)e;

            DrawBody(x, y, k);

            x += 23 * k;
            y -= 15 * k;

            DrawGun(x, y, k);
        }

        private void DrawGun(float x, float y, float k)
        {
            PointF[] p = { new PointF(x, y),
                           new PointF(x + 12 * k, y - 15 * k),
                           new PointF(x + 24 * k, y),
                           new PointF(x + 18 * k, y),
                           new PointF(x + 18 * k, y + 15 * k),
                           new PointF(x + 6 * k, y + 15 * k),
                           new PointF(x + 6 * k, y) };

            gfx.FillPolygon(Brushes.DarkGray, p);
        }

        private void DrawBody(float x, float y, float k)
        {
            PointF[] p = { new PointF(x, y),
                           new PointF(x + 36 * k, y + 18 * k),
                           new PointF(x + 72 * k, y),
                           new PointF(x + 72 * k, y - 30 * k),
                           new PointF(x + 36 * k, y - 48 * k),
                           new PointF(x, y - 30 * k) };

            gfx.FillPolygon(Brushes.OrangeRed, p);
        }
    }
}