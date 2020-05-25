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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            foreach (string str in listBox2.Items)
                listBox1.Items.Add(str);
            listBox2.Items.Clear();
            button4.Enabled = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox1.Items.Add("AI");
            listBox1.Items.Add("ML");
            listBox1.Items.Add("DL");
            listBox1.Items.Add("Block chain");
            listBox1.Items.Add("IoT");
            listBox1.Items.Add("Java");
            listBox1.Items.Add("Python");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                button2.Enabled = true;
                button4.Enabled = true;
                listBox2.Items.Add(listBox1.SelectedItem.ToString());
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
                MessageBox.Show("Select item");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            foreach (string str in listBox1.Items)
                listBox2.Items.Add(str);
            listBox1.Items.Clear();
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                button4.Enabled = true;
                button2.Enabled = true;
                listBox1.Items.Add(listBox2.SelectedItem.ToString());
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
            else
                MessageBox.Show("Select Item");
        }
    }
}
