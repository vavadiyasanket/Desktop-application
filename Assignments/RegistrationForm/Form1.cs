using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AssignmentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conStr);
            string gen;
            if (radioButton1.Checked == true)
                gen = "Male";
            else
                gen = "Female";
            string query = @"insert into RegisteredUser (Name, Address, Country, Mobile, Gender, DOB, Language, Id) values ('"+textBox1.Text+"', '"+richTextBox1.Text+"', '"+comboBox1.SelectedItem.ToString()+"', '"+textBox2.Text+"', '"+gen+"', '"+dateTimePicker1.Value.ToString("yyyy-MM-DD")+"', '"+listBox1.SelectedItem.ToString()+"', '"+textBox3.Text+"');";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data inserted");
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("India");
            comboBox1.Items.Add("USA");
            comboBox1.Items.Add("Russia");
            comboBox1.Items.Add("Isereal");
            comboBox1.Items.Add("Canada");
            listBox1.Items.Add("English");
            listBox1.Items.Add("Gujarati");
            listBox1.Items.Add("Canadian");
            listBox1.Items.Add("Chienese");
            listBox1.Items.Add("Other");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                label5.Text = "+91";
            else if (comboBox1.SelectedIndex == 1)
                label5.Text = "+1";
            else if (comboBox1.SelectedIndex == 2)
                label5.Text = "+243";
            else if (comboBox1.SelectedIndex == 3)
                label5.Text  = "+92";
            else if (comboBox1.SelectedIndex == 4)
                label5.Text  = "+5";
            else
                label5.Visible = false;
        }
    }
}
