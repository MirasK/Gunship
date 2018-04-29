using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buttons
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateBtns();
        }

        private Button[] Btn = new Button[100];
        int k = 0;

        private void CreateBtns()
        {
            int a = 40;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(a, a);
                    btn.Location = new Point(j * a, i * a);
                    btn.Click += button_Click;
                    btn.Text = k.ToString();
                    this.Controls.Add(btn);
                    Btn[k] = btn;
                    k++;
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button B =  sender as Button;
            for (int i = 0; i < 100; i++)
            {
                    if (int.Parse(Btn[i].Text) % 10 == int.Parse(B.Text) % 10 ) //vert
                {
                    Btn[i].BackColor = Color.Black;

                }
                    else if (int.Parse(Btn[i].Text) / 10 == int.Parse(B.Text) / 10) //hor
                {
                    Btn[i].BackColor = Color.Black;
                }
                    else
                    Btn[i].BackColor = Color.White;
            }

        }

    private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
