using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMS.BLL;
using CMS.DAL;
using CMS.DML;

namespace CMS.GUI
{
    public partial class frmManagePatients : Form
    {
        //code trong class form cần đưa lên tabPage
        private TabPage parentTab; // Lưu tham chiếu đến tab chứa frm1 (Page 1 hoặc Page 2)
        private TabControl tabControl; // Lưu tham chiếu đến TabControl
        private string[] genderEN = { "Male", "Female" };
        private string[] genderVN = { "Nam", "Nữ" };
        private string[] headTitleEng = { "Patient ID", "First Name", "Last Name", "Date Of Birth", "Gender", "Phone Number", "Address", "Social Security Number" };
        private string[] headTitleVN = { "Mã Bệnh Nhân", "Tên", "Họ Lót", "Ngày Sinh", "Giới Tính", "Số Điện Thoại", "Địa Chỉ", "Số Căn Cước" };
        public frmManagePatients(TabPage parentTab, TabControl tabControl)
        {
            InitializeComponent();
            this.parentTab = parentTab;
            this.tabControl = tabControl;
        }

        void frmManagePatients_Load_()
        {
            //chèn ảnh cho nut thoát
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconClose))
            {
                btnClose.Image = Image.FromStream(ms);
            }

            //thiết lập ngôn ngữ cho header datagridview và load dữ liệu lên form khi form load
            if (UTIL.Language.Lang.Equals("vn"))
            {
                dgvManagePatients.Rows.Clear();
                UTIL.UTIL.showDataToDataGridview(dgvManagePatients, "getALlPatients", headTitleVN);
            }
            else
            {
                dgvManagePatients.Rows.Clear();
                UTIL.UTIL.showDataToDataGridview(dgvManagePatients, "getALlPatients", headTitleEng);
            }

