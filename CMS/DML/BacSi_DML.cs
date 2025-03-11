using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*4. Data Model Layer (Lớp mô hình dữ liệu)
Mô tả: Lớp này chứa các class đại diện cho các bảng trong database (entities). Đây là nơi mô phỏng cấu trúc dữ liệu 
như bệnh nhân, lịch hẹn, hóa đơn, v.v. Lớp này không chứa logic, chỉ là "khung dữ liệu".
Nhiệm vụ chính:
Định nghĩa cấu trúc dữ liệu tương ứng với bảng trong database.
Cung cấp các đối tượng để các lớp khác sử dụng.
Các hàm/nhiệm vụ cụ thể:
Không có hàm xử lý logic, chỉ có các thuộc tính (properties) đại diện cho cột trong database.
Ví dụ:
Class Patient: Chứa các thuộc tính như Id, Name, DateOfBirth, PhoneNumber.
Class Appointment: Chứa các thuộc tính như Id, PatientId, DateTime, DoctorId.
Class Bill: Chứa các thuộc tính như Id, PatientId, Amount, Date.*/
namespace CMS.DML
{
    public class BacSi_DML
    {
        /*      id_bac_si INT IDENTITY(1,1) PRIMARY KEY,
                ho_ten NVARCHAR(100) NOT NULL,
                chuyen_khoa NVARCHAR(50) NOT NULL,
                so_dien_thoai VARCHAR(20) NOT NULL,
                so_giay_phep VARCHAR(50) NOT NULL*/
        private int id_bac_si;
        private string ho_ten;
        private string chuyen_khoa;
        private string so_dien_thoai;
        private string so_giay_phep;

        public int Id_bac_si { get => id_bac_si; set => id_bac_si = value; }
        public string Ho_ten { get => ho_ten; set => ho_ten = value; }
        public string Chuyen_khoa { get => chuyen_khoa; set => chuyen_khoa = value; }
        public string So_dien_thoai { get => so_dien_thoai; set => so_dien_thoai = value; }
        public string So_giay_phep { get => so_giay_phep; set => so_giay_phep = value; }

        public BacSi_DML(int id_bac_si, string ho_ten, string chuyen_khoa, string so_dien_thoai, string so_giay_phep)
        {
            this.Id_bac_si = id_bac_si;
            this.Ho_ten = ho_ten;
            this.Chuyen_khoa = chuyen_khoa;
            this.So_dien_thoai = so_dien_thoai;
            this.So_giay_phep = so_giay_phep;
        }

        public BacSi_DML()
        {
        }
    }
}
