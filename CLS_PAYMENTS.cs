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
    class CLS_PAYMENTS
    {
        CLS_DAL dal = new CLS_DAL();
        public void paymentAdd(Double recieve24 , Double delivery24 , Double recieve21, Double delivery21, Double recieve18, Double delivery18,Int32 jewelerID,DateTime date)
        {
            SqlParameter[] parameters = new SqlParameter[8];

            parameters[0] = new SqlParameter("@recieve24", SqlDbType.Float);
            parameters[0].Value = recieve24;

            parameters[1] = new SqlParameter("@delivery24", SqlDbType.Float);
            parameters[1].Value = delivery24;

            parameters[2] = new SqlParameter("@recieve21", SqlDbType.Float);
            parameters[2].Value = recieve21;

            parameters[3] = new SqlParameter("@delivery21", SqlDbType.Float);
            parameters[3].Value = delivery21;

            parameters[4] = new SqlParameter("@recieve18", SqlDbType.Float);
            parameters[4].Value = recieve18;

            parameters[5] = new SqlParameter("@delivery18", SqlDbType.Float);
            parameters[5].Value = delivery18;

            parameters[6] = new SqlParameter("@jewelerID", SqlDbType.Int);
            parameters[6].Value = jewelerID;

            parameters[7] = new SqlParameter("@date", SqlDbType.Date);
            parameters[7].Value = date;

            dal.ExecuteWithoutTable("paymentAdd", parameters);
        }

        public DataTable paymentSelect(Int32 jewelerID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@jewelerID", SqlDbType.Int);
            parameters[0].Value = jewelerID;

            return dal.ExecuteWithTable("paymentSelect", parameters);
        }

        public void paymentEdit( Int32 ID, Double recieve24, Double delivery24, Double recieve21, Double delivery21, Double recieve18, Double delivery18, Int32 jewelerID,DateTime date)
        {
            SqlParameter[] parameters = new SqlParameter[9];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            parameters[1] = new SqlParameter("@recieve24", SqlDbType.Float);
            parameters[1].Value = recieve24;

            parameters[2] = new SqlParameter("@delivery24", SqlDbType.Float);
            parameters[2].Value = delivery24;

            parameters[3] = new SqlParameter("@recieve21", SqlDbType.Float);
            parameters[3].Value = recieve21;

            parameters[4] = new SqlParameter("@delivery21", SqlDbType.Float);
            parameters[4].Value = delivery21;

            parameters[5] = new SqlParameter("@recieve18", SqlDbType.Float);
            parameters[5].Value = recieve18;

            parameters[6] = new SqlParameter("@delivery18", SqlDbType.Float);
            parameters[6].Value = delivery18;

            parameters[7] = new SqlParameter("@jewelerID", SqlDbType.Int);
            parameters[7].Value = jewelerID;

            parameters[8] = new SqlParameter("@date", SqlDbType.Date);
            parameters[8].Value = date;

            dal.ExecuteWithoutTable("paymentEdit", parameters);
        }

        public void paymentDelete(Int32 ID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            dal.ExecuteWithoutTable("paymentDelete", parameters);
        }
        public DataTable paymentSum(Int32 billID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[0].Value = billID;

            return dal.ExecuteWithTable("paymentSum", parameters);
        }

        public DataTable maxPayment()
        {
            return dal.ExecuteWithTable("maxPayment", null);
        }

        public DataTable paymentSelect1()
        {
            return dal.ExecuteWithTable("paymentSelect1", null);
        }
    }
}
