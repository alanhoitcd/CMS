using CMS.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;

namespace CMS.UTIL
{
    public class UTIL
    {
        //hàm kiểm tra chuổi có trong 1 cột của DataTable chưa
        public static Boolean checkModelString(string findString, string collumFind, DataTable dataTableCheck /*dataTableCheck: hàm selectAll*/)
        {   //hàm kiểm tra user có trong database chưa
            DataTable dataTable = dataTableCheck;
            foreach (DataRow row in dataTable.Rows) // row: type DataRow đại diện cho 1 hàng data của bảng dt
            {       //dataTable.Rows: trả về một collection (bộ sưu tập) chứa tất cả các hàng dữ liệu trong bảng dt
                if (row[collumFind].ToString().Equals(findString))
                {
                    return true;
                    break;
                }
            }
            return false;
        }

        //hàm kiểm tra 2 chuổi có trong 2 cột của DataTable chưa
        public static Boolean checkModelString_2_Key(string findString1, string collumFind1, string findString2, string collumFind2, DataTable dataTableCheck /*dataTableCheck: hàm selectAll*/)
        {   //hàm kiểm tra user có trong database chưa
            DataTable dataTable = dataTableCheck;
            foreach (DataRow row in dataTable.Rows) // row: type DataRow đại diện cho 1 hàng data của bảng dt
            {       //dataTable.Rows: trả về một collection (bộ sưu tập) chứa tất cả các hàng dữ liệu trong bảng dt
                if (row[collumFind1].ToString().Equals(findString1) && row[collumFind2].ToString().Equals(findString2))
                {
                    return true;
                    break;
                }
            }
            return false;
        }

        //hàm kiểm tra số int có trong 1 cột của DataTable chưa
        public static Boolean checkModelInt(int findInt, string collumFind, DataTable dataTableCheck /*dataTableCheck: hàm selectAll*/)
        {   //hàm kiểm tra user có trong database chưa
            DataTable dataTable = dataTableCheck;
            foreach (DataRow row in dataTable.Rows) // row: type DataRow đại diện cho 1 hàng data của bảng dt
            {       //dataTable.Rows: trả về một collection (bộ sưu tập) chứa tất cả các hàng dữ liệu trong bảng dt
                if (Convert.ToInt32(row[collumFind]) == findInt)
                {
                    return true;
                }
            }
            return false;
        }

