using System;
using System.Data;
using System.Data.SqlClient;
namespace GOLD1.DAL
{
    class CLS_DAL
    {
       // private String connectionString = @"Data Source=FLAMINGO\SQLEXPRESS;AttachDbFilename=D:\Yakdi\gold\gold.mdf;Integrated Security=True;User ID=sa; password=12345678;database=gold";
         private String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Yakdi\gold\gold.mdf;Integrated Security=True;database=gold";
        // private String connectionString = @"Data Source =DESKTOP-R8D391E; Initial Catalog = gold; User ID=sa; password=12345678";
        // private String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Yakdi\gold\gold.mdf;Integrated Security=True;database=gold";

        private SqlConnection sqlConnection;
        private SqlDataAdapter sqlDataAdapter;

        public CLS_DAL()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlDataAdapter = new SqlDataAdapter();
        }

        public DataTable ExecuteWithTable(String procedureName, SqlParameter[] parameter)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = procedureName;
            sqlCommand.Connection = sqlConnection;
            if (parameter != null)
            {
                sqlCommand.Parameters.AddRange(parameter);
            }
            DataTable dataTable = new DataTable();
            sqlDataAdapter.SelectCommand = sqlCommand;
            OpenConnection();
            sqlDataAdapter.Fill(dataTable);
            CloseConnection();
            return dataTable;
        }
        public void ExecuteWithoutTable(String procedureName, SqlParameter[] parameter)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = procedureName;
            sqlCommand.Connection = sqlConnection;
            if (parameter != null)
            {
                sqlCommand.Parameters.AddRange(parameter);
            }
            OpenConnection();
            sqlCommand.ExecuteNonQuery();
            CloseConnection();
        }

        private void OpenConnection()
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        private void CloseConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
    }
}

