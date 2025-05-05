using CMS.BLL;
using CMS.DML;
using CMS.UTIL;
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
        private readonly UsersBLL _usersBLL = new UsersBLL();
        string[] userRolesEN = new string[] {
            "Administrator",
            "Doctor",
            "Nurse",
            "Receptionist",
            "Accountant"
        };
        string[] userRolesVN = new string[] {
            "Quản trị viên",
            "Bác sĩ",
            "Y tá",
            "Lễ tân",
            "Kế toán"
        };
        private string[] securityQuestionVN = new string[] {
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

        private string[] securityQuestionEN = new string[] {
            "What is your mother's maiden name?",
            "What is your date of birth?",
            "In which city/town were you born?",
            "What was the name of your first pet?",
            "What was the license plate number of your first car?",
            "What was the name of your first elementary school?",
            "What was your favorite food as a child?",
            "What is your favorite book?",
            "What is your favorite movie?",
            "Who is your favorite singer or band?",
            "What is your favorite sport?",
            "What is your favorite sports team?",
            "What is your favorite color?",
            "What is your dream travel destination?",
            "Do you prefer reading books or watching movies?",
            "What do you usually do in your free time?",
            "What type of music do you like?",
            "What type of drink do you like?",
            "What type of fruit do you like?",
            "Which season of the year do you like the most?",
            "What is your most memorable moment?",
            "What is your biggest dream?",
            "What are you most proud of about yourself?",
            "Who has had the greatest influence on your life?",
            "What is the one thing you would most like to change about the world?",
            "If you had three wishes, what would you wish for?",
            "Would you rather live in a city or the countryside?",
            "Do you prefer working independently or in a team?",
            "What was your favorite subject in school?",
            "Do you have any special talents?"
        };

        private void UpdateLanguage()
        {
            lblSigup.Text = LanguageManager.GetString("lblSigup");
            lblUserName.Text = LanguageManager.GetString("lblUserName");
            lblPassword.Text = LanguageManager.GetString("lblPassword");
            lblConfirmPassword.Text = LanguageManager.GetString("lblConfirmPassword");
            lblUsersRole.Text = LanguageManager.GetString("lblUsersRole");
            lblEmail.Text = LanguageManager.GetString("lblEmail");
            lblSecurityQuestion.Text = LanguageManager.GetString("lblSecurityQuestion");
            lblSecurityAnswer.Text = LanguageManager.GetString("lblSecurityAnswer");
            btnSignUp.Text = LanguageManager.GetString("btnSignUp");
            txtUserName.PlaceholderText = LanguageManager.GetString("txtUserName_Holder");
            txtPassword.PlaceholderText = LanguageManager.GetString("txtPassword_Holder");
            txtConfirmPassword.PlaceholderText = LanguageManager.GetString("txtConfirmPassword_Holder");
            txtEmail.PlaceholderText = LanguageManager.GetString("txtEmail_Holder");
            txtSecurityAnswer.PlaceholderText = LanguageManager.GetString("txtSecurityAnswer_Holder");

        }

        private void frmCreateAccount_Load_()
        {
            //add data vào combobox quyền
            if (UTIL.Language.Lang.Equals("vn"))
            {
                cboUsersRole.Items.Clear();
                foreach (string item in userRolesVN)
                {
                    cboUsersRole.Items.Add(item);
                }
                cboUsersRole.SelectedIndex = 0;
            }
            else
            {
                cboUsersRole.Items.Clear();
                foreach (string item in userRolesEN)
                {
                    cboUsersRole.Items.Add(item);
                }
                cboUsersRole.SelectedIndex = 0;
            }


            //add dâta vào combobox câu hỏi bảo mật
            if (UTIL.Language.Lang.Equals("vn"))
            {
                cboSecurityQuestion.Items.Clear();
                foreach (string item in securityQuestionVN)
                {
                    cboSecurityQuestion.Items.Add(item);
                }
                cboSecurityQuestion.SelectedIndex = 0;
            }
            else
            {
                cboSecurityQuestion.Items.Clear();
                foreach (string item in securityQuestionEN)
                {
                    cboSecurityQuestion.Items.Add(item);
                }
                cboSecurityQuestion.SelectedIndex = 0;
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

            if (UTIL.Language.Lang.Equals("vn"))
            {
                //Gán giá trị mã ngôn ngữ mới cho Lang. Setter sẽ kiểm tra giá trị
                UTIL.LanguageManager.SetLanguage("vi-VN");
            }
            else
            {
                //Gán giá trị mã ngôn ngữ mới cho Lang.// Setter sẽ kiểm tra giá trị
                UTIL.LanguageManager.SetLanguage("en-US");
            }
            UpdateLanguage();
        }

        public frmCreateAccount()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text) ||
                string.IsNullOrEmpty(cboUsersRole.SelectedItem.ToString()) || string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(cboSecurityQuestion.SelectedItem.ToString()) || string.IsNullOrEmpty(txtSecurityAnswer.Text))
            {
                MessageBox.Show(LanguageManager.GetString("notif_frmCreateAccount_Fill"));
                return;
            }
            if (txtPassword.Text.Equals(txtConfirmPassword.Text))
            {
                UsersDML t = new UsersDML
                {
                    Username1 = txtUserName.Text,
                    PasswordHash1 = txtPassword.Text,
                    RoleUsers1 = cboUsersRole.SelectedItem.ToString(),
                    Email1 = txtEmail.Text,
                    SecurityQuestion1 = cboSecurityQuestion.SelectedItem.ToString(),
                    SecurityAnswerHash1 = txtSecurityAnswer.Text,
                    LastLogin1 = null,
                    IsActive1 = true
                };

                try
                {
                    bool success = _usersBLL.RegisterUser(t);
                    if (success)
                    {
                        MessageBox.Show(LanguageManager.GetString("notif_frmCreateAccount_Created"));
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(LanguageManager.GetString("notif_frmCreateAccount_CreateFailed") + ": " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show(LanguageManager.GetString("notif_frmCreateAccount_PassMiss"));
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCreateAccount_Load(object sender, EventArgs e)
        {
            frmCreateAccount_Load_();
        }
    }
}
