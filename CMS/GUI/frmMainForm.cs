using CMS.GUI;
using CMS.VIEW;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Suite.Descriptions;

/*1. Presentation Layer (Lớp giao diện)
Mô tả: Đây là lớp mà người dùng tương tác trực tiếp, bao gồm các form, button, textbox, datagridview, v.v. 
trong WinForms. Lớp này chịu trách nhiệm hiển thị dữ liệu, nhận đầu vào từ người dùng và gửi yêu cầu đến lớp Business Logic Layer.
Nhiệm vụ chính:
Hiển thị dữ liệu từ các đối tượng mô hình (Model) lên giao diện (ví dụ: danh sách bệnh nhân, thông tin lịch hẹn).
Xử lý sự kiện người dùng (click button, nhập liệu).
Gọi các phương thức từ Business Logic Layer để xử lý yêu cầu.
Các hàm/nhiệm vụ cụ thể:
LoadData(): Tải dữ liệu (ví dụ: danh sách bệnh nhân) lên DataGridView.
SaveButton_Click(): Gọi hàm lưu dữ liệu từ Business Layer khi người dùng nhấn nút "Lưu".
ValidateInput(): Kiểm tra dữ liệu đầu vào cơ bản (ví dụ: tên bệnh nhân không được để trống) trước khi gửi sang Business Layer.
ShowErrorMessage(): Hiển thị thông báo lỗi nếu có từ các lớp khác.*/
namespace CMS
{
    public partial class frmMainForm : Form
    {
        static bool statusLightMode = true;
        static bool statusLangENG = true;

        void ChangeLanguage(Guna2Button btnLang, Label lblLogan)//event btnLang_Click()
        {
            if (statusLangENG)
            {
                statusLangENG = false;
                lblLogan.Text = "Nơi sức khỏe bắt đầu, công nghệ dẫn lối";
                using (MemoryStream ms = new MemoryStream(Properties.Resources.iconUSA))
                {
                    btnLang.Image = Image.FromStream(ms);
                }
            }
            else
            {
                statusLangENG = true;
                lblLogan.Text = "Where health begins, technology leads the way";
                using (MemoryStream ms = new MemoryStream(Properties.Resources.iconVietNam))
                {
                    btnLang.Image = Image.FromStream(ms);
                }
            }
        }

        void ChangeScreenMode(Guna2Button btnScreenMode, bool lightMode)//event btnScreenMode_Click()
        {
            if (statusLightMode)
            {
                statusLightMode = false;
                this.BackColor = Color.Gray;
                using (MemoryStream ms = new MemoryStream(Properties.Resources.iconLightMode))
                {
                    btnScreenMode.Image = Image.FromStream(ms);
                }
            }
            else
            {
                statusLightMode = true;
                this.BackColor = Color.WhiteSmoke;
                using (MemoryStream ms = new MemoryStream(Properties.Resources.iconDarkMode))
                {
                    btnScreenMode.Image = Image.FromStream(ms);
                }
            }
        }

