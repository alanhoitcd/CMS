using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL
{
    //class  sqlDatabase  chứa chuổi kết nối, hàm lấy kết nối và hủy kết nối
    public class sqlDatabase
    {   // Chuổi kết nối
        private static string sql_serverName = "ALANHO\\SQLEXPRESS";
        private static string sql_databaseName = "CMS";
        private static string sql_username = "sa";
        private static string sql_password = "@dm1n123";
        //private static string sql_connectString = $"Data Source={sql_serverName};Initial Catalog={sql_databaseName};User ID=" +
        //        $"{sql_username};Password={sql_password};";
        private static string sql_connectString;

        private static string GetServerName()
        {
            return Environment.MachineName;
        }

        public static string getConnectString()
        {
            string serverName = GetServerName();
            sql_connectString = $@"Data Source={serverName}\SQLEXPRESS;Initial Catalog=CMS;Integrated Security=True";
            return sql_connectString;
        }

    }
}
