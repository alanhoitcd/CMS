using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMS.DAL;
using CMS.DML;
using Microsoft.Reporting.WinForms;

namespace CMS.BLL
{
    public class DoctorsBLL
    {
        /*
         * 2. Business Logic Layer (Lớp nghiệp vụ)
        Mô tả: Lớp này chứa logic nghiệp vụ của ứng dụng, xử lý các quy tắc kinh doanh (business rules) 
        và điều phối dữ liệu giữa Presentation Layer và Data Access Layer. Ví dụ: kiểm tra lịch hẹn trùng, tính toán chi phí khám bệnh.
        Nhiệm vụ chính:
        Xử lý logic nghiệp vụ (ví dụ: không cho đặt lịch hẹn trùng giờ).
        Chuyển đổi dữ liệu giữa Presentation Layer và Data Access Layer.
        Đảm bảo tính toàn vẹn và hợp lệ của dữ liệu trước khi lưu vào database.
        Các hàm/nhiệm vụ cụ thể:
        AddPatient(): Thêm thông tin bệnh nhân mới, kiểm tra xem mã bệnh nhân đã tồn tại chưa.
        ScheduleAppointment(): Đặt lịch hẹn, kiểm tra trùng lịch và trả về kết quả thành công/thất bại.
        CalculateBill(): Tính hóa đơn dựa trên dịch vụ khám bệnh.
        GetPatientList(): Lấy danh sách bệnh nhân từ Data Access Layer để gửi lên Presentation Layer.
        ValidateAppointment(): Kiểm tra tính hợp lệ của lịch hẹn (ví dụ: giờ làm việc của phòng khám).
         * */
        //DoctorsDAL t = new DoctorsDAL();

        //public bool checkDoctorsByLicenseNumber(string LicenseNumber)
        //{
        //    return t.checkDoctorsByLicenseNumber(LicenseNumber) > 0;
        //}

        private readonly DoctorsDAL t = new DoctorsDAL();

        public bool CheckDoctorsByDoctorId(int doctorId)
        {
            return t.CheckDoctorsByDoctorId(doctorId) > 0;
        }

        public bool CheckDoctorsByLicenseNumber(string licenseNumber)
        {
            return t.CheckDoctorsByLicenseNumber(licenseNumber) > 0;
        }

        public bool CheckDoctorsByFirstName(string firstName)
        {
            return t.CheckDoctorsByFirstName(firstName) > 0;
        }

        public bool CheckDoctorsBySpecialty(string specialty)
        {
            return t.CheckDoctorsBySpecialty(specialty) > 0;
        }

        public bool CheckDoctorsBySchedule(string schedule)
        {
            return t.CheckDoctorsBySchedule(schedule) > 0;
        }

        public DataTable GetAllDoctors()
        {
            return t.GetAllDoctors();
        }

        public void Insert(DoctorsDML dml)
        {
            t.Insert(dml);
        }

        public void Update(DoctorsDML dml)
        {
            t.Update(dml);
        }

        public void Delete(DoctorsDML dml)
        {
            t.Delete(dml);
        }

        public DataTable GetDoctorById(int doctorId)
        {
            return t.GetDoctorById(doctorId);
        }

        public DataTable GetDoctorsByFirstName(string firstName)
        {
            return t.GetDoctorsByFirstName(firstName);
        }

        public DataTable GetDoctorsBySpecialty(string specialty)
        {
            return t.GetDoctorsBySpecialty(specialty);
        }

        public DataTable GetDoctorsByLicenseNumber(string licenseNumber)
        {
            return t.GetDoctorsByLicenseNumber(licenseNumber);
        }

        public DataTable GetDoctorsBySchedule(string schedule)
        {
            return t.GetDoctorsBySchedule(schedule);
        }

    }
}