        private void frmMainForm_Load_(bool on)//hàm khi form chạy
        {
            //thiết lập các icon cho toolmenustrip File item
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconLogin))
            {
                tsmiLogin.Image = Image.FromStream(ms);
            }
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconLogout))
            {
                tsmiLogout.Image = Image.FromStream(ms);
            }
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconChangePassword))
            {
                tsmiChangePassword.Image = Image.FromStream(ms);
            }
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconExit))
            {
                tsmiExit.Image = Image.FromStream(ms);
            }
            //thiết lập các icon cho toolmenustrip Menagement item
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconManagePatients))
            {
                tsmiManagePatient.Image = Image.FromStream(ms);
            }
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconManageDoctors))
            {
                tsmiManageDoctors.Image = Image.FromStream(ms);
            }
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconManageAppointments))
            {
                tsmiManageAppointments.Image = Image.FromStream(ms);
            }
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconManageMedicineInventory))
            {
                tsmiManageMedicineInventory.Image = Image.FromStream(ms);
            }
            //thiết lập các icon cho toolmenustrip Patient Examination item
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconManageExaminationHistory))
            {
                tsmiManageExaminationHistory.Image = Image.FromStream(ms);
            }
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconManagePrescription))
            {
                tsmiManagePrescriptions.Image = Image.FromStream(ms);
            }
            //thiết lập các icon cho toolmenustrip report item
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconPatientListReport))
            {
                tsmiPatientListReport.Image = Image.FromStream(ms);
            }
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconAppointmentScheduleReport))
            {
                tsmiAppointmentScheduleReport.Image = Image.FromStream(ms);
            }
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconInventoryandMedicineRevenueReport))
            {
                tsmiInventoryAndMedicineRevenueReport.Image = Image.FromStream(ms);
            }
            //thiết lập các icon cho toolmenustrip System item
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconManageUserAccounts))
            {
                tsmiManageUserAccounts.Image = Image.FromStream(ms);
            }
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconViewActivityLog))
            {
                tsmiViewActivityLog.Image = Image.FromStream(ms);
            }
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconBackupandRestoreDatabase))
            {
                tsmiBackupandRestoreDatabase.Image = Image.FromStream(ms);
            }
            //thiết lập các icon cho toolmenustrip help item
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconAboutSoftware))
            {
                tsmiAboutSoftware.Image = Image.FromStream(ms);
            }
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconUserGuide))
            {
                tsmiUserGuide.Image = Image.FromStream(ms);
            }
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconContactSupport))
            {
                tsmiContactSupport.Image = Image.FromStream(ms);
            }
            //Ẩn các menustrip
            tsmiLogout.Enabled = on;
            tsmiChangePassword.Enabled = on;
            tsmiManagement.Enabled = on;
            tsmiChangePassword.Enabled = on;
            tsmiPatientExamination.Enabled = on;
            tsmiChangePassword.Enabled = on;
            tsmiReports.Enabled = on;
            tsmiChangePassword.Enabled = on;
            tsmiManageUserAccounts.Enabled = on;
            tsmiChangePassword.Enabled = on;
            tsmiLogin.Enabled = !on;
            //Ẩn Panel main
            if (!on)
            {
                pnlMain.Hide();
            }
            else
            {
                pnlMain.Show();
            }
            //Ẩn các tabcontrol
            tabControlMain.TabPages.Remove(tabPagePatients);
            tabControlMain.TabPages.Remove(tabPageDoctors);

        }
        //********************************************************************************************//
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            frmMainForm_Load_(false);
        }

        private void btnScreenMode_Click(object sender, EventArgs e)
        {
            ChangeScreenMode(btnScreenMode, statusLightMode);
        }

        private void btnLang_Click(object sender, EventArgs e)
        {
            ChangeLanguage(btnLang, lblLogan);
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiLogin_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            if (f.ShowDialog() == DialogResult.OK)
            {
                frmMainForm_Load_(true);
            }
            else
            {
                frmMainForm_Load_(false);
            }
        }

        private void tsmiLogout_Click(object sender, EventArgs e)
        {
            frmMainForm_Load_(false);
        }

        private void tsmiManagePatient_Click(object sender, EventArgs e)
        {
            //Xóa nội dung các tabpage
            tabPagePatients.Controls.Clear();
            tabPageDoctors.Controls.Clear();

            //tạo các đối tượng form và truyền vào các tabpage của tabcontrol
            frmManagePatients frmManagePatients = new frmManagePatients(tabPagePatients, tabControlMain);

            //thiết lập nhúng các form vào các tabpage
            frmManagePatients.TopLevel = false;
            frmManagePatients.Dock = DockStyle.Fill;
            frmManagePatients.Visible = true;

            //Thêm các form vào tabpage
            tabPagePatients.Controls.Add(frmManagePatients);

            //chuyển focus sang tabpage được chọn
            tabControlMain.SelectedTab = tabPagePatients;
            //Kiểm tra nếu tabpage bị ẩn thì mở lại
            if (!tabControlMain.TabPages.Contains(tabPagePatients))
            {
                tabControlMain.TabPages.Add(tabPagePatients);
            }
        }
    }
}
