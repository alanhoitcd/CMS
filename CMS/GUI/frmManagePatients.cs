using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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
        private static string[] kindFindEng = { "SSN", "Firt name", "Phone" };
        private static string[] kindFindVN = { "CCCD", "Tên", "Điện thoại" };


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

            //add data combobox kind find
            if (UTIL.Language.Lang.Equals("vn"))
            {
                for (int i = 0; i < kindFindVN.Length; i++)
                {
                    cboKindFind.Items.Add(kindFindVN[i]);
                }
            }
            else
            {
                for (int i = 0; i < kindFindEng.Length; i++)
                {
                    cboKindFind.Items.Add(kindFindEng[i]);
                }
            }
            //thiết lập combobox mặc định cho gender
            cboKindFind.SelectedIndex = 0;
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
            PatientsBLL bll = new PatientsBLL();
            if (bll.checkPatientsBySSN(txtSocialSecurityNumber.Text.Trim()))
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
                    PatientsDML dml = new PatientsDML();
                    dml.FirstName1 = txtFirstName.Text.Trim();
                    dml.LastName1 = txtLastName.Text.Trim();

                    // Lấy giá trị DateTime từ DateTimePicker và gán co ngày sinh
                    DateTime selectedDateTime = dtpDateOfBirth.Value;
                    //// Chuyển đổi DateTime thành chuỗi với định dạng mong muốn
                    //string formattedDateTime = selectedDateTime.ToString("yyyy-MM-dd");
                    dml.DateOfBirth1 = selectedDateTime;

                    dml.Gender1 = cboGender.SelectedItem.ToString().Trim();
                    dml.PhoneNumber1 = txtPhoneNumber.Text.Trim();
                    dml.AddressPatients1 = txtAddressPatients.Text.Trim();
                    dml.SocialSecurityNumber1 = txtSocialSecurityNumber.Text.Trim();

                    PatientsDAL dal = new PatientsDAL();
                    dal.Insert(dml);
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
            PatientsBLL bll = new PatientsBLL();
            if (bll.checkPatientsByID(int.Parse(txtPatientId.Text.Trim())))
            {
                try
                {
                    PatientsDML dml = new PatientsDML();
                    dml.PatientId1 = int.Parse(txtPatientId.Text.Trim());
                    dml.SocialSecurityNumber1 = txtSocialSecurityNumber.Text.Trim();
                    dml.FirstName1 = txtFirstName.Text.Trim();
                    dml.LastName1 = txtLastName.Text.Trim();
                    //DateTime date = dtpDateOfBirth.Value;
                    //string formatDate = date.ToString("MM-dd-yyyy");
                    dml.DateOfBirth1 = dtpDateOfBirth.Value;
                    dml.Gender1 = cboGender.Text.Trim();
                    dml.PhoneNumber1 = txtPhoneNumber.Text.Trim();
                    dml.AddressPatients1 = txtAddressPatients.Text.Trim();

                    PatientsDAL dal = new PatientsDAL();
                    dal.Update(dml);
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

        private void btnDeletePatients_Click(object sender, EventArgs e)
        {
            PatientsBLL bll = new PatientsBLL();
            if (bll.checkPatientsByID(int.Parse(txtPatientId.Text.Trim())))
            {
                try
                {
                    if (MessageBox.Show("Xác nhận xóa?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PatientsDML dml = new PatientsDML();
                        dml.PatientId1 = int.Parse(txtPatientId.Text.Trim());

                        PatientsDAL dal = new PatientsDAL();
                        dal.Delete(dml);
                        MessageBox.Show("Xóa thành công", "Thông báo");
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("đã ra hóa đơn thanh toán, không thể xóa: ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không có mã benh nhan \"" + txtPatientId.Text.Trim() + "\" trong database", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFindPatients_Click(object sender, EventArgs e)
        {
            string[] kindFind = { };

            if (UTIL.Language.Lang.Equals("vn"))
            {
                kindFind = kindFindVN;
            }
            else
            {
                kindFind = kindFindEng;
            }
            //tim
            //lấy vị trí combobox loại tìm kiếm được chọn
            int currentFindText = cboKindFind.SelectedIndex;
            switch (currentFindText)
            {
                case 0: // tim kiem theo cccd
                    PatientsBLL bll = new PatientsBLL();
                    //kiem tra ma sinh vien null
                    if (string.IsNullOrEmpty(txtFindText.Text)) // kiem tra textbox tim kiem co nhap khong
                    {
                        MessageBox.Show("Vui lòng nhập cccd để tìm benh nhan!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (bll.checkPatientsBySSN(txtFindText.Text.Trim()))
                        {
                            try
                            {
                                PatientsDML dml = new PatientsDML();
                                dml.SocialSecurityNumber1 = txtFindText.Text.Trim();

                                //khai báo 1 mdoel sinh vien khác để lưu thông tin sinh vien có mã sv là g đã set ở trên
                                PatientsDAL dal = new PatientsDAL();
                                PatientsDML dmlResult = dal.SelectBySSN(dml);

                                txtPatientId.Text = dmlResult.PatientId1.ToString();
                                txtFirstName.Text = dmlResult.FirstName1.ToString();
                                txtLastName.Text = dmlResult.LastName1.ToString();
                                dtpDateOfBirth.Value = DateTime.Parse(dmlResult.DateOfBirth1.ToString().Trim());
                                cboGender.SelectedItem = dmlResult.Gender1.ToString();
                                txtPhoneNumber.Text = dmlResult.PhoneNumber1.ToString();
                                txtAddressPatients.Text = dmlResult.AddressPatients1.ToString();
                                txtSocialSecurityNumber.Text = dmlResult.SocialSecurityNumber1.ToString();



                                // Tìm và chọn dòng trong DataGridView
                                foreach (DataGridViewRow row in dgvManagePatients.Rows)
                                {
                                    if (row.Cells["PatientId"].Value?.ToString() == dmlResult.PatientId1.ToString()) // Giả sử cột MaSv tên là "MaSv"
                                    {
                                        row.Selected = true; // Chọn dòng
                                        dgvManagePatients.CurrentCell = row.Cells[0]; // Đặt con trỏ vào ô đầu tiên của dòng
                                        dgvManagePatients.FirstDisplayedScrollingRowIndex = row.Index; // Cuộn đến dòng được chọn
                                        break;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Lỗi tại class frmPatients.cs hàm btnTimKiem_Click(object sender, EventArgs e): " + ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không có mã benh nhan \"" + txtSocialSecurityNumber.Text.Trim() + "\" trong database", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
                case 1: // tim kiem theo tên
                    PatientsBLL bll1 = new PatientsBLL();
                    //kiem tra ma sinh vien null
                    if (string.IsNullOrEmpty(txtFindText.Text)) // kiem tra textbox tim kiem co nhap khong
                    {
                        MessageBox.Show("Vui lòng nhập ten để tìm benh nhan!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (bll1.checkPatientsByFirstName(txtFindText.Text.Trim()))
                        {
                            PatientsDML dml = new PatientsDML();
                            dml.FirstName1 = txtFindText.Text.Trim();


                            txtPatientId.Text = "";
                            txtFirstName.Text = "";
                            txtLastName.Text = "";
                            cboGender.SelectedItem = "";
                            txtPhoneNumber.Text = "";
                            txtAddressPatients.Text = "";
                            txtSocialSecurityNumber.Text = "";

                            if (UTIL.Language.Lang.Equals("vn"))
                            {
                                string storedProcedureName = "getALlPatientsByFirstName";
                                // Tạo chuỗi truy vấn để gọi stored procedure
                                string chuoiQuery = $"EXEC {storedProcedureName} @FirstName = '{txtFindText.Text.Trim()}'";

                                UTIL.UTIL.showDataToDataGridview(dgvManagePatients, chuoiQuery, headTitleVN);
                            }
                            else
                            {
                                string storedProcedureName = "getALlPatientsByFirstName";
                                // Tạo chuỗi truy vấn để gọi stored procedure
                                string chuoiQuery = $"EXEC {storedProcedureName} @FirstName = '{txtFindText.Text.Trim()}'";

                                UTIL.UTIL.showDataToDataGridview(dgvManagePatients, chuoiQuery, headTitleEng);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không có mã benh nhan co ten\"" + txtFindText.Text.Trim() + "\" trong database", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
                case 2: // tim kiem theo số điện thoại
                    PatientsBLL bll2 = new PatientsBLL();
                    //kiem tra ma sinh vien null
                    if (string.IsNullOrEmpty(txtFindText.Text)) // kiem tra textbox tim kiem co nhap khong
                    {
                        MessageBox.Show("Vui lòng nhập so phone để tìm benh nhan!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (bll2.checkPatientsByPhoneNumber(txtFindText.Text.Trim()))
                        {
                            try
                            {
                                PatientsDML dml = new PatientsDML();
                                dml.PhoneNumber1 = txtFindText.Text.Trim();

                                //khai báo 1 mdoel sinh vien khác để lưu thông tin sinh vien có mã sv là g đã set ở trên
                                PatientsDAL dal = new PatientsDAL();
                                PatientsDML dmlResult = dal.SelectByPhoneNumber(dml);

                                txtPatientId.Text = dmlResult.PatientId1.ToString();
                                txtFirstName.Text = dmlResult.FirstName1.ToString();
                                txtLastName.Text = dmlResult.LastName1.ToString();
                                dtpDateOfBirth.Value = DateTime.Parse(dmlResult.DateOfBirth1.ToString().Trim());
                                cboGender.SelectedItem = dmlResult.Gender1.ToString();
                                txtPhoneNumber.Text = dmlResult.PhoneNumber1.ToString();
                                txtAddressPatients.Text = dmlResult.AddressPatients1.ToString();
                                txtSocialSecurityNumber.Text = dmlResult.SocialSecurityNumber1.ToString();



                                // Tìm và chọn dòng trong DataGridView
                                foreach (DataGridViewRow row in dgvManagePatients.Rows)
                                {
                                    if (row.Cells["PhoneNumber"].Value?.ToString() == dmlResult.PhoneNumber1.ToString()) // Giả sử cột MaSv tên là "MaSv"
                                    {
                                        row.Selected = true; // Chọn dòng
                                        dgvManagePatients.CurrentCell = row.Cells[0]; // Đặt con trỏ vào ô đầu tiên của dòng
                                        dgvManagePatients.FirstDisplayedScrollingRowIndex = row.Index; // Cuộn đến dòng được chọn
                                        break;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Lỗi tại class frmPatients.cs hàm btnTimKiem_Click(object sender, EventArgs e): " + ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không có sdt cua benh nhan \"" + txtFindText.Text.Trim() + "\" trong database", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
                default:
                    break;
            }

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
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
