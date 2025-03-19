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
    public class Doctors_DML
    {
        /*  DoctorId INT IDENTITY(1,1) PRIMARY KEY,
	        UserId INT NULL,
            FirstName NVARCHAR(50) NOT NULL,
            LastName NVARCHAR(50) NOT NULL,
            Specialty NVARCHAR(50) NOT NULL,
            LicenseNumber NVARCHAR(20) UNIQUE NOT NULL,
            Schedule NVARCHAR(100) NOT NULL,*/

        private int DoctorId;
        private int UserId;
        private string FirstName;
        private string LastName;
        private string Specialty;
        private string LicenseNumber;
        private string Schedule;

        public Doctors_DML()
        {
        }

        public Doctors_DML(int doctorId, int userId, string firstName, string lastName, string specialty, string licenseNumber, string schedule)
        {
            DoctorId1 = doctorId;
            UserId1 = userId;
            FirstName1 = firstName;
            LastName1 = lastName;
            Specialty1 = specialty;
            LicenseNumber1 = licenseNumber;
            Schedule1 = schedule;
        }

        public int DoctorId1 { get => DoctorId; set => DoctorId = value; }
        public int UserId1 { get => UserId; set => UserId = value; }
        public string FirstName1 { get => FirstName; set => FirstName = value; }
        public string LastName1 { get => LastName; set => LastName = value; }
        public string Specialty1 { get => Specialty; set => Specialty = value; }
        public string LicenseNumber1 { get => LicenseNumber; set => LicenseNumber = value; }
        public string Schedule1 { get => Schedule; set => Schedule = value; }
    }
}
