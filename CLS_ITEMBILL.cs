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
    class CLS_ITEMBILL
    {

        CLS_DAL dal = new CLS_DAL();

        public void billitemsDelete(int billID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[0].Value = billID;

            dal.ExecuteWithoutTable("billitemsDelete", parameters);
        }

        public void billitemsAdd(Int32 itemID, Int32 billID,Double actvalue , Double value, Double valuebeforechange , String statementchange , Double valueafterchange)
        {
            SqlParameter[] parameters = new SqlParameter[7];

            parameters[0] = new SqlParameter("@itemID", SqlDbType.Int);
            parameters[0].Value = itemID;

            parameters[1] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[1].Value = billID;

            parameters[2] = new SqlParameter("@actvalue", SqlDbType.Float);
            parameters[2].Value = actvalue;

            parameters[3] = new SqlParameter("@value", SqlDbType.Float);
            parameters[3].Value = value;

            parameters[4] = new SqlParameter("@valuebeforechange", SqlDbType.Float);
            parameters[4].Value = valuebeforechange;

            parameters[5] = new SqlParameter("@statementchange", SqlDbType.NVarChar);
            parameters[5].Value = statementchange;

            parameters[6] = new SqlParameter("@valueafterchange", SqlDbType.Float);
            parameters[6].Value = valueafterchange;

            dal.ExecuteWithoutTable("billitemsAdd", parameters);
        }

        public DataTable billitemsSelect(Int32 billID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[0].Value = billID;

            return dal.ExecuteWithTable("billitemsSelect", parameters);
        }

        public DataTable itemidSelect(Int32 billID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[0].Value = billID;

            return dal.ExecuteWithTable("itemidSelect", parameters);
        }
    }
}
