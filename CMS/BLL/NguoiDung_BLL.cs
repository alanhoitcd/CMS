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
    public class NguoiDung_BLL
    {
        private NguoiDung_DAL nguoiDung_DAL = new NguoiDung_DAL();

        public bool CheckUser(int id_nguoi_dung)
        {
            return nguoiDung_DAL.CheckUser(id_nguoi_dung) > 0;
        }
    }
}



