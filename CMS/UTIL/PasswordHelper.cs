using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.UTIL
{
    public static class PasswordHelper
    {
        // Mã hóa mật khẩu
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty.");
            }
            // Mã hóa mật khẩu với BCrypt, tự động thêm salt
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Kiểm tra mật khẩu
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
            {
                return false;
            }
            // So sánh mật khẩu người dùng nhập với mật khẩu đã mã hóa
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
