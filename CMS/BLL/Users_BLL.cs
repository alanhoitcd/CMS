using CMS.DAL;
using CMS.DML;
using CMS.UTIL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMS.BLL
{
    public class Users_BLL
    {
        private readonly Users_DAL _usersDAL = new Users_DAL();
        public bool checkUser(string ten_nguoi_dung)
        {
            return _usersDAL.checkUser(ten_nguoi_dung) > 0;
        }

        public bool LoginUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username and password are required.");
            }

            Users_DML user = _usersDAL.GetUserByUsername(username);
            if (user == null)
            {
                return false; // Người dùng không tồn tại
            }

            if (!user.IsActive1)
            {
                throw new Exception("Account is not active.");
            }

            bool isPasswordValid = PasswordHelper.VerifyPassword(password, user.PasswordHash1);
            if (!isPasswordValid)
            {
                return false; // Mật khẩu sai
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be empty.");
            if (email.Length < 6)
                throw new ArgumentException("Email must be at least 6 characters long.");
            if (email.Length > 100)
                throw new ArgumentException("Email cannot exceed 100 characters.");

            // Biểu thức chính quy kiểm tra email
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(email, emailPattern))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool RegisterUser(Users_DML t)
        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(t.Username1) || string.IsNullOrEmpty(t.PasswordHash1) ||
                string.IsNullOrEmpty(t.RoleUsers1) || string.IsNullOrEmpty(t.Email1) ||
                t.SecurityQuestion1 == null || t.SecurityQuestion1.Length == 0 ||
                t.SecurityAnswerHash1 == null || t.SecurityAnswerHash1.Length == 0)
            {
                throw new ArgumentException("All required fields must be provided.");
            }

            // Kiểm tra định dạng Email
            if (!IsValidEmail(t.Email1))
            {
                throw new ArgumentException("Invalid email format.");
            }

            // Kiểm tra xem username đã tồn tại chưa
            if (_usersDAL.GetUserByUsername(t.Username1) != null)
            {
                throw new ArgumentException("Username already exists.");
            }

            // Kiểm tra xem email đã tồn tại chưa
            if (_usersDAL.GetUserByEmail(t.Email1) != null)
            {
                throw new ArgumentException("Email already exists.");
            }

            // Mã hóa mật khẩu
            string hashedPassword = PasswordHelper.HashPassword(t.PasswordHash1);
            // Mã hóa câu hỏi bảo mật
            string hashSecurityQuestion = PasswordHelper.HashPassword(t.SecurityQuestion1);
            // Mã hóa câu trả lời bảo mật
            string hashSecurityAnswerHash = PasswordHelper.HashPassword(t.SecurityAnswerHash1);

            //// Tạo đối tượng Users_DML
            //Users_DML user = new Users_DML
            //{
            //    Username1 = t.Username1,
            //    PasswordHash1 = hashedPassword,
            //    RoleUsers1 = t.RoleUsers1,
            //    Email1 = t.Email1,
            //    SecurityQuestion1 = hashSecurityQuestion,
            //    SecurityAnswerHash1 = hashSecurityAnswerHash,
            //    LastLogin1 = t.LastLogin1,
            //    IsActive1 = t.IsActive1
            //};

            //// Gọi DAL để lưu vào cơ sở dữ liệu
            //return _usersDAL.CreateUser(user);

            //edit trên Users_DML t truyền vào không tạo đối tượng mới để tiết kiệm bộ nhớ
            t.PasswordHash1 = PasswordHelper.HashPassword(t.PasswordHash1);
            t.SecurityAnswerHash1 = PasswordHelper.HashPassword(t.SecurityAnswerHash1);
            return _usersDAL.CreateUser(t);
        }





        //public bool checkPassword(string ten_nguoi_dung, string mat_khau)
        //{
        //    return Users_DAL_.checkPassword(ten_nguoi_dung, mat_khau) > 0;
        //}
    }
}



