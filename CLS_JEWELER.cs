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
    class CLS_JEWELER
    {
        CLS_DAL dal = new CLS_DAL();
        public void jewelerAdd(String jewelerName , String mobile)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@jewelerName", SqlDbType.NVarChar, 50);
            parameters[0].Value = jewelerName;

            parameters[1] = new SqlParameter("@mobile", SqlDbType.NVarChar, 50);
            parameters[1].Value = mobile;

            dal.ExecuteWithoutTable("jewelerAdd", parameters);
        }

        public DataTable jewelerSelect()
        {
            return dal.ExecuteWithTable("jewelerSelect", null);
        }
        public DataTable jewelerSelect1(Int32 ID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            return dal.ExecuteWithTable("jewelerSelect1", parameters);
        }

        public DataTable jewelerSelect2(String name)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@name", SqlDbType.NVarChar ,50);
            parameters[0].Value = name;

            return dal.ExecuteWithTable("jewelerSelect2", parameters);
        }

        public void jewelerEdit(Int32 ID, String jewelerName, String mobile)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            parameters[1] = new SqlParameter("@jewelerName", SqlDbType.NVarChar, 50);
            parameters[1].Value = jewelerName;

            parameters[2] = new SqlParameter("@mobile", SqlDbType.NVarChar, 50);
            parameters[2].Value = mobile;

            dal.ExecuteWithoutTable("jewelerEdit", parameters);
        }
        public void jewelerDelete(int ID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            dal.ExecuteWithoutTable("jewelerDelete", parameters);
        }

    }
}
