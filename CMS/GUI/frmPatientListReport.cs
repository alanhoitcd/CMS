using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CMS.GUI
{
    public partial class frmPatientListReport : Form
    {
        //code trong class form cần đưa lên tabPage
        private TabPage parentTab; // Lưu tham chiếu đến tab chứa frm1 (Page 1 hoặc Page 2)
        private TabControl tabControl; // Lưu tham chiếu đến TabControl
        public frmPatientListReport(TabPage parentTab, TabControl tabControl)
        {
            InitializeComponent();
            this.parentTab = parentTab;
            this.tabControl = tabControl;
        }
        //========================================
        //hàm tải bảo cáo 
        private void LoadReport(ReportViewer reportViewer1, string sqlQuery, string dataSetName, string itemReportName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DAL.sqlDatabase.getConnectString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("getALlPatients", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Debug: Kiểm tra dữ liệu
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu trong dataTable!");
                    }
                    else
                    {
                        MessageBox.Show($"Có {dataTable.Rows.Count} dòng dữ liệu.");
                    }

                    // Cấu hình ReportViewer
                    reportViewer1.LocalReport.ReportEmbeddedResource = "CMS.Report.PatientListReport.rdlc";
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataTable));

                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        //========================================
        void frmPatientListReport_Load_()
        {
            LoadReport(reportViewer1, "getALlPatients", "DataSet1", "CMS.Report.PatientListReport.rdlc");
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (parentTab != null && tabControl != null)
            {
                tabControl.TabPages.Remove(parentTab); // Xóa tab khỏi TabControl nhưng không dispose
            }
        }

        private void frmPatientListReport_Load(object sender, EventArgs e)
        {
            frmPatientListReport_Load_();
            this.reportViewer1.RefreshReport();
        }
    }
}
