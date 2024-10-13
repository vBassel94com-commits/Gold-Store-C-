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
    public partial class FRM_DRAFT : Form
    {
        CLS_BILLITEMS bi = new CLS_BILLITEMS();
        public FRM_DRAFT()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            dataGridView2.DataSource = bi.draftwagesSelect(dateTimePicker1.Value , dateTimePicker2.Value);
            DataTable dt = bi.draftwagesSum(dateTimePicker1.Value, dateTimePicker2.Value);
            try
            {
                if (dt.Rows[0][0].ToString() != String.Empty)
                {
                    textBox3.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    textBox3.Text = "0";
                }
            }
            catch { MessageBox.Show("لا يوجد مدخلان خلال هذه المدة ");}
            DataTable dt1 = bi.exSum(dateTimePicker1.Value, dateTimePicker2.Value);
            try
            {
                if (dt1.Rows[0][0].ToString() != String.Empty)
                {
                    textBox1.Text = dt1.Rows[0][0].ToString();
                }
                else
                {
                    textBox1.Text = "0";
                }
            }
            catch { MessageBox.Show("لا يوجد مدخلان خلال هذه المدة "); }

            textBox2.Text = Math.Round((Convert.ToDouble(textBox3.Text) - Convert.ToDouble(textBox1.Text)), 2).ToString();
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
