using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using gold1.PL;
using System.Data.SqlClient;

namespace gold1.PL
{
    public partial class FRM_PRINT1 : Form
    {
        String code;
        SqlConnection co = new SqlConnection();
        public FRM_PRINT1(String code )
        {
            InitializeComponent();
            this.code = code;
        }

        private void FRM_PRINT1_Load(object sender, EventArgs e)
        {
           // String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Yakdi\gold\gold.mdf;Integrated Security=True;database=gold";
            //co.ConnectionString = connectionString;

            co.ConnectionString = @"Data Source =DESKTOP-MVUCDUI\SQLEXPRESS; Initial Catalog = gold; User ID=sa; password=12345678";

            String sq = "select * from items where code ='" + code + "'";
            DataSet22 ds = new DataSet22();
            SqlDataAdapter dad = new SqlDataAdapter(sq, co);
            dad.Fill(ds.Tables["items"]);
            CrystalReport1 em = new CrystalReport1();
            em.SetDataSource(ds.Tables["items"]);
            crystalReportViewer1.ReportSource = em;
            crystalReportViewer1.Refresh();



        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
