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
    class CLS_ITEM
    {

        CLS_DAL dal = new CLS_DAL();
        public void itemAdd(String name ,  String code, Byte[] barcode , float weight , Int32 karat , float draftwages, String type , Boolean status ,Int32 catID)
        {
            SqlParameter[] parameters = new SqlParameter[9];

            parameters[0] = new SqlParameter("@name", SqlDbType.NVarChar);
            parameters[0].Value = name;

            parameters[1] = new SqlParameter("@code", SqlDbType.NVarChar, 50);
            parameters[1].Value = code;

            parameters[2] = new SqlParameter("@barcode", SqlDbType.Image);
            parameters[2].Value = barcode;

            parameters[3] = new SqlParameter("@weight", SqlDbType.Float);
            parameters[3].Value = weight;

            parameters[4] = new SqlParameter("@karat", SqlDbType.Int);
            parameters[4].Value = karat;

            parameters[5] = new SqlParameter("@draftwages", SqlDbType.Float);
            parameters[5].Value = draftwages;

            parameters[6] = new SqlParameter("@type", SqlDbType.NVarChar,50);
            parameters[6].Value = type;

            parameters[7] = new SqlParameter("@status", SqlDbType.Bit);
            parameters[7].Value = status;

            parameters[8] = new SqlParameter("@catID", SqlDbType.Int);
            parameters[8].Value = catID;

            dal.ExecuteWithoutTable("itemAdd", parameters);
        }

        public void itemAdd1(String name, String code,  float weight, Int32 karat, float draftwages, String type, Boolean status , Int32 catID)
        {
            SqlParameter[] parameters = new SqlParameter[8];

            parameters[0] = new SqlParameter("@name", SqlDbType.NVarChar);
            parameters[0].Value = name;

            parameters[1] = new SqlParameter("@code", SqlDbType.NVarChar, 50);
            parameters[1].Value = code;

            parameters[2] = new SqlParameter("@weight", SqlDbType.Float);
            parameters[2].Value = weight;

            parameters[3] = new SqlParameter("@karat", SqlDbType.Int);
            parameters[3].Value = karat;

            parameters[4] = new SqlParameter("@draftwages", SqlDbType.Float);
            parameters[4].Value = draftwages;

            parameters[5] = new SqlParameter("@type", SqlDbType.NVarChar, 50);
            parameters[5].Value = type;

            parameters[6] = new SqlParameter("@status", SqlDbType.Bit);
            parameters[6].Value = status;

            parameters[7] = new SqlParameter("@catID", SqlDbType.Int);
            parameters[7].Value = catID;

            dal.ExecuteWithoutTable("itemAdd1", parameters);
        }


        public DataTable itemSelect()
        {
            return dal.ExecuteWithTable("itemSelect", null);
        }

        public DataTable itemSelect4()
        {
            return dal.ExecuteWithTable("itemSelect4", null);
        }

        public DataTable itemSelect1(String name)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@name", SqlDbType.NVarChar );
            parameters[0].Value = name;

            return dal.ExecuteWithTable("itemSelect1", parameters);
        }

        public DataTable itemSelect2(String code)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@code", SqlDbType.NVarChar,50);
            parameters[0].Value = code;

            return dal.ExecuteWithTable("itemSelect2", parameters);
        }

        public DataTable itemSelect3(String code)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@code", SqlDbType.NVarChar);
            parameters[0].Value = code;

            return dal.ExecuteWithTable("itemSelect3", parameters);
        }

        public DataTable itemSearch(String item)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@item", SqlDbType.NVarChar, 50);
            parameters[0].Value = item;

            return dal.ExecuteWithTable("itemSearch", parameters);
        }

        public DataTable itemSearch1(String item)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@item", SqlDbType.NVarChar, 50);
            parameters[0].Value = item;

            return dal.ExecuteWithTable("itemSearch1", parameters);
        }

        public DataTable jewelerSelect2(String name)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            parameters[0].Value = name;

            return dal.ExecuteWithTable("jewelerSelect2", parameters);
        }
        public DataTable statusItem(Int32 itemID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@itemID", SqlDbType.Int);
            parameters[0].Value = itemID;

            return dal.ExecuteWithTable("statusItem", parameters);
        }

        public DataTable statusItem1(Int32 itemID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@itemID", SqlDbType.Int);
            parameters[0].Value = itemID;

            return dal.ExecuteWithTable("statusItem1", parameters);
        }


        public void itemEdit(Int32 ID,String name , String code, Byte[] barcode, float weight, Int32 karat, float draftwages,String type, Boolean status)
        {
            SqlParameter[] parameters = new SqlParameter[9];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            parameters[1] = new SqlParameter("@name", SqlDbType.NVarChar);
            parameters[1].Value = name;

            parameters[2] = new SqlParameter("@code", SqlDbType.NVarChar, 50);
            parameters[2].Value = code;

            parameters[3] = new SqlParameter("@barcode", SqlDbType.Image);
            parameters[3].Value = barcode;

            parameters[4] = new SqlParameter("@weight", SqlDbType.Float);
            parameters[4].Value = weight;

            parameters[5] = new SqlParameter("@karat", SqlDbType.Int);
            parameters[5].Value = karat;

            parameters[6] = new SqlParameter("@draftwages", SqlDbType.Float);
            parameters[6].Value = draftwages;

            parameters[7] = new SqlParameter("@type", SqlDbType.NVarChar,50);
            parameters[7].Value = type;

            parameters[8] = new SqlParameter("@status", SqlDbType.Bit);
            parameters[8].Value = status;

            dal.ExecuteWithoutTable("itemEdit", parameters);
        }

        public void itemEdit1(Int32 ID, Double weight)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            parameters[1] = new SqlParameter("@weight", SqlDbType.Float);
            parameters[1].Value = weight;


            dal.ExecuteWithoutTable("itemEdit1", parameters);
        }
        public void itemDelete(int ID)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[0].Value = ID;

            dal.ExecuteWithoutTable("itemDelete", parameters);
        }
        public DataTable storeSearch(String name)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@name", SqlDbType.NVarChar,50);
            parameters[0].Value = name;

            return dal.ExecuteWithTable("storeSearch", parameters);
        }

        public DataTable itemSelect5(String category)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@category", SqlDbType.NVarChar, 50);
            parameters[0].Value = category;

            return dal.ExecuteWithTable("itemSelect5", parameters);
        }

    }
}
