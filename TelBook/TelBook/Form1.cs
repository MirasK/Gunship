Skip to content
This repository
Search
Pull requests
Issues
Marketplace
Explore
 @MirasK
Sign out
0
0 1 dorenyerbolov/pp2byDaurenYerbolov
 Code  Issues 0  Pull requests 0  Projects 0  Wiki Insights
pp2byDaurenYerbolov/lab13 MyTelehponeBook/MySQLSample2/Form1.cs
5c5f92a  14 hours ago
@dorenyerbolov dorenyerbolov mytelephonebook
     
118 lines(101 sloc)  3.72 KB
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQLSample2
{
    public partial class Form1 : Form
    {
        MySqlConnection mySqlConnection, mySqlConnection2;
        MySqlDataAdapter mySqlDataAdapter;
        MySqlCommandBuilder mySqlCommandBuilder;
        DataTable dataTable;
        BindingSource bindingSource;
        public int increment = 0;
        public int maxRows;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mySqlConnection = new MySqlConnection(
               "SERVER=localhost;" +
               "DATABASE=fitbd;" +
               "UID=root;" +
               "PASSWORD=;");
            mySqlConnection.Open();

            string query = "SELECT * FROM MyTelephoneBook";
            //LIMIT 1 OFFSET " + increment;
            Setup(query, mySqlConnection);
            GetMaxNumberOfRows();

        }
        private void GetMaxNumberOfRows()
        {

            string query2 = "SELECT COUNT(*) FROM MyTelephoneBook";
            mySqlConnection2 = new MySqlConnection(
                   "SERVER=localhost;" +
                   "DATABASE=fitbd;" +
                   "UID=root;" +
                   "PASSWORD=;");
            mySqlConnection2.Open();
            MySqlCommand command = new MySqlCommand(query2, mySqlConnection2);
            maxRows = int.Parse(command.ExecuteScalar().ToString());
            mySqlConnection2.Close();
        }
        private void Setup(string query, MySqlConnection mySqlConnection)
        {
            mySqlDataAdapter = new MySqlDataAdapter(query, mySqlConnection);
            mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);

            mySqlDataAdapter.UpdateCommand = mySqlCommandBuilder.GetUpdateCommand();
            mySqlDataAdapter.DeleteCommand = mySqlCommandBuilder.GetDeleteCommand();
            mySqlDataAdapter.InsertCommand = mySqlCommandBuilder.GetInsertCommand();

            dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);

            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            dataGridView1.DataSource = bindingSource;
            bindingNavigator1.BindingSource = bindingSource;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mySqlDataAdapter.Update(dataTable);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "SELECT* FROM MyTelephoneBook ORDER BY RegistrationDate";
            Setup(query, mySqlConnection);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            string query = "SELECT * FROM MyTelephoneBook WHERE Firstname LIKE" + " '%" + s + "'";

            Setup(query, mySqlConnection);
            textBox1.Text = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (increment <= maxRows)
            {
                increment += 3;
                string query = "SELECT * FROM MyTelephoneBook LIMIT 3 OFFSET " + increment;
                Setup(query, mySqlConnection);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (increment >= 3)
            {
                increment -= 3;
                string query = "SELECT * FROM MyTelephoneBook LIMIT 3 OFFSET " + increment;
                Setup(query, mySqlConnection);
            }
        }
    }
}
© 2018 GitHub, Inc.
Terms
Privacy
Security
Status
Help
Contact GitHub
API
Training
Shop
Blog
About
Press h to open a hovercard with more details.