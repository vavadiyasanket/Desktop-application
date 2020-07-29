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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Products pro;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            if (pro == null)
            {
                pro = new Products();
                pro.FormClosed += new FormClosedEventHandler(Pro_FormClosed);
                pro.StartPosition = FormStartPosition.CenterScreen;
                pro.Show();
            }
        }
        private void Pro_FormClosed(object sender, FormClosedEventArgs e)
        {
            pro = null;
        }

        Stock stk;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            if (stk == null)
            {
                stk = new Stock();
                stk.FormClosed += new   FormClosedEventHandler(Stk_FormClosed);
                stk.StartPosition = FormStartPosition.CenterScreen;
                stk.Show();
            }
        }

        private void Stk_FormClosed(object sender, FormClosedEventArgs e)
        {
            stk = null;
        }

        Report rpt;
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            if (rpt == null)
            {
                rpt = new Report();
                rpt.FormClosed += new FormClosedEventHandler(Rpt_FormClosed);
                rpt.StartPosition = FormStartPosition.CenterScreen;
                rpt.Show();
            }
        }

        private void Rpt_FormClosed(object sender, FormClosedEventArgs e)
        {
            rpt = null;
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
