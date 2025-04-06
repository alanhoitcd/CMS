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

namespace CMS.GUI
{
    public partial class frmManagePatients : Form
    {
        //code trong class form cần đưa lên tabPage
        private TabPage parentTab; // Lưu tham chiếu đến tab chứa frm1 (Page 1 hoặc Page 2)
        private TabControl tabControl; // Lưu tham chiếu đến TabControl
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
            if (parentTab != null && tabControl != null)
            {
                tabControl.TabPages.Remove(parentTab); // Xóa tab khỏi TabControl nhưng không dispose
                if (tabControl.TabPages.Count == 0)
                {
                    tabControl.Hide();
                }
                else
                {
                    tabControl.Show();
                }
            }
        }
    }
}
