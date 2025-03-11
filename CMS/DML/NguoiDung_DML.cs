using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DML
{
    public class NguoiDung_DML
    {
        /*      id_nguoi_dung INT IDENTITY(1,1) PRIMARY KEY,
                ten_nguoi_dung VARCHAR(20) UNIQUE NOT NULL,
                mat_khau VARCHAR(50) NOT NULL,
                ho_va_ten NVARCHAR(100) NOT NULL,
                quyen INT NOT NULL,
                id_bac_si INT NOT NULL,
                so_dien_thoai VARCHAR(20),
                email VARCHAR(100) UNIQUE,
                trang_thai BIT NOT NULL,*/
        private int id_nguoi_dung;
        private string ten_nguoi_dung;
        private string mat_khau;
        private string ho_va_ten;
        private int quyen;
        private int id_bac_si;
        private string so_dien_thoai;
        private string email;
        private bool trang_thai;

        public int Id_nguoi_dung { get => id_nguoi_dung; set => id_nguoi_dung = value; }
        public string Ten_nguoi_dung { get => ten_nguoi_dung; set => ten_nguoi_dung = value; }
        public string Mat_khau { get => mat_khau; set => mat_khau = value; }
        public string Ho_va_ten { get => ho_va_ten; set => ho_va_ten = value; }
        public int Quyen { get => quyen; set => quyen = value; }
        public int Id_bac_si { get => id_bac_si; set => id_bac_si = value; }
        public string So_dien_thoai { get => so_dien_thoai; set => so_dien_thoai = value; }
        public string Email { get => email; set => email = value; }
        public bool Trang_thai { get => trang_thai; set => trang_thai = value; }

        public NguoiDung_DML(int id_nguoi_dung, string ten_nguoi_dung, string mat_khau, string ho_va_ten,
            int quyen, int id_bac_si, string so_dien_thoai, string email, bool trang_thai)
        {
            this.Id_nguoi_dung = id_nguoi_dung;
            this.Ten_nguoi_dung = ten_nguoi_dung;
            this.Mat_khau = mat_khau;
            this.Ho_va_ten = ho_va_ten;
            this.Quyen = quyen;
            this.Id_bac_si = id_bac_si;
            this.So_dien_thoai = so_dien_thoai;
            this.Email = email;
            this.Trang_thai = trang_thai;
        }

        public NguoiDung_DML()
        {
        }
    }
}
