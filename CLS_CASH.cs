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
    class CLS_CASH
    {

        CLS_DAL dal = new CLS_DAL();
        public void cashAdd(DateTime date, Double inputmoney, Double outputmoney, Double input24, Double output24, Double input21, Double output21, Double input18, Double output18, Int32 billID,Int32 jewelerID , String note)
        {
            SqlParameter[] parameters = new SqlParameter[12];

            parameters[0] = new SqlParameter("@date", SqlDbType.Date);
            parameters[0].Value = date;

            parameters[1] = new SqlParameter("@inputmoney", SqlDbType.Float);
            parameters[1].Value = inputmoney;

            parameters[2] = new SqlParameter("@outputmoney", SqlDbType.Float);
            parameters[2].Value = outputmoney;

            parameters[3] = new SqlParameter("@input24", SqlDbType.Float);
            parameters[3].Value = input24;

            parameters[4] = new SqlParameter("@output24", SqlDbType.Float);
            parameters[4].Value = output24;

            parameters[5] = new SqlParameter("@input21", SqlDbType.Float);
            parameters[5].Value = input21;

            parameters[6] = new SqlParameter("@output21", SqlDbType.Float);
            parameters[6].Value = output21;

            parameters[7] = new SqlParameter("@input18", SqlDbType.Float);
            parameters[7].Value = input18;

            parameters[8] = new SqlParameter("@output18", SqlDbType.Float);
            parameters[8].Value = output18;

            parameters[9] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[9].Value = billID;

            parameters[10] = new SqlParameter("@jewelerID", SqlDbType.Int);
            parameters[10].Value = jewelerID;

            parameters[11] = new SqlParameter("@note", SqlDbType.NVarChar);
            parameters[11].Value = note;

            dal.ExecuteWithoutTable("cashAdd", parameters);
        }

        public void cashEdit(Int32 ID, DateTime date, Double inputmoney, Double outputmoney, Double input24, Double output24, Double input21, Double output21, Double input18, Double output18, Int32 billID,Int32 jewelerID, Int32 note)
        {
            SqlParameter[] parameters = new SqlParameter[13];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            parameters[1] = new SqlParameter("@date", SqlDbType.Date);
            parameters[1].Value = date;

            parameters[2] = new SqlParameter("@inputmoney", SqlDbType.Float);
            parameters[2].Value = inputmoney;

            parameters[3] = new SqlParameter("@outputmoney", SqlDbType.Float);
            parameters[3].Value = outputmoney;

            parameters[4] = new SqlParameter("@input24", SqlDbType.Float);
            parameters[4].Value = input24;

            parameters[5] = new SqlParameter("@output24", SqlDbType.Float);
            parameters[5].Value = output24;

            parameters[6] = new SqlParameter("@input21", SqlDbType.Float);
            parameters[6].Value = input21;

            parameters[7] = new SqlParameter("@output21", SqlDbType.Float);
            parameters[7].Value = output21;

            parameters[8] = new SqlParameter("@input18", SqlDbType.Float);
            parameters[8].Value = input18;

            parameters[9] = new SqlParameter("@output18", SqlDbType.Float);
            parameters[9].Value = output18;

            parameters[10] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[10].Value = billID;

            parameters[11] = new SqlParameter("@jewelerID", SqlDbType.Int);
            parameters[11].Value = jewelerID;

            parameters[12] = new SqlParameter("@note", SqlDbType.NVarChar);
            parameters[12].Value = note;

            dal.ExecuteWithoutTable("cashEdit", parameters);
        }

        public void cashEdit1( DateTime date, Double inputmoney, Double outputmoney, Double input24, Double output24, Double input21, Double output21, Double input18, Double output18, Int32 billID, Int32 jewelerID, String note)
        {
            SqlParameter[] parameters = new SqlParameter[12];

            parameters[0] = new SqlParameter("@date", SqlDbType.Date);
            parameters[0].Value = date;

            parameters[1] = new SqlParameter("@inputmoney", SqlDbType.Float);
            parameters[1].Value = inputmoney;

            parameters[2] = new SqlParameter("@outputmoney", SqlDbType.Float);
            parameters[2].Value = outputmoney;

            parameters[3] = new SqlParameter("@input24", SqlDbType.Float);
            parameters[3].Value = input24;

            parameters[4] = new SqlParameter("@output24", SqlDbType.Float);
            parameters[4].Value = output24;

            parameters[5] = new SqlParameter("@input21", SqlDbType.Float);
            parameters[5].Value = input21;

            parameters[6] = new SqlParameter("@output21", SqlDbType.Float);
            parameters[6].Value = output21;

            parameters[7] = new SqlParameter("@input18", SqlDbType.Float);
            parameters[7].Value = input18;

            parameters[8] = new SqlParameter("@output18", SqlDbType.Float);
            parameters[8].Value = output18;

            parameters[9] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[9].Value = billID;

            parameters[10] = new SqlParameter("@jewelerID", SqlDbType.Int);
            parameters[10].Value = jewelerID;

            parameters[11] = new SqlParameter("@note", SqlDbType.NVarChar);
            parameters[11].Value = note;

            dal.ExecuteWithoutTable("cashEdit1", parameters);
        }

        public void cashDelete(Int32 billID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[0].Value = billID;

            dal.ExecuteWithoutTable("cashDelete", parameters);
        }

        public DataTable cashSelect(DateTime date1, DateTime date2)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@date1", SqlDbType.Date);
            parameters[0].Value = date1;

            parameters[1] = new SqlParameter("@date2", SqlDbType.Date);
            parameters[1].Value = date2;

           

            return dal.ExecuteWithTable("cashSelect", parameters);
        }

        public DataTable cashSum(DateTime date1, DateTime date2)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@date1", SqlDbType.Date);
            parameters[0].Value = date1;

            parameters[1] = new SqlParameter("@date2", SqlDbType.Date);
            parameters[1].Value = date2;

            return dal.ExecuteWithTable("cashSum", parameters);
        }

        public DataTable cashBalance(DateTime date1, DateTime date2)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@date1", SqlDbType.Date);
            parameters[0].Value = date1;

            parameters[1] = new SqlParameter("@date2", SqlDbType.Date);
            parameters[1].Value = date2;

            return dal.ExecuteWithTable("cashBalance", parameters);
        }
    }
}
