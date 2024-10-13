using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using gold1;

namespace Gold.PL
{
    public partial class FRM_PRINT : Form
    {
        Int32 billID;
        CrystalReport3 em;

        SqlConnection co = new SqlConnection();
        public FRM_PRINT(CrystalReport3 em)
        {
            InitializeComponent();
            this.em = em;
           
        }


        private void FRM_PRINT_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = em;
            crystalReportViewer1.Refresh();
           
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
