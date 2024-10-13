using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gold.PL;
using gold1.PL;

namespace Gold
{
    public partial class Form2 : Form
    {
        String username;
        public Form2(String username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FRM_BILL b = new FRM_BILL();
            b.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FRM_JEWELER j = new FRM_JEWELER();
            
            j.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FRM_ITEMS item = new FRM_ITEMS();
            item.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label5.Text = username;
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FRM_ROLE role = new FRM_ROLE();
            role.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FRM_CUSTOMERACCOUNT ca = new FRM_CUSTOMERACCOUNT();
            ca.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FRM_CASH c = new FRM_CASH();
            c.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FRM_PAY p = new FRM_PAY();
            p.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FRM_CONTRIBUTER con = new FRM_CONTRIBUTER();
            con.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FRM_DRAFT dr = new FRM_DRAFT();
            dr.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FRM_EXPENSES fr = new FRM_EXPENSES();
            fr.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FRM_STORE store = new FRM_STORE();
            store.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FRM_CAT cat = new FRM_CAT();
            cat.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FRM_TREEVIEW tree = new FRM_TREEVIEW();
            tree.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.ShowDialog();
        }
    }
}
