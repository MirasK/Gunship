using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading.Tasks;

namespace RedBlue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Button btn = new Button();
        Random r1 = new Random();
        Random r2 = new Random();
        int score = 0, k = 0;
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btn.Size = new Size(50, 50);

            btn.Location = new Point(r2.Next(0, 300), r2.Next(0, 300));
            
            
            btn.Click += button_Click;

            k = int.Parse(r1.Next(0,2).ToString());

            if (k == 0)
            {
                btn.BackColor = Color.Red;
            }
            else
            {
                btn.BackColor = Color.Blue;
            }

            Controls.Add(btn);
        }

        private void button_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;

            if (k==0)
            {
                score--;
                label2.Text = score.ToString();
            }

            else
            {
                score++;
                label2.Text = score.ToString();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //label2.Text = score.ToString();
        }
    }
}
