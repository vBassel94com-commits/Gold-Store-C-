using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gold1.BL;

namespace Gold
{
    public partial class Form1 : Form
    {
        CLS_ROLE role = new CLS_ROLE();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(comboBox1.Text == "admin" && textBox2.Text == "admin")
            {
                Form2 f = new Form2("admin");
                f.ShowDialog();
            }
            else
            {
                DataTable dt = role.passwordSelect(comboBox1.Text);
                if(dt.Rows[0][2].ToString() == textBox2.Text)
                {
                    Form2 f = new Form2(comboBox1.Text);
                    f.ShowDialog();
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = role.roleSelect();
            comboBox1.DisplayMember = "username";
            comboBox1.ValueMember = "ID";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (comboBox1.Text == "admin" && textBox2.Text == "admin")
                {
                    Form2 f = new Form2("admin");
                    f.ShowDialog();
                }
                else
                {
                    DataTable dt = role.passwordSelect(comboBox1.Text);
                    if (dt.Rows[0][2].ToString() == textBox2.Text)
                    {
                        Form2 f = new Form2(comboBox1.Text);
                        f.ShowDialog();
                    }

                }
            }
        }
    }
}
