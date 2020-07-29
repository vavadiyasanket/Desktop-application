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
    public partial class StockMain : Form
    {
        string uname;
        public StockMain(string uname)
        {
            InitializeComponent();
            this.uname = uname;
        }
        

        

        bool close = true;
        private void StockMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close)
            {
                DialogResult dialogresult = MessageBox.Show("Are you sure you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogresult == DialogResult.Yes)
                {
                    close = false;
                    Application.Exit();
                }
                else
                    e.Cancel = true;
            }
        }
       
        private void StockMain_Load(object sender, EventArgs e)
        {
            label3.Text = uname;
            panel5.BackColor = Color.MediumSlateBlue;
            panel6.BackColor = Color.MediumSlateBlue;
            panel7.BackColor = Color.MediumSlateBlue;
            
        }

       


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Exit ex = new Exit();
            if (d != null)
                d.Close();
            if (abt != null)
                abt.Close();
            if (lg != null)
                lg.Close();
            ex.StartPosition = FormStartPosition.CenterScreen;
            ex.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
           else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;


            }
        }


        private void button2_MouseHover(object sender, EventArgs e)
        {
           
            button2.BackColor = Color.DarkOrchid;
            panel5.BackColor = Color.Violet;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
           
            button2.BackColor = Color.MediumSlateBlue;
            panel5.BackColor = Color.MediumSlateBlue;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
           
            button3.BackColor = Color.DarkOrchid;
            panel6.BackColor = Color.Violet;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
           
            button3.BackColor = Color.MediumSlateBlue;
            panel6.BackColor = Color.MediumSlateBlue;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
           
            button4.BackColor = Color.DarkOrchid;
            panel7.BackColor = Color.Violet;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
           
            button4.BackColor = Color.MediumSlateBlue;
            panel7.BackColor = Color.MediumSlateBlue;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

      

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.MediumSlateBlue;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }
        Dashboard d;
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (d == null)
            {
                if (abt != null)
                    abt.Close();
                if (lg != null)
                    lg.Close();
                d = new Dashboard();
                d.MdiParent = this;
                d.StartPosition = FormStartPosition.CenterScreen;

                d.FormClosed += new FormClosedEventHandler( D_FormClosed);
                d.Show();
            }
            
        }

        private void D_FormClosed(object sender, FormClosedEventArgs e)
        {
            d = null;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        AboutUs abt;
        private void button3_Click(object sender, EventArgs e)
        {
            if (abt == null)
            {
                if (d != null)
                    d.Close();
                if (lg != null)
                    lg.Close();
                abt = new AboutUs();
                abt.MdiParent = this;
                abt.StartPosition = FormStartPosition.CenterScreen;

                abt.FormClosed += new FormClosedEventHandler(Abt_FormClosed);
                abt.Show();
            }
        }

        private void Abt_FormClosed(object sender, FormClosedEventArgs e)
        {
            abt = null;
        }
        Logout lg;
        private void button4_Click(object sender, EventArgs e)
        {


            if (lg == null)
            {
                if (d != null)
                    d.Close();
                if (abt != null)
                    abt.Close();
                lg = new Logout();
                lg.MdiParent = this;
                lg.StartPosition = FormStartPosition.CenterScreen;

                lg.FormClosed += new FormClosedEventHandler(Lg_FormClosed);
               
                lg.Show();
            
            }
            

        }

        private void Lg_FormClosed(object sender, FormClosedEventArgs e)
        {
            lg = null;
        }

        private void StockMain_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button2_Leave(object sender, EventArgs e)
        {
           
        }
    }
}
