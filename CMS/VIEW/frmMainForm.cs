using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class frmMainForm : Form
    {
        bool statusDarkMode = false;
        bool statusLangENG = false;
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnScreenMode_Click(object sender, EventArgs e)
        {
            if (!statusDarkMode)
            {
                statusDarkMode = true;
                this.BackColor = Color.Gray;
                btnScreenMode.Image = Image.FromFile(@"D:\_DE_TAI_\CMS\CMS\IMG\iconLightMode.png");
            }
            else
            {
                statusDarkMode = false;
                this.BackColor = Color.WhiteSmoke;
                btnScreenMode.Image = Image.FromFile(@"D:\_DE_TAI_\CMS\CMS\IMG\iconDarkMode.png");
            }
        }

        private void btnLang_Click(object sender, EventArgs e)
        {
            if (!statusLangENG)
            {
                statusLangENG = true;
                btnLang.Image = Image.FromFile(@"D:\_DE_TAI_\CMS\CMS\IMG\iconVietNam.png");
                lblLogan1.Text = "Your health..";
                lblLogan2.Text = "is our happiness";
            }
            else
            {
                statusLangENG = false;
                btnLang.Image = Image.FromFile(@"D:\_DE_TAI_\CMS\CMS\IMG\iconUSA.png");
                lblLogan1.Text = "Sức khỏe của bạn..";
                lblLogan2.Text = "là hạnh phúc của chúng tôi!";
            }
        }
    }
}
