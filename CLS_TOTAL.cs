using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using GOLD1.DAL;

namespace gold1.BL
{
    class CLS_TOTAL
    {

        CLS_DAL dal = new CLS_DAL();
        public void totalAdd(Double sumgold, Double sumdraft , Int32 billID)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@sumgold", SqlDbType.Float);
            parameters[0].Value = sumgold;

            parameters[1] = new SqlParameter("@sumdraft", SqlDbType.Float);
            parameters[1].Value = sumdraft;

            parameters[2] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[2].Value = billID;


            dal.ExecuteWithoutTable("totalAdd", parameters);
        }

        public void totalDelete(Int32 billID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[0].Value = billID;

            dal.ExecuteWithoutTable("totalDelete", parameters);
        }
        public DataTable totalSelect(Int32 billID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@billID", SqlDbType.Int);
            parameters[0].Value = billID;

            return dal.ExecuteWithTable("totalSelect", parameters);
        }

    }
}
