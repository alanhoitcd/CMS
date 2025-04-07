using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DML;

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

        public bool CreateUser(Users_DML t)
        {
            using (SqlConnection conn = new SqlConnection(DAL.sqlDatabase.getConnectString()))
            {
                string query = "INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate) " +
                               "VALUES (@Username, @PasswordHash, @RoleUsers, @Email, @SecurityQuestion, @SecurityAnswerHash, @LastLogin, @IsActive, GETDATE())";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = t.Username1;
                cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar).Value = t.PasswordHash1;
                cmd.Parameters.Add("@RoleUsers", SqlDbType.NVarChar).Value = t.RoleUsers1;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = t.Email1;
                cmd.Parameters.Add("@SecurityQuestion", SqlDbType.NVarChar).Value = t.SecurityQuestion1;
                cmd.Parameters.Add("@SecurityAnswerHash", SqlDbType.NVarChar).Value = t.SecurityAnswerHash1;
                cmd.Parameters.Add("@LastLogin", SqlDbType.DateTime).Value = (object)t.LastLogin1 ?? DBNull.Value;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = t.IsActive1;

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Lỗi vi phạm ràng buộc UNIQUE
                    {
                        if (ex.Message.Contains("Username"))
                            throw new Exception("Username already exists in the database.");
                        if (ex.Message.Contains("Email"))
                            throw new Exception("Email already exists in the database.");
                    }
                    throw new Exception("Error creating user: " + ex.Message);
                }
            }
        }

        public Users_DML GetUserByUsername(string userName)
        {
            using (SqlConnection conn = new SqlConnection(DAL.sqlDatabase.getConnectString()))
            {
                string query = "SELECT * FROM Users WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = userName;

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Users_DML
                        {
                            UserId1 = Convert.ToInt32(reader["UserId"]),
                            Username1 = reader["Username"].ToString(),
                            PasswordHash1 = reader["PasswordHash"].ToString(),
                            RoleUsers1 = reader["RoleUsers"].ToString(),
                            Email1 = reader["Email"].ToString(),
                            SecurityQuestion1 = reader["SecurityQuestion"].ToString(),
                            SecurityAnswerHash1 = reader["SecurityAnswerHash"].ToString(),
                            LastLogin1 = reader["LastLogin"] != DBNull.Value ? Convert.ToDateTime(reader["LastLogin"]) : (DateTime?)null,
                            IsActive1 = Convert.ToBoolean(reader["IsActive"]),
                            //Kiểm tra CreateDate bên sql có null không
                            //CreatedDate1 = reader["CreatedDate"] != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("CreatedDate")) : DateTime.Now
                            CreatedDate1 = reader.GetDateTime(reader.GetOrdinal("CreatedDate"))

                        };
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving user: " + ex.Message);
                }
            }
        }

        public Users_DML GetUserByEmail(string email)
        {
            using (SqlConnection conn = new SqlConnection(DAL.sqlDatabase.getConnectString()))
            {
                string query = "SELECT * FROM Users WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Users_DML
                        {
                            UserId1 = Convert.ToInt32(reader["UserId"]),
                            Username1 = reader["Username"].ToString(),
                            PasswordHash1 = reader["PasswordHash"].ToString(),
                            RoleUsers1 = reader["RoleUsers"].ToString(),
                            Email1 = reader["Email"].ToString(),
                            SecurityQuestion1 = reader["SecurityQuestion"].ToString(),
                            SecurityAnswerHash1 = reader["SecurityAnswerHash"].ToString(),
                            LastLogin1 = reader["LastLogin"] != DBNull.Value ? Convert.ToDateTime(reader["LastLogin"]) : (DateTime?)null,
                            IsActive1 = Convert.ToBoolean(reader["IsActive"]),
                            //Kiểm tra CreateDate bên sql có null không
                            //CreatedDate1 = reader["CreatedDate"] != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("CreatedDate")) : DateTime.Now
                            CreatedDate1 = reader.GetDateTime(reader.GetOrdinal("CreatedDate"))
                        };
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
        }




        //public int checkPassword(string userName, string password)
        //{
        //    try
        //    {
        //        using (SqlConnection c = new SqlConnection(DAL.sqlDatabase.getConnectString()))
        //        {
        //            c.Open();
        //            string query = "select count(Username) from Users where Username = @Username and PasswordHash = @PasswordHash";
        //            using (SqlCommand cmd = new SqlCommand(query, c))
        //            {
        //                cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = userName; // Sửa kiểu dữ liệu
        //                cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar).Value = password;
        //                return (int)cmd.ExecuteScalar(); // Trả về kết quả trực tiếp số lượng dòng kết quả
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi class Users_DAL function checkPassword(): " + ex.Message);
        //        return 0;
        //    }
        //}
    }
}
