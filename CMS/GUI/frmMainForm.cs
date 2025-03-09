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

        private void frmMainForm_Load_()//hàm khi form chạy
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
        }
        //********************************************************************************************//
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            frmMainForm_Load_();
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
            this.Hide();
            f.ShowDialog();
        }
    }
}
