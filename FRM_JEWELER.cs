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

namespace Gold.PL
{
    public partial class FRM_JEWELER : Form
    {
        CLS_JEWELER j = new CLS_JEWELER();
        Int32 jewelerID;
        public FRM_JEWELER()
        {
            InitializeComponent();
        }

        private void FRM_JEWELER_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != String.Empty)
            {
                j.jewelerAdd(textBox2.Text, textBox3.Text);
               // MessageBox.Show("تم اضافة صائغ جديد بنجاح");
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                this.Close();
            }
            else
            {
                MessageBox.Show("المعلومات المدخلة ليست كافية");
            }
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DataTable dt = j.jewelerSelect1(Convert.ToInt32(textBox1.Text));
                if(dt.Rows.Count > 0)
                {
                    textBox2.Text = dt.Rows[0][1].ToString();
                    textBox3.Text = dt.Rows[0][2].ToString();
                }
                else
                {
                    MessageBox.Show("لايوجد صائع بهذا الرقم");
                }
             
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataTable dt = j.jewelerSelect2(textBox2.Text);
                    textBox1.Text = dt.Rows[0][0].ToString();
                    textBox3.Text = dt.Rows[0][2].ToString();
                }
                catch
                {
                    textBox3.Focus();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != String.Empty && textBox2.Text != String.Empty)
            {
                j.jewelerEdit(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text);
                MessageBox.Show("تم تعديل معلومات الصائغ بنجاح");
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("المعلومات المدخلة ليست كافية");
            }
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != String.Empty)
            {
                j.jewelerDelete(Convert.ToInt32(textBox1.Text));
                MessageBox.Show("تم حذف الصائغ بنجاح");
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("أدخل رقم الصائغ");
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }

        }
    }
}
