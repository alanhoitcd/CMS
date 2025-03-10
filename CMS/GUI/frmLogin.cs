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
            //code button dang nhap

            if (txtUserName.Text.Equals("admin"))
            {
                if (txtUserName.Text.Equals("admin"))
                {
                    if (txtPassword.Text.Equals("admin"))
                    {
                        MessageBox.Show("Đăng nhập thành công", "Thông báo");
                        this.DialogResult = DialogResult.OK;
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
                                //txtPassword.Enabled = false;
                                MessageBox.Show("Đã nhập sai 3 lần, thoát app, byeeeeeeeeeeee", "Thông Báo");
                                this.DialogResult = DialogResult.Cancel;
                                Application.Exit();
                            }
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

            //if(txtUser.Text.Equals(txtPassword.Text))
            //{
            //    this.DialogResult = DialogResult.OK;
            //    //Form1 form1 = new Form1();
            //    //form1.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Không đúng tên người dùng/mật khẩu !!!");
            //    this.DialogResult = DialogResult.Cancel;
            //}



















            //if (txtUserName.Text.Equals(txtPassword.Text))
            //{
            //    //modelUsers ad = new modelUsers();
            //    //ad.UserName = txtUser.Text;
            //    //modelUsers k = dao_users.selectByID(ad);
            //    if (txtUserName.Text != txtPassword.Text)
            //    {
            //        if (txtUserName.Text.Equals(txtPassword.Text))
            //        {
            //            MessageBox.Show("Đăng nhập thành công", "Thông báo");
            //            //userLogin = txtUser.Text;
            //            this.DialogResult = DialogResult.OK;
            //        }
            //        else
            //        {
            //            if (countSaiPass < 2)
            //            {
            //                MessageBox.Show("sai password " + (countSaiPass + 1) + " lần", "Thông Báo");
            //                countSaiPass++;
            //                txtPassword.ResetText();
            //                if (countSaiPass == 2)
            //                {
            //                    txtPassword.Enabled = false;
            //                    MessageBox.Show("Đã nhập sai 3 lần, thoát app, byeeeeeeeeeeee", "Thông Báo");
            //                    this.DialogResult = DialogResult.Cancel;
            //                    Application.Exit();
            //                }
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    txtUserName.ResetText();
            //    txtPassword.ResetText();
            //    if (MessageBox.Show("user " + txtUserName.Text + " không đúng, bạn có muốn tạo user mới không?", "THÔNG BÁO", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            //    {
            //        this.Hide();
            //        frmCreateAccount frm = new frmCreateAccount();
            //        frm.ShowDialog();
            //    }
            //}
        }
    }
}
