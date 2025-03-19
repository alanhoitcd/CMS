using CMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL
{
    public class Users_BLL
    {
        private Users_DAL Users_DAL_ = new Users_DAL();
        public bool checkUser(string ten_nguoi_dung)
        {
            return Users_DAL_.checkUser(ten_nguoi_dung) > 0;
        }
        public bool checkPassword(string ten_nguoi_dung, string mat_khau)
        {
            return Users_DAL_.checkPassword(ten_nguoi_dung, mat_khau) > 0;
        }
    }
}



