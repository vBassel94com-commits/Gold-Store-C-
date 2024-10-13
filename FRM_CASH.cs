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
    public partial class FRM_CASH : Form
    {
        CLS_CASH cash = new CLS_CASH();
        public FRM_CASH()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cash.cashSelect(dateTimePicker1.Value , dateTimePicker2.Value);
            dataGridView2.DataSource = cash.cashSum(dateTimePicker1.Value, dateTimePicker2.Value);
            dataGridView3.DataSource = cash.cashBalance (dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
