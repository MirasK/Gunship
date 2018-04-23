using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Main : Form
    {
        Brain brain = new Brain();

        public Main()
        {
            InitializeComponent();
            brain.invoker = ShowInfo;
        }

        public void BtnClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            brain.Process(b.Text);
        }

        public void ShowInfo(string msg)
        {
            Display.Text = msg;
        }

        private void Display_TextChanged(object sender, EventArgs e)
        {

        }
    }
}