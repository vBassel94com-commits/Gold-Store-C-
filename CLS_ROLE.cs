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
    class CLS_ROLE
    {

        CLS_DAL dal = new CLS_DAL();
        public void roleAdd(String username, String password)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@username", SqlDbType.NVarChar, 50);
            parameters[0].Value = username;

            parameters[1] = new SqlParameter("@password", SqlDbType.NVarChar, 50);
            parameters[1].Value = password;

            dal.ExecuteWithoutTable("roleAdd", parameters);
        }

        public void roleEdit(Int32 ID, String username, String password)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            parameters[1] = new SqlParameter("@username", SqlDbType.NVarChar, 50);
            parameters[1].Value = username;

            parameters[2] = new SqlParameter("@password", SqlDbType.NVarChar, 50);
            parameters[2].Value = password;

            dal.ExecuteWithoutTable("roleEdit", parameters);
        }
        public void roleDelete(int ID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            dal.ExecuteWithoutTable("roleDelete", parameters);
        }
        public DataTable roleSelect()
        {
            return dal.ExecuteWithTable("roleSelect", null);
        }

        public DataTable passwordSelect(String username)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@username", SqlDbType.NVarChar , 50);
            parameters[0].Value = username;

            return dal.ExecuteWithTable("passwordSelect", parameters);
        }

    }
}
