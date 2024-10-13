using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using GOLD1.DAL;

namespace Gold1.BL
{
    class CLS_CUSTOMERACCOUNT
    {
        CLS_DAL dal = new CLS_DAL();
        public void customeraccountAdd(DateTime date, Double tousmoney, Double toyoumoney, Double tous21, Double toyou21,  String note, Int32 jewelerID , Int32 billID)
        {
            SqlParameter[] parameters = new SqlParameter[8];

            parameters[0] = new SqlParameter("@date", SqlDbType.Date);
            parameters[0].Value = date;

            parameters[1] = new SqlParameter("@tousmoney", SqlDbType.Float);
            parameters[1].Value = tousmoney;

            parameters[2] = new SqlParameter("@toyoumoney", SqlDbType.Float);
            parameters[2].Value = toyoumoney;

            parameters[3] = new SqlParameter("@tous21", SqlDbType.Float);
            parameters[3].Value = tous21;

            parameters[4] = new SqlParameter("@toyou21", SqlDbType.Float);
            parameters[4].Value = toyou21;

            parameters[5] = new SqlParameter("@note", SqlDbType.NVarChar);
            parameters[5].Value = note;

            parameters[6] = new SqlParameter("@jewelerID", SqlDbType.Int);
            parameters[6].Value = jewelerID;

            parameters[7] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[7].Value = billID;

            dal.ExecuteWithoutTable("customeraccountAdd", parameters);
        }

        public void customeraccountEdit(Int32 ID, DateTime date, Double tousmoney, Double toyoumoney, Double tous21, Double toyou21, String note, Int32 jewelerID,Int32 billID)
        {
            SqlParameter[] parameters = new SqlParameter[9];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            parameters[1] = new SqlParameter("@date", SqlDbType.Date);
            parameters[1].Value = date;

            parameters[2] = new SqlParameter("@tousmoney", SqlDbType.Float);
            parameters[2].Value = tousmoney;

            parameters[3] = new SqlParameter("@toyoumoney", SqlDbType.Float);
            parameters[3].Value = toyoumoney;

            parameters[4] = new SqlParameter("@tous21", SqlDbType.Float);
            parameters[4].Value = tous21;

            parameters[5] = new SqlParameter("@toyou21", SqlDbType.Float);
            parameters[5].Value = toyou21;

            parameters[6] = new SqlParameter("@note", SqlDbType.NVarChar);
            parameters[6].Value = note;

            parameters[7] = new SqlParameter("@jewelerID", SqlDbType.Int);
            parameters[7].Value = jewelerID;

            parameters[8] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[8].Value = billID;

            dal.ExecuteWithoutTable("customeraccountEdit", parameters);
        }

        public void customeraccountEdit1(DateTime date, Double tousmoney, Double toyoumoney, Double tous21, Double toyou21, String note, Int32 jewelerID, Int32 billID)
        {
            SqlParameter[] parameters = new SqlParameter[8];

            parameters[0] = new SqlParameter("@date", SqlDbType.Date);
            parameters[0].Value = date;

            parameters[1] = new SqlParameter("@tousmoney", SqlDbType.Float);
            parameters[1].Value = tousmoney;

            parameters[2] = new SqlParameter("@toyoumoney", SqlDbType.Float);
            parameters[2].Value = toyoumoney;

            parameters[3] = new SqlParameter("@tous21", SqlDbType.Float);
            parameters[3].Value = tous21;

            parameters[4] = new SqlParameter("@toyou21", SqlDbType.Float);
            parameters[4].Value = toyou21;

            parameters[5] = new SqlParameter("@note", SqlDbType.NVarChar);
            parameters[5].Value = note;

            parameters[6] = new SqlParameter("@jewelerID", SqlDbType.Int);
            parameters[6].Value = jewelerID;

            parameters[7] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[7].Value = billID;

            dal.ExecuteWithoutTable("customeraccountEdit1", parameters);
        }
        public void customeraccountDelete(Int32 billID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[0].Value = billID;

            dal.ExecuteWithoutTable("customeraccountDelete", parameters);
        }

        public void customeraccountDelete1(Int32 billID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[0].Value = billID;

            dal.ExecuteWithoutTable("customeraccountDelete1", parameters);
        }

        public DataTable customeraccountSelect(DateTime date1 , DateTime date2 , Int32 jewelerID)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@date1", SqlDbType.Date);
            parameters[0].Value = date1;

            parameters[1] = new SqlParameter("@date2", SqlDbType.Date);
            parameters[1].Value = date2;

            parameters[2] = new SqlParameter("@jewelerID", SqlDbType.Int);
            parameters[2].Value = jewelerID;

            return dal.ExecuteWithTable("customeraccountSelect", parameters);
        }

        public DataTable customeraccountSum(DateTime date1, DateTime date2, Int32 jewelerID)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@date1", SqlDbType.Date);
            parameters[0].Value = date1;

            parameters[1] = new SqlParameter("@date2", SqlDbType.Date);
            parameters[1].Value = date2;

            parameters[2] = new SqlParameter("@jewelerID", SqlDbType.Int);
            parameters[2].Value = jewelerID;

            return dal.ExecuteWithTable("customeraccountSum", parameters);
        }

        public DataTable customeraccountBalance(DateTime date1, DateTime date2, Int32 jewelerID)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@date1", SqlDbType.Date);
            parameters[0].Value = date1;

            parameters[1] = new SqlParameter("@date2", SqlDbType.Date);
            parameters[1].Value = date2;

            parameters[2] = new SqlParameter("@jewelerID", SqlDbType.Int);
            parameters[2].Value = jewelerID;

            return dal.ExecuteWithTable("customeraccountBalance", parameters);
        }

    }
}
