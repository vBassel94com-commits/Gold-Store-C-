using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLD1.DAL;

namespace gold1.BL
{
    class CLS_VALUE
    {
        CLS_DAL dal = new CLS_DAL();
        public void valuesAdd(Double value24 , Double value21 ,Double value18)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@value24", SqlDbType.Float);
            parameters[0].Value = value24;

            parameters[1] = new SqlParameter("@value21", SqlDbType.Float);
            parameters[1].Value = value21;

            parameters[2] = new SqlParameter("@value18", SqlDbType.Float);
            parameters[2].Value = value18;

            dal.ExecuteWithoutTable("valuesAdd", parameters);
        }

        
        
        public void valuesDelete()
        {
            

            dal.ExecuteWithoutTable("valuesDelete", null);
        }
        public DataTable valuesSelect()
        {
            return dal.ExecuteWithTable("valuesSelect", null);
        }
    }
}
