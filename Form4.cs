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
    public partial class Form4 : Form
    {
        CLS_VALUE v = new CLS_VALUE();
        
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            DataTable dt = v.valuesSelect();
            if(dt.Rows.Count == 0)
            {

            }
            else
            {
                textBox3.Text = dt.Rows[0][0].ToString();
                textBox4.Text = dt.Rows[0][1].ToString();
                textBox5.Text = dt.Rows[0][2].ToString();
            }
           
        }

        private void but_Click(object sender, EventArgs e)
        {
            v.valuesDelete();
            v.valuesAdd(Convert.ToSingle(textBox3.Text), Convert.ToSingle(textBox4.Text), Convert.ToSingle(textBox5.Text));
        }
    }
}
