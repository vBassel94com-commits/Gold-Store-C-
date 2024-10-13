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

namespace gold1.PL
{
    public partial class FRM_EXPENSES : Form
    {
        CLS_BILLITEMS bi = new CLS_BILLITEMS();
        public FRM_EXPENSES()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bi.exAdd(textBox4.Text,Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox1.Text), Convert.ToDouble(textBox3.Text),dateTimePicker1.Value);
            dataGridView2.DataSource = bi.exSelect();
            this.Close();
        }

        private void FRM_EXPENSES_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = bi.exSelect();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox3.Text = Math.Round((Convert.ToDouble(textBox2.Text) /Convert.ToDouble(textBox1.Text)), 2).ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
