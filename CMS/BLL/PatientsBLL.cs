using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMS.DAL;
using Microsoft.Reporting.WinForms;

namespace CMS.BLL
{
    public class PatientsBLL
    {
        PatientsDAL t = new PatientsDAL();
        public bool checkPatientsBySSN(string SSN)
        {
            return t.checkPatientsBySSN(SSN) > 0;
        }

        public bool checkPatientsByID(int patientID)
        {
            return t.checkPatientsByID(patientID) > 0;
        }
        public bool checkPatientsByFirstName(string firstName)
        {
            return t.checkPatientsByFirstName(firstName) > 0;
        }
        public bool checkPatientsByPhoneNumber(string phoneNumber)
        {
            return t.checkPatientsByPhoneNumber(phoneNumber) > 0;
        }

        // hàm xuất báo cáo ra file
        public static void ExportReport(ReportViewer reportViewer1)
        {
            try
            {
                // Lấy đường dẫn thư mục chạy của ứng dụng (bin\Debug hoặc bin\Release)
                string appPath = Application.StartupPath;

                // Kết hợp với thư mục Report để tạo đường dẫn tương đối
                string reportFolder = Path.Combine(appPath, "_Report");

                // Tạo thư mục Report nếu chưa tồn tại
                if (!Directory.Exists(reportFolder))
                {
                    Directory.CreateDirectory(reportFolder);
                }
                //thêm thời gian vào tên file để tránh ghi đè 
                string fileName = $"PatientsReport_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                // Đường dẫn file Excel trong thư mục Report
                string filePath = Path.Combine(reportFolder, fileName);
                // Xuất báo cáo ra file Excel
                byte[] bytes = reportViewer1.LocalReport.Render("EXCELOPENXML");

                // Lưu file Excel
                File.WriteAllBytes(filePath, bytes);

                MessageBox.Show($"Xuất file Excel thành công! File được lưu tại: {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
            }
        }
    }
}
