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

        //********************************************************************************************//
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {

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
    }
}
