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
                Patients_DML a = new Patients_DML();
                a.FirstName1 = txtFirstName.Text.Trim();
                a.LastName1 = txtLastName.Text.Trim();
                // Lấy giá trị DateTime từ DateTimePicker
                DateTime selectedDateTime = dtpDateOfBirth.Value;
                //// Chuyển đổi DateTime thành chuỗi với định dạng mong muốn
                //string formattedDateTime = selectedDateTime.ToString("yyyy-MM-dd");
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
    }
}