        //hàm show dữ liệu lên DataGridView
        public static void showDataToDataGridview(DataGridView dataGridView, string chuoiQuery, string[] headTitle)
        {
            /*
             * khai báo ngoài hàm để truyền vào hàm
                // Tạo chuổi truy vấn
                string chuoiQuery = "Câu lệnh truy vấn SELECT";
            */
            using (SqlConnection c = new SqlConnection(DAL.sqlDatabase.getConnectString()))
            {
                // tạo đối tượng đưa data vào bảng = class sqlDatabase gọi hàm lấy kết nối sqlConnection getConnection();
                using (SqlDataAdapter sql_DataAdapter = new SqlDataAdapter(chuoiQuery, c))
                {
                    //tạo đối tượng  DataTable để lưu tạm thời kết quả truy vấn sql trước khi đưa lên dataGridView
                    DataTable dataTable = new DataTable();

                    //làm sạch DataTable trước khi đổ dữ liệu vào
                    dataTable.Clear();

                    //đổ dữ liệu từ kết quả truy vấn sql vào một bảng dữ liệu trong bộ nhớ dataTable
                    sql_DataAdapter.Fill(dataTable);

                    //Gán DataGridView = null trước khi đưa dữu liệu vào
                    dataGridView.DataSource = null;

                    //Đưa dữ liệu lên DataGridView
                    dataGridView.DataSource = dataTable;

                    //dặt tên tiêu đề cột
                    for (int i = 0; i < headTitle.Length; i++)
                    {
                        dataGridView.Columns[i].HeaderText = headTitle[i];
                    }

                    //tự động chỉnh size
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    //canh giữa header 
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
        }

        //hàm đưa dữ liệu từ dataTable vô combobox
        public static void AddDataToComboBox(DataTable dataTable, ComboBox comboBox, int collumIndex)
        {
            // Kiểm tra xem DataTable và ComboBox có null không
            if (dataTable == null || comboBox == null)
            {
                return; // Thoát hàm nếu DataTable hoặc ComboBox không hợp lệ
            }

            // Lặp qua từng hàng trong DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                // Lấy giá trị ở cột đầu tiên của hàng hiện tại
                string value = row[collumIndex].ToString();

                // Thêm giá trị vào ComboBox
                comboBox.Items.Add(value);
            }
        }

        //hàm kiểm tra chuổi có phải là số
        public static Boolean checkIsNumber(string stringCheckIsNumber)
        {
            int number;
            return int.TryParse(stringCheckIsNumber, out number);
        }

        //hàm kiểm tra số có nằm trong khoảng min và max
        public static Boolean checkInt(int numCheck, int min, int max)
        {
            return numCheck >= min && numCheck <= max;
        }

        //hàm kiểm tra DateTime
        public static bool checkDateTime(string dateTimeString)
        {
            try
            {
                // Thử chuyển đổi chuỗi thành đối tượng DateTime
                DateTime dateTime = DateTime.Parse(dateTimeString);
                return true;
            }
            catch (FormatException)
            {
                // Nếu xảy ra ngoại lệ FormatException nghĩa là chuỗi không hợp lệ
                return false;
            }
        }

        //hàm kiểm tra chuổi có phải là số nguyên dương không
        public Boolean checkIsNumberPlus(string stringTest)
        {
            try
            {
                int num = int.Parse(stringTest);
                return num >= 0;
            }
            catch
            {
                return false;
            }
        }

        //kiểm tra chuổi có phải số decimal hay không
        public static bool checkIsDecimal(string stringTest)
        {
            decimal number;
            return decimal.TryParse(stringTest, out number);
        }

        // hàm kiểm tra độ dài chuổi trong khoảng min và max
        public static Boolean checkString(string stringCheck, int minlength, int maxlength)
        {
            return stringCheck.Length >= minlength && stringCheck.Length <= maxlength;
        }

        // hàm dành cho event CellClick của Datagridview: lấy dữ liệu từ Datagridview lên textbox
        public static void layDataFromDatagridviewFillTextbox(TextBox textbox, DataGridView dataGridView, int collum, DataGridViewCellEventArgs e)
        {
            //private void dataGridView_Form4_CellClick(object sender, DataGridViewCellEventArgs e)
            //{ // Sự kiện CellClick của DataGridView 
            //    if (e.RowIndex >= 0)
            //    {
            //        txtThanhPho.Text = dataGridView_Form4.Rows[e.RowIndex].Cells[0].Value.ToString();
            //        txtTenThanhPho.Text = dataGridView_Form4.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    }
            //}
            if (e.RowIndex >= 0)
            {
                textbox.Text = dataGridView.Rows[e.RowIndex].Cells[collum].Value.ToString();
            }
        }

        // hàm dành cho event CellClick của Datagridview: lấy dữ liệu từ Datagridview lên COMBOBOX
        public static void layDataFromDatagridviewFillCombobox(ComboBox comboBox, DataGridView dataGridView, int collum, DataGridViewCellEventArgs e)
        {
            //    private void dataGridView_Form4_CellClick(object sender, DataGridViewCellEventArgs e)
            //{ // Sự kiện CellClick của DataGridView 
            //    if (e.RowIndex >= 0)
            //    {
            //        cboMaHoaDon.SelectedItem = dataGridView_frmQuamLyDanhMucChiTietHoaDon.Rows[e.RowIndex].Cells[0].Value.ToString();
            //    }
            //}

            if (e.RowIndex >= 0)
            {
                comboBox.SelectedItem = dataGridView.Rows[e.RowIndex].Cells[collum].Value.ToString();
            }
        }
    }
}
