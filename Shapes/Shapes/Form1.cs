using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Shapes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }

        Graphics g;
        int x, y;

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            x = int.Parse(textBox1.Text);
            y = int.Parse(textBox2.Text);
            Pen pen = new Pen(Color.Black);

            g.DrawLine(pen, x, y, x-50, y + 100);
            g.DrawLine(pen, x, y, x + 50, y + 100);
            g.DrawLine(pen, x - 50, y + 100, x + 50, y + 100);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            x = int.Parse(textBox1.Text);
            y = int.Parse(textBox2.Text);
            Pen pen = new Pen(Color.Black);
            Rectangle r = new Rectangle(x, y, 100, 100);
            g.DrawRectangle(pen, r);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            x = int.Parse(textBox1.Text);
            y = int.Parse(textBox2.Text);
            Pen pen = new Pen(Color.Black);
            Rectangle r = new Rectangle(x, y, 100, 100);

            g.DrawLine(pen, x, y, x + 100, y);
            g.DrawLine(pen, x, y, x - 50, y + 100);
            g.DrawLine(pen, x + 100, y, x + 150, y + 100);
            g.DrawLine(pen, x - 50, y + 100, x + 150, y + 100);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = int.Parse(textBox1.Text);
            y = int.Parse(textBox2.Text);
            Pen pen = new Pen(Color.Black);
            Rectangle r = new Rectangle(x, y, 100, 100);
            g.DrawEllipse(pen, r);
        }
    }
}
