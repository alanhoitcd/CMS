using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS.GUI
{
    public partial class frmTest: Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            string[] s = { "Id", "Họ tên", "chuyên khoa", "số điện thoại", "số giấy phép" };
            UTIL.UTIL.showDataToDataGridview(dataGridView1, "select * from bac_si", s);
        }
    }
}
