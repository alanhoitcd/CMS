using CMS.BLL;
using CMS.DML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.GUI
{
    public partial class frmCreateAccount : Form
    {
        private readonly Users_BLL _usersBLL = new Users_BLL();
        string[] userRoles = new string[] {
            "Administrator",
            "Doctor",
            "Nurse",
            "Receptionist",
            "Accountant"
        };
        private string[] securityQuestion = new string[] {
            "Tên thời con gái của mẹ bạn là gì?",
            "Ngày sinh của bạn là ngày nào?",
            "Nơi sinh của bạn là thành phố/thị trấn nào?",
            "Tên thú cưng đầu tiên của bạn là gì?",
            "Biển số xe đầu tiên của bạn là gì?",
            "Trường tiểu học đầu tiên của bạn tên là gì?",
            "Món ăn yêu thích của bạn khi còn nhỏ là gì?",
            "Cuốn sách yêu thích của bạn là gì?",
            "Bộ phim yêu thích của bạn là gì?",
            "Ca sĩ/ban nhạc yêu thích của bạn là gì?",
            "Môn thể thao yêu thích của bạn là gì?",
            "Đội thể thao yêu thích của bạn là gì?",
            "Màu sắc yêu thích của bạn là gì?",
            "Địa điểm du lịch mơ ước của bạn là đâu?",
            "Bạn thích đọc sách hay xem phim hơn?",
            "Bạn thường làm gì vào thời gian rảnh?",
            "Bạn thích loại nhạc nào?",
            "Bạn thích uống loại đồ uống nào?",
            "Bạn thích ăn loại trái cây nào?",
            "Bạn thích mùa nào trong năm nhất?",
            "Kỷ niệm đáng nhớ nhất của bạn là gì?",
            "Ước mơ lớn nhất của bạn là gì?",
            "Điều gì khiến bạn tự hào nhất về bản thân?",
            "Ai là người có ảnh hưởng lớn nhất đến cuộc đời bạn?",
            "Bạn muốn thay đổi điều gì nhất trên thế giới này?",
            "Nếu có ba điều ước, bạn sẽ ước gì?",
            "Bạn thích sống ở thành phố hay nông thôn hơn?",
            "Bạn thích làm việc độc lập hay theo nhóm hơn?",
            "Bạn thích học môn học nào nhất khi còn đi học?",
            "Bạn có tài lẻ gì đặc biệt không?"
        };

        public frmCreateAccount()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text) ||
                string.IsNullOrEmpty(cboUsersRole.SelectedItem.ToString()) || string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(cboSecurityQuestion.SelectedItem.ToString()) || string.IsNullOrEmpty(txtSecurityAnswerHash.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }
            if (txtPassword.Text.Equals(txtConfirmPassword.Text))
            {
                Users_DML t = new Users_DML
                {
                    Username1 = txtUserName.Text,
                    PasswordHash1 = txtPassword.Text,
                    RoleUsers1 = cboUsersRole.SelectedItem.ToString(),
                    Email1 = txtEmail.Text,
                    SecurityQuestion1 = cboSecurityQuestion.SelectedItem.ToString(),
                    SecurityAnswerHash1 = txtSecurityAnswerHash.Text,
                    LastLogin1 = null,
                    IsActive1 = true
                };

                try
                {
                    bool success = _usersBLL.RegisterUser(t);
                    if (success)
                    {
                        MessageBox.Show("Tạo tài khoản thành công!");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tạo tài khoản thất bại: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Xác thực mật khẩu không khớp");
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCreateAccount_Load(object sender, EventArgs e)
        {
            foreach (string item in userRoles)
            {
                cboUsersRole.Items.Add(item);
            }
            cboUsersRole.SelectedIndex = 0;
            foreach (string item in securityQuestion)
            {
                cboSecurityQuestion.Items.Add(item);
            }
            cboSecurityQuestion.SelectedIndex = 0;
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconClose))
            {
                btnClose.Image = Image.FromStream(ms);
            }
            using (MemoryStream ms = new MemoryStream(Properties.Resources.imgfrmCreateAccount))
            {
                ptbSignUp.Image = Image.FromStream(ms);
            }
        }
    }
}
