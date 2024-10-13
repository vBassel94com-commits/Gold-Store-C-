using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gold1.BL;

namespace gold1.PL
{
    public partial class FRM_CONTRIBUTER : Form
    {
        CLS_CONTRIBUTER con = new CLS_CONTRIBUTER();
        public FRM_CONTRIBUTER()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FRM_CONTRIBUTER_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.conSelect();
            DataTable dt = con.conSum();
            if(dt.Rows[0][0].ToString() != String.Empty )
            {
                textBox1.Text = dt.Rows[0][0].ToString();
            }
            else
            {

            }
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            con.conAdd(textBox2.Text , Convert.ToDouble(textBox3.Text));
            dataGridView1.DataSource = con.conSelect();
            DataTable dt = con.conSum();
            if (dt.Rows[0][0].ToString() != String.Empty)
            {
                textBox1.Text = dt.Rows[0][0].ToString();
            }
            else
            {

            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.conEdit(Convert.ToInt32(textBox4.Text), textBox2.Text, Convert.ToDouble(textBox3.Text));
            dataGridView1.DataSource = con.conSelect();
            DataTable dt = con.conSum();
            if (dt.Rows[0][0].ToString() != String.Empty)
            {
                textBox1.Text = dt.Rows[0][0].ToString();
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.conDelete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            dataGridView1.DataSource = con.conSelect();
            DataTable dt = con.conSum();
            if (dt.Rows[0][0].ToString() != String.Empty)
            {
                textBox1.Text = dt.Rows[0][0].ToString();
            }
            else
            {

            }
        }
    }
}
