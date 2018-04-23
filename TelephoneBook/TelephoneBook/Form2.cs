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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                MessageBox.Show("Data Error! \n" + "Add information", 
                    "TelephoneBook", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                string m = textBox1.Text;
                string text = File.ReadAllText("E:\\1.txt");
                using (StreamReader sr = new StreamReader("E:\\1.txt"))
                {
                    if (text.Contains(m))
                    {
                        MessageBox.Show("Phone exist");
                    }

                    else
                    {
                        sr.Close();
                        StreamWriter sw = new StreamWriter("E:\\1.txt", true);

                        sw.WriteLine(textBox1.Text);
                        sw.WriteLine(textBox2.Text);
                        sw.Close();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        MessageBox.Show("Contact saved");
                    }
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
