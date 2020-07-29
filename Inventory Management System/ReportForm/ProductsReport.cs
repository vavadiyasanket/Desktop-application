using CrystalDecisions.CrystalReports.Engine;
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

namespace Inventory_Management_System.ReportForm
{
    public partial class ProductsReport : Form
    {
        ReportDocument crept = new ReportDocument();
        public ProductsReport()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
           

        }

        private void ProductsReport_Load(object sender, EventArgs e)
        {
            crept.Load(Application.StartupPath+"\\Reports\\Product.rpt");
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory Management System.mdf;Integrated Security=True;Connect Timeout=90";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            DataSet dst = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [Products]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            crept.SetDataSource(dt);
            crystalReportViewer1.ReportSource = crept;
        }

        private void ProductsReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Report rpt = new Report();
            rpt.StartPosition = FormStartPosition.CenterScreen;
            rpt.Show();
        }
    }
}
