using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicControl
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            comboBox1.Items.Add("AI");
            comboBox1.Items.Add("ML");
            comboBox1.Items.Add("DL");
            comboBox1.Items.Add("Block chain");
            comboBox1.Items.Add("IoT");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                label1.Visible = true;
                label1.Text = "You selected: " + comboBox1.SelectedItem.ToString();
            }
            else
                MessageBox.Show("No item selected");
        }
    }
}
