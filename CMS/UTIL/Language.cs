using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.UTIL
{
    public static class Language
    {
        // Thuộc tính tĩnh để lưu mã ngôn ngữ
        private static string _lang = "en"; // Giá trị mặc định là "en"

        // Danh sách các mã ngôn ngữ được hỗ trợ
        private static readonly HashSet<string> SupportedLanguages = new HashSet<string> { "en", "vn" };

        // Property để truy cập và thay đổi mã ngôn ngữ
        public static string Lang
        {
            get => _lang;
            set
            {
                // Kiểm tra giá trị hợp lệ trước khi gán
                if (SupportedLanguages.Contains(value))
                {
                    _lang = value;
                }
                else
                {
                    throw new ArgumentException($"Language '{value}' is not supported. Supported languages: {string.Join(", ", SupportedLanguages)}");
                }
            }
        }

        // Phương thức để lấy danh sách ngôn ngữ được hỗ trợ (nếu cần)
        public static IEnumerable<string> GetSupportedLanguages()
        {
            return SupportedLanguages;
        }
    }

}
