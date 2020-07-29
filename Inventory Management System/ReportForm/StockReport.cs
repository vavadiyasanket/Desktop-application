using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    public partial class StockReport : Form
    {
        ReportDocument crept = new ReportDocument();
        public StockReport()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StockReport_Load(object sender, EventArgs e)
        {

        }
        DataSet dst = new DataSet();
        private void button1_Click(object sender, EventArgs e)
        {
            crept.Load(Application.StartupPath + "\\Reports\\Stocks.rpt");
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory Management System.mdf;Integrated Security=True;Connect Timeout=90";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [Stock] where Cast(TransDate as Date) between '"+ dateTimePicker1.Value.ToString("MM/dd/yyyy")+"' and '"+ dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'", con);
            sda.Fill(dst,"Stock");
            crept.SetDataSource(dst);
            crept.SetParameterValue("@FromDate", dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            crept.SetParameterValue("@ToDate", dateTimePicker2.Value.ToString("dd/MM/yyyy"));
            crystalReportViewer1.ReportSource = crept;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportOptions exportOption;
            DiskFileDestinationOptions diskFileDestinationOptions = new DiskFileDestinationOptions();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pdf Files|*.pdf";
           // sfd.Filter = "Excel|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                diskFileDestinationOptions.DiskFileName = sfd.FileName;
            }
            exportOption = crept.ExportOptions;
            {
                exportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                exportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
             //   exportOption.ExportFormatType = ExportFormatType.Excel;
                exportOption.ExportDestinationOptions = diskFileDestinationOptions;
                exportOption.ExportFormatOptions = new PdfRtfWordFormatOptions();
              //  exportOption.ExportFormatOptions = new ExcelFormatOptions();
            }
            crept.Export();
        }

        private void StockReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Report rpt = new Report();
            rpt.StartPosition = FormStartPosition.CenterScreen;
            rpt.Show();
        }
    }
}
