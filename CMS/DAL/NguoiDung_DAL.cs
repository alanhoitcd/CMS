using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL
{
    class NguoiDung_DAL
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

        public int CheckUser(int id_nguoi_dung)
        {
            try
            {
                using (SqlConnection c = new SqlConnection(DAL.sqlDatabase.getConnectString()))
                {
                    c.Open();
                    string query = "SELECT COUNT(ten_nguoi_dung) FROM nguoi_dung WHERE id_nguoi_dung = @id_nguoi_dung";
                    using (SqlCommand cmd = new SqlCommand(query, c))
                    {
                        cmd.Parameters.Add("@id_nguoi_dung", SqlDbType.Int).Value = id_nguoi_dung; // Sửa kiểu dữ liệu
                        return (int)cmd.ExecuteScalar(); // Trả về kết quả trực tiếp
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi NguoiDung_DAL: " + ex.Message);
                return 0;
            }
        }
    }
}
