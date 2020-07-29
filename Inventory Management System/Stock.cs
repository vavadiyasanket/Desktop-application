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
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            this.ActiveControl = dateTimePicker1;
            comboBox1.SelectedIndex = 0;
            resetRecords();
            LoadData();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Length <= 0)
                    textBox1.Focus();
                else
                {
                    textBox2.Focus();
                    string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory Management System.mdf;Integrated Security=True;Connect Timeout=90";
                    SqlConnection sqlConnection = new SqlConnection(conStr);
                    sqlConnection.Open();
                    var sqlQuery = "select ProductName from Stock where ProductCode = '" + textBox1.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(sqlQuery, sqlConnection);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if(dt.Rows.Count > 0)
                    {
                        textBox2.Text = dt.Rows[0][0].ToString();
                        button1.Text = "Update";
                        textBox3.Focus();
                    }
                    else
                    {
                        textBox2.Focus();
                    }
                   
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox3.Text.Length <= 0)
                    textBox2.Focus();
                else
                    textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBox1.Focus();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.Focus();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
                e.Handled = true;
        }

        private void resetRecords()
        {
            //dateTimePicker1.Value = DateTime.Now;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = 0;            
            dateTimePicker1.Focus();
            button1.Text = "Add";
        }

        private bool validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "Product code required");
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Product name required");
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Product quantity required");
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(comboBox1, "Product status required");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }

        private bool ifProductExist(SqlConnection con, String id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select 1 from  Stock where ProductCode = '" + id + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        

        public void LoadData()
        {
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory Management System.mdf;Integrated Security=True;Connect Timeout=90";
            SqlConnection sqlConnection = new SqlConnection(conStr);
            SqlDataAdapter sda = new SqlDataAdapter("select * from  Stock", sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int quantity = 0;

            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = n;
                dataGridView1.Rows[n].Cells[1].Value = item["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["ProductName"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["Quantity"].ToString();
                quantity += int.Parse(item["Quantity"].ToString());
                dataGridView1.Rows[n].Cells[4].Value = Convert.ToDateTime(item["TransDate"].ToString()).ToString("dd/MM/yyyy");

                if ((bool)item["ProductStatus"])
                    dataGridView1.Rows[n].Cells[5].Value = "Active";
                else
                    dataGridView1.Rows[n].Cells[5].Value = "Deactive";
            }
            label6.Text = "Total Products: " + (dataGridView1.Rows.Count.ToString());
            label7.Text = "Total Quantity: " + quantity;
        }
        DataTable dt;
        private void button1_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory Management System.mdf;Integrated Security=True;Connect Timeout=90";
                SqlConnection sqlConnection = new SqlConnection(conStr);
                sqlConnection.Open();
                bool status = false;
                status = comboBox1.SelectedIndex == 0 ? true : false;
                var sqlQuery = "";
                var sqlQuery1 ="";
                String str = "select ProductCode from Stock where ProductCode='"+ textBox1.Text +"'";
                SqlDataAdapter sd = new SqlDataAdapter(str, sqlConnection);
                dt = new DataTable();
                sd.Fill(dt);
               
                
               
                    if (ifProductExist(sqlConnection, textBox1.Text))
                    {
                        sqlQuery = "update Stock set ProductName = '" + textBox2.Text + "', ProductStatus = '" + status + "', TransDate = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "', Quantity = '" + textBox3.Text + "' where ProductCode = '" + textBox1.Text + "'";
                        sqlQuery1 = "update Products set ProductName = '" + textBox2.Text + "', ProductStatus = '" + status + "' where ProductCode = '" + textBox1.Text + "'";
                    }
                    else
                    {
                        sqlQuery = @"INSERT INTO Stock (ProductCode, ProductName, TransDate, Quantity, ProductStatus) VALUES  ('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox3.Text + "','" + status + "')";
                        sqlQuery1 = @"INSERT INTO Products (ProductCode, ProductName, ProductStatus) VALUES  ('" + textBox1.Text + "','" + textBox2.Text + "','" + status + "')";
                    }

                    SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand(sqlQuery1, sqlConnection);
                    cmd1.ExecuteNonQuery();
                    dt.Rows.Clear();
                    sqlConnection.Close();

                    //reading data
                    LoadData();
                    resetRecords();
                    button1.Text = "Add";
                }
              
            
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button1.Text = "Update";
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            dateTimePicker1.Text = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString()).ToString("dd/MM/yyyy");
            if (dataGridView1.SelectedRows[0].Cells[5].Value.ToString() == "Active")
                comboBox1.SelectedIndex = 0;
            else
                comboBox1.SelectedIndex = 1;
            
        }
        SqlConnection sqlConnection;
        private void button2_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory Management System.mdf;Integrated Security=True;Connect Timeout=90";
               sqlConnection = new SqlConnection(conStr);
                sqlConnection.Open();
                if (ifProductExist(sqlConnection, textBox1.Text))
                {
                    DialogResult dialogresult = MessageBox.Show("Are you sure you want to delete selected item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogresult == DialogResult.Yes)
                    {
                        var sqlQuery = "";
                        var sqlQuery1 = "";
                        sqlQuery = "delete from Stock where ProductCode = '" + textBox1.Text + "'";
                        sqlQuery1 = "delete from Products where ProductCode = '" + textBox1.Text + "' and ProductName = '" + textBox2.Text + "'";
                        SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);
                        cmd.ExecuteNonQuery();
                        SqlCommand cmd1 = new SqlCommand(sqlQuery1, sqlConnection);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Product deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sqlConnection.Close();
                        LoadData();
                        resetRecords();
                    }
                }
                else
                {
                    MessageBox.Show("No product found", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resetRecords();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            resetRecords();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory Management System.mdf;Integrated Security=True;Connect Timeout=90";
            sqlConnection = new SqlConnection(conStr);
            sqlConnection.Open();
            String str = "select * from Stock";
            SqlCommand cmd2 = new SqlCommand(str, sqlConnection);

            SqlDataAdapter sda = new SqlDataAdapter(str, sqlConnection);
            dt = new DataTable();
            sda.Fill(dt);
            int quantity = 0;
           // int j = 0;
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {

                string a = textBox1.Text.ToString();
                string b = item["ProductCode"].ToString();
                if (a == b)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = n;
                    dataGridView1.Rows[n].Cells[1].Value = item["ProductCode"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item["ProductName"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item["Quantity"].ToString();
                    quantity += int.Parse(item["Quantity"].ToString());
                    dataGridView1.Rows[n].Cells[4].Value = Convert.ToDateTime(item["TransDate"].ToString()).ToString("dd/MM/yyyy");

                    if ((bool)item["ProductStatus"])
                        dataGridView1.Rows[n].Cells[5].Value = "Active";
                    else
                        dataGridView1.Rows[n].Cells[5].Value = "Deactive";
                    button1.Text = "Update";
                    textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    dateTimePicker1.Text = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString()).ToString("dd/MM/yyyy");
                    if (dataGridView1.SelectedRows[0].Cells[5].Value.ToString() == "Active")
                        comboBox1.SelectedIndex = 0;
                    else
                        comboBox1.SelectedIndex = 1;
                }

            }
            if (textBox1.Text.Length > 0)
            {
                LoadSpecific(textBox1.Text);
               
            }
            else if (textBox1.Text.Length == 0)
            {
                button1.Text = "Add";
                resetRecords();
                LoadData();
            }
        }

        void LoadSpecific(string ProductCode)
        {
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory Management System.mdf;Integrated Security=True;Connect Timeout=90";
            SqlConnection sqlConnection = new SqlConnection(conStr);
            SqlDataAdapter sda = new SqlDataAdapter("select * from  Stock where ProductCode like '"+ProductCode+"%'", sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int quantity = 0;

            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = n;
                dataGridView1.Rows[n].Cells[1].Value = item["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["ProductName"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["Quantity"].ToString();
                quantity += int.Parse(item["Quantity"].ToString());
                dataGridView1.Rows[n].Cells[4].Value = Convert.ToDateTime(item["TransDate"].ToString()).ToString("dd/MM/yyyy");

                if ((bool)item["ProductStatus"])
                    dataGridView1.Rows[n].Cells[5].Value = "Active";
                else
                    dataGridView1.Rows[n].Cells[5].Value = "Deactive";
            }
            label6.Text = "Total Products: " + (dataGridView1.Rows.Count.ToString());
            label7.Text = "Total Quantity: " + quantity;
           
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dsb = new Dashboard();
            dsb.StartPosition = FormStartPosition.CenterScreen;
            dsb.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
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

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Violet;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.CornflowerBlue;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Violet;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.CornflowerBlue;
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
