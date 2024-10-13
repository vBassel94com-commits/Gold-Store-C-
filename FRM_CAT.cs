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
    public partial class FRM_CAT : Form
    {
        CLS_CAT cat = new CLS_CAT();
        public FRM_CAT()
        {
            InitializeComponent();
        }

        private void FRM_CAT_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cat.catSelect();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cat.catAdd(textBox2.Text , Convert.ToDouble(textBox1.Text));
            dataGridView1.DataSource = cat.catSelect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cat.catEdit(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()),textBox2.Text, Convert.ToDouble(textBox1.Text));
            dataGridView1.DataSource = cat.catSelect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cat.catDelete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            dataGridView1.DataSource = cat.catSelect();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