            //add data combobox gender
            if (UTIL.Language.Lang.Equals("vn"))
            {
                for (int i = 0; i < genderVN.Length; i++)
                {
                    cboGender.Items.Add(genderVN[i]);
                }
            }
            else
            {
                for (int i = 0; i < genderEN.Length; i++)
                {
                    cboGender.Items.Add(genderEN[i]);
                }
            }
            //thiết lập combobox mặc định cho gender
            cboGender.SelectedIndex = 0;
        }
        //

        public frmManagePatients()
        {
            InitializeComponent();
        }

        private void frmManagePatients_Load(object sender, EventArgs e)
        {
            frmManagePatients_Load_();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //if (parentTab != null && tabControl != null)
            //{
            //    tabControl.TabPages.Remove(parentTab); // Xóa tab khỏi TabControl nhưng không dispose
            //}
        }

        private void btnAddPatients_Click(object sender, EventArgs e)
        {
            PatientsBLL t = new PatientsBLL();
            if (t.checkPatientsBySSN(txtSocialSecurityNumber.Text.Trim()))
            {
                MessageBox.Show(txtSocialSecurityNumber.Text + " is available", "Notif");
            }
            else
            {
                if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text) || string.IsNullOrEmpty(txtSocialSecurityNumber.Text))
                {
                    MessageBox.Show("First name, last name and social security number is not null", "Notif", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    PatientsDML a = new PatientsDML();
                    a.FirstName1 = txtFirstName.Text.Trim();
                    a.LastName1 = txtLastName.Text.Trim();

                    // Lấy giá trị DateTime từ DateTimePicker và gán co ngày sinh
                    DateTime selectedDateTime = dtpDateOfBirth.Value;
                    //// Chuyển đổi DateTime thành chuỗi với định dạng mong muốn
                    //string formattedDateTime = selectedDateTime.ToString("yyyy-MM-dd");
                    a.DateOfBirth1 = selectedDateTime;

                    a.Gender1 = cboGender.SelectedItem.ToString().Trim();
                    a.PhoneNumber1 = txtPhoneNumber.Text.Trim();
                    a.AddressPatients1 = txtAddressPatients.Text.Trim();
                    a.SocialSecurityNumber1 = txtSocialSecurityNumber.Text.Trim();

                    PatientsDAL PatientsDAL_ = new PatientsDAL();
                    PatientsDAL_.Insert(a);
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (UTIL.Language.Lang.Equals("vn"))
                    {
                        UTIL.UTIL.showDataToDataGridview(dgvManagePatients, "getALlPatients", headTitleVN);
                    }
                    else
                    {
                        UTIL.UTIL.showDataToDataGridview(dgvManagePatients, "getALlPatients", headTitleEng);
                    }
                }
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblSocialSecurityNumber_Click(object sender, EventArgs e)
        {

        }

        private void dgvManagePatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UTIL.UTIL.getDataFromDatagridviewFillTextbox(txtPatientId, dgvManagePatients, 0, e);
            UTIL.UTIL.getDataFromDatagridviewFillTextbox(txtFirstName, dgvManagePatients, 1, e);
            UTIL.UTIL.getDataFromDatagridviewFillTextbox(txtLastName, dgvManagePatients, 2, e);
            UTIL.UTIL.getDataFromDatagridviewFillDateTimePicker(dtpDateOfBirth, dgvManagePatients, 3, e);
            UTIL.UTIL.getDataFromDatagridviewFillCombobox(cboGender, dgvManagePatients, 4, e);
            UTIL.UTIL.getDataFromDatagridviewFillTextbox(txtPhoneNumber, dgvManagePatients, 5, e);
            UTIL.UTIL.getDataFromDatagridviewFillTextbox(txtAddressPatients, dgvManagePatients, 6, e);
            UTIL.UTIL.getDataFromDatagridviewFillTextbox(txtSocialSecurityNumber, dgvManagePatients, 7, e);

        }

        private void dgvManagePatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditPatients_Click(object sender, EventArgs e)
        {
            PatientsBLL PatientsBLL_ = new PatientsBLL();
            if (PatientsBLL_.checkPatientsByID(int.Parse(txtPatientId.Text.Trim())))
            {
                try
                {
                    PatientsDML t = new PatientsDML();
                    t.PatientId1 = int.Parse(txtPatientId.Text.Trim());
                    t.SocialSecurityNumber1 = txtSocialSecurityNumber.Text.Trim();
                    t.FirstName1 = txtFirstName.Text.Trim();
                    t.LastName1 = txtLastName.Text.Trim();
                    //DateTime date = dtpDateOfBirth.Value;
                    //string formatDate = date.ToString("MM-dd-yyyy");
                    t.DateOfBirth1 = dtpDateOfBirth.Value;
                    t.Gender1 = cboGender.Text.Trim();
                    t.PhoneNumber1 = txtPhoneNumber.Text.Trim();
                    t.AddressPatients1 = txtAddressPatients.Text.Trim();

                    PatientsDAL u = new PatientsDAL();
                    u.Update(t);
                    MessageBox.Show("Chỉnh sửa thành công bệnh nhân \"" + txtPatientId.Text.Trim() + "\"", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //thiết lập ngôn ngữ cho header datagridview và load dữ liệu lên form khi form load
                    if (UTIL.Language.Lang.Equals("vn"))
                    {
                        UTIL.UTIL.showDataToDataGridview(dgvManagePatients, "getALlPatients", headTitleVN);
                    }
                    else
                    {
                        UTIL.UTIL.showDataToDataGridview(dgvManagePatients, "getALlPatients", headTitleEng);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Chưa có benh nhan \"" + txtSocialSecurityNumber.Text.Trim() + "\" trong database", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Kiểm tra xem độ dài văn bản hiện tại đã đạt đến giới hạn (5 ký tự) hay chưa
            if (textBox.Text.Length >= 50 && !char.IsControl(e.KeyChar))
            {
                // Nếu đã đạt giới hạn và ký tự vừa nhập không phải là phím điều khiển (ví dụ: Backspace),
                // thì hủy bỏ sự kiện KeyPress, ngăn không cho ký tự được nhập vào TextBox.
                e.Handled = true;
            }
        }

        private void txtSocialSecurityNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự vừa nhập có phải là số hoặc các phím điều khiển đặc biệt (ví dụ: Backspace) hay không
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu không phải số và không phải phím điều khiển, hủy bỏ sự kiện KeyPress
                e.Handled = true;
            }
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Kiểm tra xem độ dài văn bản hiện tại đã đạt đến giới hạn (5 ký tự) hay chưa
            if (textBox.Text.Length >= 50 && !char.IsControl(e.KeyChar))
            {
                // Nếu đã đạt giới hạn và ký tự vừa nhập không phải là phím điều khiển (ví dụ: Backspace),
                // thì hủy bỏ sự kiện KeyPress, ngăn không cho ký tự được nhập vào TextBox.
                e.Handled = true;
            }
        }

        private void txtAddressPatients_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Kiểm tra xem độ dài văn bản hiện tại đã đạt đến giới hạn (5 ký tự) hay chưa
            if (textBox.Text.Length >= 100 && !char.IsControl(e.KeyChar))
            {
                // Nếu đã đạt giới hạn và ký tự vừa nhập không phải là phím điều khiển (ví dụ: Backspace),
                // thì hủy bỏ sự kiện KeyPress, ngăn không cho ký tự được nhập vào TextBox.
                e.Handled = true;
            }
        }
    }
}
