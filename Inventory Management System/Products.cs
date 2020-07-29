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

namespace Inventory_Management_System
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        DataTable dt;
        SqlConnection sqlConnection;
        private void button2_Click(object sender, EventArgs e)
        {


            if (validation())
            {
                string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory Management System.mdf;Integrated Security=True;Connect Timeout=90";
                sqlConnection = new SqlConnection(conStr);
                sqlConnection.Open();
                bool status = false;
                status = statuscomboBox.SelectedIndex == 0 ? true : false;
               
                    var sqlQuery = "";
                    var sqlQuery1 = "";
                    if (ifProductExist(sqlConnection, pcodetxtbox.Text))
                    {

                        sqlQuery = "update Products set ProductName = '" + pnametxtbox.Text + "', ProductStatus = '" + status + "' where ProductCode = '" + pcodetxtbox.Text + "'";
                        sqlQuery1 = "update Stock set ProductName = '" + pnametxtbox.Text + "', ProductStatus = '" + status + "', TransDate = '', Quantity = '' where ProductCode = '" + pcodetxtbox.Text + "'";

                    }
                    else
                    {
                        sqlQuery = "insert into Products (ProductCode, ProductName, ProductStatus) values ('" + pcodetxtbox.Text + "', '" + pnametxtbox.Text + "', '" + status + "')";
                        sqlQuery1 = @"INSERT INTO Stock (ProductCode, ProductName, TransDate, Quantity, ProductStatus) VALUES  ('" + pcodetxtbox.Text + "','" + pnametxtbox.Text + "','','','" + status + "')";
                    }
                    SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand(sqlQuery1, sqlConnection);
                    cmd1.ExecuteNonQuery();
                    sqlConnection.Close();

                    //reading data
                    LoadData();
                    resetTextBox();

                    button2.Text = "Add";

              

            }

        }    
          
          
             
            
        

        private bool ifProductExist(SqlConnection con, String id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select 1 from  Products where ProductCode = '" + id+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        private void Products_Load(object sender, EventArgs e)
        {
            //statuscomboBox.SelectedIndex = 0;
            LoadData();
        }

        public void LoadData()
        {
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory Management System.mdf;Integrated Security=True;Connect Timeout=90";
            SqlConnection sqlConnection = new SqlConnection(conStr);
            SqlDataAdapter sda = new SqlDataAdapter("select * from  Products", sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["ProductName"].ToString();
                if ((bool)item["ProductStatus"])
                    dataGridView1.Rows[n].Cells[2].Value = "Active";
                else
                    dataGridView1.Rows[n].Cells[2].Value = "Deactive";
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button2.Text = "Update";
            pcodetxtbox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            pnametxtbox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString() == "Active")
                statuscomboBox.SelectedIndex = 0;
            else
                statuscomboBox.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory Management System.mdf;Integrated Security=True;Connect Timeout=90";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            bool status = false;
            status = statuscomboBox.SelectedIndex == 0 ? true : false;
            var sqlQuery = "";
            var sqlQuery1 = "";
            if (ifProductExist(con, pcodetxtbox.Text))
            {
                DialogResult dialogresult = MessageBox.Show("Are you sure you want to delete selected item?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogresult == DialogResult.Yes)
                {
                    sqlQuery = "delete from Products where ProductCode = '" + pcodetxtbox.Text + "' and ProductName = '" + pnametxtbox.Text + "'";
                    sqlQuery1 = "delete from Stock where ProductCode = '" + pcodetxtbox.Text + "'";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand(sqlQuery1, con);
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Product not found", "Wrong Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //reading data
            LoadData();

            resetTextBox();
            button2.Text = "Add";
        }
        public void resetTextBox()
        {
            pcodetxtbox.Clear();
            pnametxtbox.Clear();
            pcodetxtbox.Focus();
            statuscomboBox.SelectedIndex = -1;
            button2.Text = "Add";
        }

        private bool validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(pcodetxtbox.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(pcodetxtbox, "Product code required");
            }
            else if (string.IsNullOrEmpty(pnametxtbox.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(pnametxtbox, "Product name required");
            }
            else if (statuscomboBox.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(statuscomboBox, "Product status required");
            }
            else
                result = true;
           return result;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            resetTextBox();
        }
        void LoadSpecific(string ProductCode)
        {
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory Management System.mdf;Integrated Security=True;Connect Timeout=90";
            SqlConnection sqlConnection = new SqlConnection(conStr);
            SqlDataAdapter sda = new SqlDataAdapter("select * from  Products where ProductCode like '" + ProductCode + "%'", sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //int quantity = 0;

            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
               // dataGridView1.Rows[n].Cells[0].Value = n;
                dataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["ProductName"].ToString();
               // dataGridView1.Rows[n].Cells[3].Value = item["Quantity"].ToString();
              /*  quantity += int.Parse(item["Quantity"].ToString());
                dataGridView1.Rows[n].Cells[4].Value = Convert.ToDateTime(item["TransDate"].ToString()).ToString("dd/MM/yyyy");
                */
                if ((bool)item["ProductStatus"])
                    dataGridView1.Rows[n].Cells[2].Value = "Active";
                else
                    dataGridView1.Rows[n].Cells[2].Value = "Deactive";
            }
           /* label6.Text = "Total Products: " + (dataGridView1.Rows.Count.ToString());
            label7.Text = "Total Quantity: " + quantity;*/
        }
        private void pcodetxtbox_TextChanged(object sender, EventArgs e)
        {
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory Management System.mdf;Integrated Security=True;Connect Timeout=90";
            sqlConnection = new SqlConnection(conStr);
            sqlConnection.Open();
            String str = "select * from Products";
            SqlCommand cmd2 = new SqlCommand(str, sqlConnection);

            SqlDataAdapter sda = new SqlDataAdapter(str, sqlConnection);
            dt = new DataTable();
            sda.Fill(dt);
           
           
            dataGridView1.Rows.Clear();
            foreach (DataRow dtr in dt.Rows)
            {
                
                string a = pcodetxtbox.Text.ToString();
                    string b = dtr["ProductCode"].ToString();
                    if (a == b)
                    {
                         int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = dtr["ProductCode"].ToString();
                        dataGridView1.Rows[n].Cells[1].Value = dtr["ProductName"].ToString();
                        if ((bool)dtr["ProductStatus"])
                            dataGridView1.Rows[n].Cells[2].Value = "Active";
                        else
                             dataGridView1.Rows[n].Cells[2].Value = "Deactive";
                           button2.Text = "Update";
                        pcodetxtbox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        pnametxtbox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString() == "Active")
                            statuscomboBox.SelectedIndex = 0;
                        else
                            statuscomboBox.SelectedIndex = 1;
                    }
                
            }
            if (pcodetxtbox.Text.Length > 0)
                LoadSpecific(pcodetxtbox.Text);
            else if (pcodetxtbox.Text.Length == 0)
            {
                button2.Text = "Add";
                resetTextBox();
                LoadData();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dsb = new Dashboard();
            dsb.StartPosition = FormStartPosition.CenterScreen;
            dsb.Show();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.DarkOrchid;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.CornflowerBlue;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Violet;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.CornflowerBlue;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Violet;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
           button1.BackColor = Color.CornflowerBlue;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.Violet;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.CornflowerBlue;
        }
    }
}
