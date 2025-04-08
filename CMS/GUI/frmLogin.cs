using CMS.BLL;
using CMS.GUI;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace CMS.VIEW
{
    public partial class frmLogin : Form
    {
        private readonly Users_BLL _usersBLL = new Users_BLL();
        private static int countSaiPass = 0;
        private void UpdateLanguage()
        {
            //Đổi ngôn ngữ label Chào
            lblLogin.Text = LanguageManager.GetString("lblLogin");
            txtUserName.PlaceholderText = LanguageManager.GetString("txtUserName");
            txtPassword.PlaceholderText = LanguageManager.GetString("txtPassword");
            chkRememberPassword.Text = LanguageManager.GetString("chkRememberPassword");
            btnLogin.Text = LanguageManager.GetString("btnLogin");
            llblForgotPassword.Text = LanguageManager.GetString("llblForgotPassword");
            llblDontHaveAnAccount.Text = LanguageManager.GetString("llblDontHaveAnAccount");
            
        }
        void frmLogin_Load_()
        {
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconClose))
            {
                btnClose.Image = Image.FromStream(ms);
            }
            using (MemoryStream ms = new MemoryStream(Properties.Resources.imgfrmLoginForm))
            {
                ptbLogin.Image = Image.FromStream(ms);
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
            txtPassword.Text = "admin";
            txtUserName.Text = "admin";
        }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            frmLogin_Load_();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCreateAccount f = new frmCreateAccount();
            f.ShowDialog();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                string frmLoginCap_Enter = LanguageManager.GetString("notif_frmLogin_EnterUserAndPass");
                string notification = LanguageManager.GetString("notif_");
                MessageBox.Show(frmLoginCap_Enter, notification);
                return;
            }
            else
            {
                Users_BLL NguoiDung_BLL_ = new Users_BLL();
                if (NguoiDung_BLL_.checkUser(txtUserName.Text))//kiểm tra id có trong database chưa
                {
                    try
                    {
                        bool success = _usersBLL.LoginUser(txtUserName.Text, txtPassword.Text);
                        if (success)
                        {
                            string frmLoginCap_LoginSuccessful = LanguageManager.GetString("notif_frmLogin_LoginSuccessful");
                            string notification = LanguageManager.GetString("notif_");
                            MessageBox.Show(frmLoginCap_LoginSuccessful, notification);
                            this.DialogResult = DialogResult.OK;
                            countSaiPass = 0;
                        }
                        else
                        {
                            if (countSaiPass <= 2)
                            {
                                string frmLoginCap_WrongPassword = LanguageManager.GetString("notif_frmLogin_WrongPassword");
                                string frmLoginCap_CountTime = LanguageManager.GetString("notif_frmLogin_CountTime");
                                string notification = LanguageManager.GetString("notif_");
                                MessageBox.Show(frmLoginCap_WrongPassword + (countSaiPass + 1) + frmLoginCap_CountTime, notification);
                                countSaiPass++;
                                txtPassword.ResetText();
                                if (countSaiPass == 3)
                                {
                                    txtPassword.Enabled = false;
                                    string noticeClosed = LanguageManager.GetString("notif_frmLogin_Closed");
                                    MessageBox.Show(noticeClosed, notification);
                                    this.DialogResult = DialogResult.Cancel;
                                    Application.Exit();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string frmLoginCap_Error = LanguageManager.GetString("notif_frmLogin_Error");
                        MessageBox.Show(frmLoginCap_Error + ex.Message);
                    }
                }
                else
                {
                    txtUserName.ResetText();
                    txtPassword.ResetText();
                    string frmLoginCap_UserName = LanguageManager.GetString("notif_frmLogin_UserName");
                    string frmLoginCap_noticeNotFound = LanguageManager.GetString("notif_frmLogin_NotFound");
                    string notification = LanguageManager.GetString("notif_");

                    if (MessageBox.Show(frmLoginCap_UserName + txtUserName.Text + frmLoginCap_noticeNotFound, notification, MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    {
                        this.Hide();
                        frmCreateAccount frm = new frmCreateAccount();
                        frm.ShowDialog();
                    }
                }
            }
        }
    }
}
