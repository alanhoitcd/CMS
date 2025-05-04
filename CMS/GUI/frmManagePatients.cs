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
            using (MemoryStream ms = new MemoryStream(Properties.Resources.iconClose))
            {
                btnClose.Image = Image.FromStream(ms);
            }
            if (UTIL.Language.Lang.Equals("vn"))
            {
                UTIL.UTIL.showDataToDataGridview(dgvManagePatients, "getALlPatients", headTitleVN);
            }
            else
            {
                UTIL.UTIL.showDataToDataGridview(dgvManagePatients, "getALlPatients", headTitleEng);
            }
            //
            // add year
            for (int i = 1900; i <= DateTime.Now.Year + 2; i++)
            {
                cboYear.Items.Add(i);
            }
            cboYear.SelectedItem = 1979;
            // add month
            for (int i = 1; i <= 12; i++)
            {
                cboMonth.Items.Add(i);
            }
            cboMonth.SelectedIndex = 1;
            //
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

        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDay.Items.Clear();
            // Lấy số ngày trong tháng và năm được chọn
            int daysInMonth = DateTime.DaysInMonth(int.Parse(cboYear.SelectedItem.ToString().Trim()), int.Parse(cboMonth.SelectedItem.ToString().Trim()));

            // Thêm các ngày vào ComboBox cboDay
            for (int day = 1; day <= daysInMonth; day++)
            {
                cboDay.Items.Add(day);
            }
            cboDay.SelectedIndex = 0;
        }

        private void lblSocialSecurityNumber_Click(object sender, EventArgs e)
        {

        }
    }
}
