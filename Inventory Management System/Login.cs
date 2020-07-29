using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inventory_Management_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((textBox1.Text == "kunj" || textBox1.Text == "meet" || textBox1.Text == "sanket"|| textBox1.Text=="pdd" || textBox1.Text == "parth") && textBox2.Text == "admin")
            {
                //SqlConnection con = new SqlConnection("Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = I:\Lab\DotNet\Inventory Management System\DatabaseIMS\Inventory Management System.mdf; Integrated Security = True; Connect Timeout = 30");
                this.Hide();
                StockMain main = new StockMain(textBox1.Text);
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username & Password..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button2_Click(sender, e);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if(this.WindowState!=FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;


            }
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Red;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Blue;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
          
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatAppearance.BorderColor =Color.Blue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        { 
            button1.FlatAppearance.BorderSize = 0;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatAppearance.BorderColor = Color.Blue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.FlatAppearance.BorderSize = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
