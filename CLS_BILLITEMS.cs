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
    class CLS_BILLITEMS
    {

        CLS_DAL dal = new CLS_DAL();
        public void billitemsAdd(Int32 itemID , Int32 billID ,float actvalue ,  Int32 count , float value ,float valuebeforechange ,String statementchange , float valueafterchange)
        {
            SqlParameter[] parameters = new SqlParameter[8];

            parameters[0] = new SqlParameter("@itemID", SqlDbType.Int);
            parameters[0].Value = itemID;

            parameters[1] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[1].Value = billID;

            parameters[2] = new SqlParameter("@actvalue", SqlDbType.Float);
            parameters[2].Value = actvalue;

            parameters[3] = new SqlParameter("@count", SqlDbType.Int);
            parameters[3].Value = count;

            parameters[4] = new SqlParameter("@value", SqlDbType.Float);
            parameters[4].Value = value;

            parameters[5] = new SqlParameter("@valuebeforechange", SqlDbType.Float);
            parameters[5].Value = valuebeforechange;

            parameters[6] = new SqlParameter("@statementchange", SqlDbType.NVarChar);
            parameters[6].Value = statementchange;

            parameters[7] = new SqlParameter("@totalafterdiscount", SqlDbType.Float);
            parameters[7].Value = valueafterchange;

           

            dal.ExecuteWithoutTable("billitemsAdd", parameters);
        }

        
        public DataTable billitemsSelect(Int32 billID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[0].Value = billID;

            return dal.ExecuteWithTable("billitemsSelect", parameters);
        }

        public DataTable jewelerSelect2(String name)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            parameters[0].Value = name;

            return dal.ExecuteWithTable("jewelerSelect2", parameters);
        }

        //public void billEdit(Int32 ID, String buyorpur, DateTime date, Int32 jewelerID, float goldprice, float total, float discount, float totalafterdiscount, String type, float paymentvalue, float resttopay)
        //{
        //    SqlParameter[] parameters = new SqlParameter[11];

        //    parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
        //    parameters[0].Value = ID;

        //    parameters[1] = new SqlParameter("@buyorpur", SqlDbType.NVarChar, 50);
        //    parameters[1].Value = buyorpur;

        //    parameters[2] = new SqlParameter("@date", SqlDbType.Date);
        //    parameters[2].Value = date;

        //    parameters[3] = new SqlParameter("@jewelerID", SqlDbType.Int);
        //    parameters[3].Value = jewelerID;

        //    parameters[4] = new SqlParameter("@goldprice", SqlDbType.Float);
        //    parameters[4].Value = goldprice;

        //    parameters[5] = new SqlParameter("@total", SqlDbType.Float);
        //    parameters[5].Value = total;

        //    parameters[6] = new SqlParameter("@discount", SqlDbType.Float);
        //    parameters[6].Value = discount;

        //    parameters[7] = new SqlParameter("@totalafterdiscount", SqlDbType.Float);
        //    parameters[7].Value = totalafterdiscount;

        //    parameters[8] = new SqlParameter("@type", SqlDbType.Float);
        //    parameters[8].Value = type;

        //    parameters[9] = new SqlParameter("@paymentvalue", SqlDbType.Float);
        //    parameters[9].Value = paymentvalue;

        //    parameters[10] = new SqlParameter("@resttopay", SqlDbType.Float);
        //    parameters[10].Value = resttopay;

        //    dal.ExecuteWithoutTable("billEdit", parameters);
        //}
        public void billitemsDelete(Int32 billID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[0].Value = billID;

            dal.ExecuteWithoutTable("billitemsDelete", parameters);
        }
        public DataTable draftwagesSelect(DateTime date1,DateTime date2)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@date1", SqlDbType.Date);
            parameters[0].Value = date1;

            parameters[1] = new SqlParameter("@date2", SqlDbType.Date);
            parameters[1].Value = date2;

            return dal.ExecuteWithTable("draftwagesSelect", parameters);
        }

        public DataTable draftwagesSum(DateTime date1, DateTime date2)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@date1", SqlDbType.Date);
            parameters[0].Value = date1;

            parameters[1] = new SqlParameter("@date2", SqlDbType.Date);
            parameters[1].Value = date2;

            return dal.ExecuteWithTable("draftwagesSum", parameters);
        }

        public void exAdd(String name , Double value , Int32 goldprice , Double valuegold , DateTime date)
        {
            SqlParameter[] parameters = new SqlParameter[5];

            parameters[0] = new SqlParameter("@name", SqlDbType.NVarChar ,50);
            parameters[0].Value = name;

            parameters[1] = new SqlParameter("@value", SqlDbType.Float);
            parameters[1].Value = value;

            parameters[2] = new SqlParameter("@goldprice", SqlDbType.Int);
            parameters[2].Value = goldprice;

            parameters[3] = new SqlParameter("@valuegold", SqlDbType.Float);
            parameters[3].Value = valuegold;

            parameters[4] = new SqlParameter("@date", SqlDbType.Date);
            parameters[4].Value = date;


            dal.ExecuteWithoutTable("exAdd", parameters);
        }
        public DataTable exSelect()
        {
            return dal.ExecuteWithTable("exSelect", null);
        }

        public DataTable exSum(DateTime date1, DateTime date2)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@date1", SqlDbType.Date);
            parameters[0].Value = date1;

            parameters[1] = new SqlParameter("@date2", SqlDbType.Date);
            parameters[1].Value = date2;

            return dal.ExecuteWithTable("exSum", parameters);
        }
    }
}
