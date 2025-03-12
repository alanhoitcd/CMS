create database CMS

-- Tạo bảng bac_si
CREATE TABLE bac_si (
    id_bac_si INT IDENTITY(1,1) PRIMARY KEY,
    ho_ten NVARCHAR(100) NOT NULL,
    chuyen_khoa NVARCHAR(50) NOT NULL,
    so_dien_thoai VARCHAR(20) NOT NULL,
    so_giay_phep VARCHAR(50) NOT NULL
);

-- Tạo bảng nguoi_dung
CREATE TABLE nguoi_dung (
    id_nguoi_dung INT IDENTITY(1,1) PRIMARY KEY,
    ten_nguoi_dung VARCHAR(20) UNIQUE NOT NULL,
    mat_khau VARCHAR(50) NOT NULL,
    ho_va_ten NVARCHAR(100) NOT NULL,
    quyen INT NOT NULL,
    id_bac_si INT NOT NULL,
    so_dien_thoai VARCHAR(20),
    email VARCHAR(100) UNIQUE,
    trang_thai BIT NOT NULL,
    FOREIGN KEY (id_bac_si) REFERENCES bac_si(id_bac_si)
);

--Nhập dữ liệu bac_si
INSERT INTO bac_si (ho_ten, chuyen_khoa, so_dien_thoai, so_giay_phep) VALUES (N'Nguyễn Văn A', N'Nội khoa', '0901234567', '1234567890');
INSERT INTO bac_si (ho_ten, chuyen_khoa, so_dien_thoai, so_giay_phep) VALUES (N'Trần Thị B', N'Ngoại khoa', '0912345678', '2345678901');
INSERT INTO bac_si (ho_ten, chuyen_khoa, so_dien_thoai, so_giay_phep) VALUES (N'Lê Hoàng C', N'Răng hàm mặt', '0923456789', '3456789012');
INSERT INTO bac_si (ho_ten, chuyen_khoa, so_dien_thoai, so_giay_phep) VALUES (N'Phạm Thu D', N'Da liễu', '0934567890', '4567890123');
INSERT INTO bac_si (ho_ten, chuyen_khoa, so_dien_thoai, so_giay_phep) VALUES (N'Vũ Minh E', N'Tai mũi họng', '0945678901', '5678901234');
INSERT INTO bac_si (ho_ten, chuyen_khoa, so_dien_thoai, so_giay_phep) VALUES (N'Hoàng Thị F', N'Mắt', '0956789012', '6789012345');
INSERT INTO bac_si (ho_ten, chuyen_khoa, so_dien_thoai, so_giay_phep) VALUES (N'Đặng Quốc G', N'Nhi khoa', '0967890123', '7890123456');
INSERT INTO bac_si (ho_ten, chuyen_khoa, so_dien_thoai, so_giay_phep) VALUES (N'Bùi Thanh H', N'Sản phụ khoa', '0978901234', '8901234567');
INSERT INTO bac_si (ho_ten, chuyen_khoa, so_dien_thoai, so_giay_phep) VALUES (N'Cao Xuân I', N'Tim mạch', '0989012345', '9012345678');
INSERT INTO bac_si (ho_ten, chuyen_khoa, so_dien_thoai, so_giay_phep) VALUES (N'Đỗ Thị K', N'Thần kinh', '0990123456', '0123456789');

--Nhập dữ liệu nguoi_dung
INSERT INTO nguoi_dung (ten_nguoi_dung, mat_khau, ho_va_ten, quyen, id_bac_si, so_dien_thoai, email, trang_thai) VALUES ('admin', 'admin', N'admin', 1, 1, '0000000000', 'admin@example.com', 1);
INSERT INTO nguoi_dung (ten_nguoi_dung, mat_khau, ho_va_ten, quyen, id_bac_si, so_dien_thoai, email, trang_thai) VALUES ('nguyena', '12345678', N'Nguyễn Văn An', 1, 1, '0901111111', 'nguyena@example.com', 1);
INSERT INTO nguoi_dung (ten_nguoi_dung, mat_khau, ho_va_ten, quyen, id_bac_si, so_dien_thoai, email, trang_thai) VALUES ('tranb', 'abcdefgh', N'Trần Thị Bình', 2, 2, '0912222222', 'tranb@example.com', 1);
INSERT INTO nguoi_dung (ten_nguoi_dung, mat_khau, ho_va_ten, quyen, id_bac_si, so_dien_thoai, email, trang_thai) VALUES ('lehoangc', 'password123', N'Lê Hoàng Công', 1, 3, '0923333333', 'lehoangc@example.com', 0);
INSERT INTO nguoi_dung (ten_nguoi_dung, mat_khau, ho_va_ten, quyen, id_bac_si, so_dien_thoai, email, trang_thai) VALUES ('phamthud', 'securepass', N'Phạm Thu Dung', 3, 4, '0934444444', 'phamthud@example.com', 1);
INSERT INTO nguoi_dung (ten_nguoi_dung, mat_khau, ho_va_ten, quyen, id_bac_si, so_dien_thoai, email, trang_thai) VALUES ('vuminhe', 'mypassword', N'Vũ Minh Em', 2, 5, '0945555555', 'vuminhe@example.com', 0);
INSERT INTO nguoi_dung (ten_nguoi_dung, mat_khau, ho_va_ten, quyen, id_bac_si, so_dien_thoai, email, trang_thai) VALUES ('hoangthif', '123qwerty', N'Hoàng Thị Phương', 1, 6, '0956666666', 'hoangthif@example.com', 1);
INSERT INTO nguoi_dung (ten_nguoi_dung, mat_khau, ho_va_ten, quyen, id_bac_si, so_dien_thoai, email, trang_thai) VALUES ('dangquocg', 'pass1234', N'Đặng Quốc Giang', 3, 7, '0967777777', 'dangquocg@example.com', 0);
INSERT INTO nguoi_dung (ten_nguoi_dung, mat_khau, ho_va_ten, quyen, id_bac_si, so_dien_thoai, email, trang_thai) VALUES ('buithanhh', 'mysecret', N'Bùi Thanh Hiền', 2, 8, '0978888888', 'buithanhh@example.com', 1);
INSERT INTO nguoi_dung (ten_nguoi_dung, mat_khau, ho_va_ten, quyen, id_bac_si, so_dien_thoai, email, trang_thai) VALUES ('caoxuani', 'password567', N'Cao Xuân Ích', 1, 9, '0989999999', 'caoxuani@example.com', 0);
INSERT INTO nguoi_dung (ten_nguoi_dung, mat_khau, ho_va_ten, quyen, id_bac_si, so_dien_thoai, email, trang_thai) VALUES ('dothik', 'secure123', N'Đỗ Thị Kim', 3, 10, '0990000000', 'dothik@example.com', 1);

select * from bac_si