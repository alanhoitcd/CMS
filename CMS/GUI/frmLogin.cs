using CMS.BLL;
using CMS.GUI;
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

namespace CMS.VIEW
{
    public partial class frmLogin : Form
    {
        private static int countSaiPass = 0;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconClose))
            {
                btnClose.Image = Image.FromStream(ms);
            }
            txtPassword.Text = "admin";
            txtUserName.Text = "admin";

            //chèn ảnh 
            using (MemoryStream ms = new MemoryStream(Properties.Resources.imgfrmLoginForm))
            {
                ptbLogin.Image = Image.FromStream(ms);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            NguoiDung_BLL NguoiDung_BLL_ = new NguoiDung_BLL();
            if (NguoiDung_BLL_.checkUser(txtUserName.Text)) //kiểm tra id có trong database chưa
            {
                if (NguoiDung_BLL_.checkPassword(txtUserName.Text, txtPassword.Text)) //kiểm tra mật khẩu đúng
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo");
                    this.DialogResult = DialogResult.OK;
                    countSaiPass = 0;
                }
                else
                {
                    if (countSaiPass <= 2)
                    {
                        MessageBox.Show("sai password " + (countSaiPass + 1) + " lần", "Thông Báo");
                        countSaiPass++;
                        txtPassword.ResetText();
                        if (countSaiPass == 3)
                        {
                            txtPassword.Enabled = false;
                            MessageBox.Show("Đã nhập sai 3 lần, thoát app, byeeeeeeeeeeee", "Thông Báo");
                            this.DialogResult = DialogResult.Cancel;
                            Application.Exit();
                        }
                    }
                }
            }
            else
            {
                txtUserName.ResetText();
                txtPassword.ResetText();
                if (MessageBox.Show("user " + txtUserName.Text + " không đúng, bạn có muốn tạo user mới không?", "THÔNG BÁO", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    this.Hide();
                    frmCreateAccount frm = new frmCreateAccount();
                    frm.ShowDialog();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCreateAccount f = new frmCreateAccount();
            f.ShowDialog();

        }
    }
}
