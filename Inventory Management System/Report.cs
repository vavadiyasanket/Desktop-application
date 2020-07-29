using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management_System
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dsb = new Dashboard();
            dsb.StartPosition = FormStartPosition.CenterScreen;
            dsb.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportForm.ProductsReport prorpt = new ReportForm.ProductsReport();
            prorpt.StartPosition = FormStartPosition.CenterScreen;
            prorpt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportForm.StockReport stkrpt = new ReportForm.StockReport();
            stkrpt.StartPosition = FormStartPosition.CenterScreen;
            stkrpt.Show();
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
    }
}
