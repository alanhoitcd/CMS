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
        private static string sql_connectString = $"Data Source={sql_serverName};Initial Catalog={sql_databaseName};User ID=" +
                $"{sql_username};Password={sql_password};";
        //private static SqlConnection connect_;

        public static string getConnectString()
        {
            return sql_connectString;
        }



        //public static SqlConnection getConnection()
        //{     //hàm kết nối sql
        //    try
        //    {
        //        //Gán giá trị cho đối tượng kết nối
        //        connect_ = new SqlConnection(sql_connectString);
        //        // Mở kết nối
        //        connect_.Open();

        //        // Kiểm tra trạng thái kết nối
        //        if (connect_.State == ConnectionState.Open)
        //        {
        //            Console.WriteLine("Kết nối SQL thành công");
        //            return connect_;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Kết nối SQL thất bại");
        //            return null; // Hoặc throw một ngoại lệ tùy theo yêu cầu
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi kết nối SQL: " + ex.Message);
        //        return null;
        //    }
        //}

        //public static void disConnet()
        //{      //hàm HỦY kết nối sql
        //    if (connect_ != null && connect_.State == ConnectionState.Open)
        //    {
        //        connect_.Close();
        //        connect_.Dispose();
        //    }
        //}
    }
}
