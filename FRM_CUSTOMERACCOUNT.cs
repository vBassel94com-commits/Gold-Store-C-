using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gold1.PL;
using Gold1.BL;

namespace Gold.PL
{
    public partial class FRM_CUSTOMERACCOUNT : Form
    {
        CLS_CUSTOMERACCOUNT ca = new CLS_CUSTOMERACCOUNT();
        CLS_JEWELER j = new CLS_JEWELER();
        public FRM_CUSTOMERACCOUNT()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable dt = j.jewelerSelect2(textBox2.Text);
            Int32 jewelerID = Convert.ToInt32(dt.Rows[0][0].ToString());
            dataGridView1.DataSource = ca.customeraccountSelect(dateTimePicker1.Value, dateTimePicker2.Value, jewelerID);
            dataGridView2.DataSource = ca.customeraccountSum(dateTimePicker1.Value, dateTimePicker2.Value, jewelerID);
            dataGridView3.DataSource = ca.customeraccountBalance(dateTimePicker1.Value, dateTimePicker2.Value, jewelerID);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FRM_CUSTOMERACCOUNT_Load(object sender, EventArgs e)
        {
            DataTable dtt = j.jewelerSelect();
            AutoCompleteStringCollection datasource1 = new AutoCompleteStringCollection();
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                datasource1.Add(dtt.Rows[i][1].ToString());
            }
            this.textBox2.AutoCompleteCustomSource = datasource1;
            this.textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
               
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        //    MessageBox.Show(dataGridView1.CurrentRow.Cells[6].Value.ToString());
          int a=  Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value.ToString());

            FRM_BILL fr = new FRM_BILL(a);
            fr.ShowDialog();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = j.jewelerSelect2(textBox2.Text);
            Int32 jewelerID = Convert.ToInt32(dt.Rows[0][0].ToString());
            Form3 f = new Form3(dateTimePicker1.Value, dateTimePicker2.Value, jewelerID);
            f.ShowDialog();
        }
    }
}
