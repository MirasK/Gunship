using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TelephoneBook
{
    public struct Customers
    {
        public string name;
        public string number;
    }

    public partial class Form1 : Form
    {
        List<Customers> l = new List<Customers>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
        }

        int find(string s)
        {
            for (int i = 0; i < l.Count; i++)
            { 
                if (l[i].name.Equals(s))
                    return i;
            }

            return -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") ||(textBox2.Text == ""))
            {
                MessageBox.Show ( "Data Error! \n" + "Add information", 
                    "TelephoneBook", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                Customers A;
                A.name = textBox1.Text;
                A.number = textBox2.Text;
                int x = find(A.name);

                if (x == -1)
                {
                    l.Add(A);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MessageBox.Show("It's OK!");
                }

                else
                {
                    MessageBox.Show("OK!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            int x = find(s);

            if (x != -1)
            {
                textBox2.Text = l[x].number;
            }

            else
            {
                MessageBox.Show("Unable to find:(");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 s = new Form2();
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("E:\\1.txt");
            string m;

            while ((m = sr.ReadLine()) != null)
            {
                Customers A;
                A.name = m;
                A.number = sr.ReadLine();
                l.Add(A);
            }
            sr.Close();
        }
    }
}
