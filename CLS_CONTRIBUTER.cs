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
    class CLS_CONTRIBUTER
    {
        CLS_DAL dal = new CLS_DAL();
        public void conAdd(String contributer , Double value)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@contributer", SqlDbType.NVarChar);
            parameters[0].Value = contributer;

            parameters[1] = new SqlParameter("@value", SqlDbType.Float);
            parameters[1].Value = value;

            dal.ExecuteWithoutTable("conAdd", parameters);
        }

        public DataTable conSelect1(String contributer)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@contributer", SqlDbType.NVarChar);
            parameters[0].Value = contributer;

            return dal.ExecuteWithTable("conSelect1", parameters);
        }

        public void conEdit(Int32 ID, String contributer, Double value)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            parameters[1] = new SqlParameter("@contributer", SqlDbType.NVarChar);
            parameters[1].Value = contributer;

            parameters[2] = new SqlParameter("@value", SqlDbType.Float);
            parameters[2].Value = value;

            dal.ExecuteWithoutTable("conEdit", parameters);
        }

        public void conDelete(Int32 ID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            dal.ExecuteWithoutTable("conDelete", parameters);
        }
        

        public DataTable conSum()
        {
            return dal.ExecuteWithTable("conSum", null);
        }

        public DataTable conSelect()
        {
            return dal.ExecuteWithTable("conSelect", null);
        }
    }
}
