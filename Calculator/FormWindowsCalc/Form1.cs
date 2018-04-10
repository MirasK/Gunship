using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormWindowsCalc
{
    public partial class Form1 : Form
    {
        float x, y;
        int count;
        bool znak = true;

        private void calculate()
        {
            switch (count)
            {
                case 1:
                    y = x + float.Parse(textBox1.Text);
                    textBox1.Text = y.ToString();
                    break;
                case 2:
                    y = x - float.Parse(textBox1.Text);
                    textBox1.Text = y.ToString();
                    break;
                case 3:
                    y = x * float.Parse(textBox1.Text);
                    textBox1.Text = y.ToString();
                    break;
                case 4:
                    y = x / float.Parse(textBox1.Text);
                    textBox1.Text = y.ToString();
                    break;
                case 5:
                    y = x * x;
                    textBox1.Text = y.ToString();
                    break;
                case 6:
                    y = x * x * x;
                    textBox1.Text = y.ToString();
                    break;
                
                default:
                    break;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 5;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ".";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 1;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 2;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 3;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 4;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            x = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 1;
            label2.Text = x.ToString() + "+";
            znak = true;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            x = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 2;
            label2.Text = x.ToString() + "-";
            znak = true;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            x = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 3;
            label2.Text = x.ToString() + "×";
            znak = true;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            x = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 4;
            label2.Text = x.ToString() + "/";
            znak = true;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            calculate();
            label2.Text = "";
        }

        private void button35_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label2.Text = "";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            int lenght = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            for (int i = 0; i < lenght; i++)
            {
                textBox1.Text = textBox1.Text + text[i];
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (znak == true)
            {
                textBox1.Text = "-" + textBox1.Text;
                znak = false;
            }
            else if (znak == false)
            {
                textBox1.Text = textBox1.Text.Replace("-", "");
                znak = true;
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + Math.PI;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            x = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 5;
            label2.Text = x.ToString() + "^2";
            znak = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            x = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 6;
            label2.Text = x.ToString() + "^3";
            znak = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
        }

        private void button34_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 9;
        }
    }
}
