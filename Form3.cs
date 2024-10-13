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

namespace gold1.PL
{
    public partial class Form3 : Form
    {
        DateTime date1;
        DateTime date2;
        Int32 jewelerID;
        public Form3(DateTime date1 , DateTime date2 ,Int32 jewelerID)
        {
            InitializeComponent();
            this.date1 = date1;
            this.date2 = date2;
            this.jewelerID = jewelerID;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = @"Data Source = DESKTOP-R8D391E; Initial Catalog = gold; User ID = sa; password = 12345678";
            String sq = "select tousmoney ,toyoumoney,tous21, toyou21, note ,jewelerName  , billID from customeraccount inner join jeweler on customeraccount.jewelerID = jeweler.ID WHERE customeraccount.date between'" + date1 + "'and '" + date2 + "'and jeweler.ID = " + jewelerID;
            DataSet6 ds = new DataSet6();
            SqlDataAdapter dad = new SqlDataAdapter(sq, co);
            dad.Fill(ds.Tables["DataTable1"]);
            CrystalReport6 em1 = new CrystalReport6();
            em1.SetDataSource(ds.Tables["DataTable1"]);
            crystalReportViewer1.ReportSource = em1;
            crystalReportViewer1.Refresh();
        }
    }
}
