CREATE DATABASE CMS

CREATE TABLE Patients_BenhNhan(
	PatientID (PK, int, IDENTITY/INTEGER PRIMARY KEY AUTOINCREMENT)
	HoTen (nvarchar)
	Tuoi (int)
	GioiTinh (nvarchar)
	DiaChi (nvarchar)
	SoDienThoai (nvarchar)
	GhiChu (nvarchar)
)

CREATE TABLE Visits_LanKham(
	VisitID (PK, int, IDENTITY/INTEGER PRIMARY KEY AUTOINCREMENT)
	PatientID (FK, int, liên kết tới Patients)
	DoctorID (FK, int, liên kết tới Doctors)
	NgayKham (datetime)
	TrieuChung (nvarchar)
	ChanDoan (nvarchar)
)

CREATE TABLE Doctors_BacSi(
	DoctorID (PK, int, IDENTITY/INTEGER PRIMARY KEY AUTOINCREMENT)
	HoTen (nvarchar)
	ChuyenKhoa (nvarchar)
	SoDienThoai (nvarchar)
)

CREATE TABLE Prescriptions_DonThuoc(
	PrescriptionID (PK, int, IDENTITY/INTEGER PRIMARY KEY AUTOINCREMENT)
	VisitID (FK, int, liên kết tới Visits)
	NgayKeDon (datetime)
)

CREATE TABLE PrescriptionDetails_ChiTietDonThuoc(
	PrescriptionDetailID (PK, int, IDENTITY/INTEGER PRIMARY KEY AUTOINCREMENT)
	PrescriptionID (FK, int, liên kết tới Prescriptions)
	MedicineID (FK, int, liên kết tới MedicineInventory)
	SoLuong (int)
	DonVi (nvarchar)
	CachDung (nvarchar)
)

CREATE TABLE Appointments_LichHen(
	AppointmentID (PK, int, IDENTITY/INTEGER PRIMARY KEY AUTOINCREMENT)
	PatientID (FK, int, liên kết tới Patients)
	DoctorID (FK, int, liên kết tới Doctors)
	NgayHen (datetime)
	TrangThai (nvarchar, ví dụ: “Chưa khám”, “Đã khám”, “Hủy”)
)

CREATE TABLE Users_NguoiDung(
UserID (PK, int, IDENTITY/INTEGER PRIMARY KEY AUTOINCREMENT)
Username (nvarchar)
Password (nvarchar)
FullName (nvarchar)
Role (nvarchar)
DoctorID (FK, int, lien ket den Doctors – tuy chon)
SoDienThoai(nvarchar)
Email (nvarchar)
IsActive (bit)
)