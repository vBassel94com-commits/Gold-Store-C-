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
    class CLS_BILL
    {
        CLS_DAL dal = new CLS_DAL();
        public void billAdd(String buyorpur, DateTime date, Int32 jewelerID, float goldprice, Double total, Double discount, Double totalafterdiscount)
        {
            SqlParameter[] parameters = new SqlParameter[7];

            parameters[0] = new SqlParameter("@buyorpur", SqlDbType.NVarChar, 50);
            parameters[0].Value = buyorpur;

            parameters[1] = new SqlParameter("@date", SqlDbType.Date);
            parameters[1].Value = date;

            parameters[2] = new SqlParameter("@jewelerID", SqlDbType.Int);
            parameters[2].Value = jewelerID;

            parameters[3] = new SqlParameter("@goldprice", SqlDbType.Float);
            parameters[3].Value = goldprice;

            parameters[4] = new SqlParameter("@total", SqlDbType.Float);
            parameters[4].Value = total;

            parameters[5] = new SqlParameter("@discount", SqlDbType.Float);
            parameters[5].Value = discount;

            parameters[6] = new SqlParameter("@totalafterdiscount", SqlDbType.Float);
            parameters[6].Value = totalafterdiscount;

            dal.ExecuteWithoutTable("billAdd", parameters);
        }

        public void billAdd1(String buyorpur, DateTime date)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@buyorpur", SqlDbType.NVarChar, 50);
            parameters[0].Value = buyorpur;

            parameters[1] = new SqlParameter("@date", SqlDbType.Date);
            parameters[1].Value = date;

            dal.ExecuteWithoutTable("billAdd1", parameters);
        }

        public DataTable billSelect(Int32 ID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            return dal.ExecuteWithTable("billSelect", parameters);
        }


        public DataTable billSelect1(String buyorpur)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@buyorpur", SqlDbType.NVarChar, 50);
            parameters[0].Value = buyorpur;

            return dal.ExecuteWithTable("billSelect1", parameters);
        }

        public DataTable billSelect2(Int32 ID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            return dal.ExecuteWithTable("billSelect2", parameters);
        }

        public DataTable sumbill(Int32 billID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[0].Value = billID;

            return dal.ExecuteWithTable("sumbill", parameters);
        }
        public DataTable sumbill1(Int32 billID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[0].Value = billID;

            return dal.ExecuteWithTable("sumbill1", parameters);
        }
        public void billEdit(Int32 ID, String buyorpur, DateTime date, Int32 jewelerID, float goldprice, Double total, Double discount, Double totalafterdiscount)
        {
            SqlParameter[] parameters = new SqlParameter[8];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            parameters[1] = new SqlParameter("@buyorpur", SqlDbType.NVarChar, 50);
            parameters[1].Value = buyorpur;

            parameters[2] = new SqlParameter("@date", SqlDbType.Date);
            parameters[2].Value = date;

            parameters[3] = new SqlParameter("@jewelerID", SqlDbType.Int);
            parameters[3].Value = jewelerID;

            parameters[4] = new SqlParameter("@goldprice", SqlDbType.Float);
            parameters[4].Value = goldprice;

            parameters[5] = new SqlParameter("@total", SqlDbType.Float);
            parameters[5].Value = total;

            parameters[6] = new SqlParameter("@discount", SqlDbType.Float);
            parameters[6].Value = discount;

            parameters[7] = new SqlParameter("@totalafterdiscount", SqlDbType.Float);
            parameters[7].Value = totalafterdiscount;

            dal.ExecuteWithoutTable("billEdit", parameters);
        }
        public void billDelete(Int32 ID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            dal.ExecuteWithoutTable("billDelete", parameters);
        }

        public DataTable balanceSelect(Int32 ID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            return dal.ExecuteWithTable("balanceSelect", parameters);
        }
    }
}

