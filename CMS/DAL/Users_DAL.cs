using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL
{
    class Users_DAL
    {
        /*
         3. Data Access Layer (Lớp truy cập dữ liệu)
        Mô tả: Lớp này chịu trách nhiệm giao tiếp trực tiếp với database (thường là SQL Server trong C# WinForms). 
        Nó thực hiện các thao tác CRUD (Create, Read, Update, Delete) và ánh xạ dữ liệu từ database vào các đối tượng Model.
        Nhiệm vụ chính:
        Truy xuất dữ liệu từ database.
        Lưu dữ liệu từ ứng dụng vào database.
        Đảm bảo kết nối và quản lý giao dịch với database.
        Các hàm/nhiệm vụ cụ thể:
        InsertPatient(): Thêm một bệnh nhân mới vào bảng Patients trong database.
        GetPatientById(): Truy vấn thông tin bệnh nhân theo mã ID.
        UpdateAppointment(): Cập nhật thông tin lịch hẹn trong database.
        DeletePatient(): Xóa bệnh nhân khỏi database.
        GetAllAppointments(): Lấy toàn bộ danh sách lịch hẹn từ database để trả về dưới dạng danh sách Model.*/

        public int checkUser(string ten_nguoi_dung)
        {
            try
            {
                using (SqlConnection c = new SqlConnection(DAL.sqlDatabase.getConnectString()))
                {
                    c.Open();
                    string query = "select count(Username) from Users where Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, c))
                    {
                        cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = ten_nguoi_dung; // Sửa kiểu dữ liệu
                        return (int)cmd.ExecuteScalar(); // Trả về kết quả trực tiếp
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi class Users_DAL function checkUser: " + ex.Message);
                return 0;
            }
        }

        public int checkPassword(string userName, string password)
        {
            try
            {
                using (SqlConnection c = new SqlConnection(DAL.sqlDatabase.getConnectString()))
                {
                    c.Open();
                    string query = "select count(Username) from Users where Username = @Username and PasswordHash = @PasswordHash";
                    using (SqlCommand cmd = new SqlCommand(query, c))
                    {
                        cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = userName; // Sửa kiểu dữ liệu
                        cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar).Value = password;
                        return (int)cmd.ExecuteScalar(); // Trả về kết quả trực tiếp số lượng dòng kết quả
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi class Users_DAL function checkPassword(): " + ex.Message);
                return 0;
            }
        }
    }
}
