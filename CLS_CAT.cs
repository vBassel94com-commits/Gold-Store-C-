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
    class CLS_CAT
    {
        CLS_DAL dal = new CLS_DAL();
        public void catAdd(String category, Double draft)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@category", SqlDbType.NVarChar, 50);
            parameters[0].Value = category;

            parameters[1] = new SqlParameter("@draft", SqlDbType.Float);
            parameters[1].Value = draft;

            dal.ExecuteWithoutTable("catAdd", parameters);
        }

        public void catEdit(Int32 ID, String category, Double draft)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            parameters[1] = new SqlParameter("@category", SqlDbType.NVarChar, 50);
            parameters[1].Value = category;

            parameters[2] = new SqlParameter("@draft", SqlDbType.Float);
            parameters[2].Value = draft;

            dal.ExecuteWithoutTable("catEdit", parameters);
        }
        public void catDelete(int ID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            dal.ExecuteWithoutTable("catDelete", parameters);
        }
        public DataTable catSelect()
        {
            return dal.ExecuteWithTable("catSelect", null);
        }
        public DataTable catSelect1()
        {
            return dal.ExecuteWithTable("catSelect1", null);
        }
        public DataTable catSelect2(Int32 ID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            return dal.ExecuteWithTable("catSelect2", parameters);
        }

        public DataTable catSelect3(String category)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@category", SqlDbType.NVarChar ,50);
            parameters[0].Value = category;

            return dal.ExecuteWithTable("catSelect3", parameters);
        }

        public DataTable idcategory(String category)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@category", SqlDbType.NVarChar, 50);
            parameters[0].Value = category;

            return dal.ExecuteWithTable("idcategory", parameters);
        }
    }
}
