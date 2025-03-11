using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL
{
    public class BacSi_BLL
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
        
    }
}
