create database CMS

CREATE TABLE Patients (
    PatientId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    PhoneNumber NVARCHAR(15) NOT NULL,
    Address NVARCHAR(100) NOT NULL,
    SocialSecurityNumber NVARCHAR(11) NULL,
    IsEncrypted BIT DEFAULT 0 NOT NULL
);

CREATE TABLE Doctors (
    DoctorId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Specialty NVARCHAR(50) NOT NULL,
    LicenseNumber NVARCHAR(20) NOT NULL,
    Schedule NVARCHAR(100) NOT NULL
);

CREATE TABLE Staff (
    StaffId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    Contact NVARCHAR(15) NOT NULL,
    HireDate DATE NOT NULL
);

CREATE TABLE Suppliers (
    SupplierId INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName NVARCHAR(100) NOT NULL,
    ContactPerson NVARCHAR(50) NOT NULL,
    Phone NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);

CREATE TABLE Labs (
    LabId INT IDENTITY(1,1) PRIMARY KEY,
    LabName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200) NOT NULL
);

CREATE TABLE Appointments (
    AppointmentId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    AppointmentDate DATETIME NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);

CREATE TABLE Visits (
    VisitId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    StaffId INT NULL,
    AppointmentId INT NULL,
    VisitDate DATETIME NOT NULL,
    ChiefComplaint NVARCHAR(200) NOT NULL,
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId),
    FOREIGN KEY (StaffId) REFERENCES Staff(StaffId),
    FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId)
);

CREATE TABLE VitalSigns (
    VitalSignId INT IDENTITY(1,1) PRIMARY KEY,
    VisitId INT NOT NULL,
    BloodPressure NVARCHAR(10) NOT NULL,
    HeartRate INT NOT NULL,
    Temperature DECIMAL(5,2) NOT NULL,
    Weight DECIMAL(5,2) NOT NULL,
    Height DECIMAL(5,2) NOT NULL,
    RecordDate DATETIME NOT NULL,
    FOREIGN KEY (VisitId) REFERENCES Visits(VisitId)
);

CREATE TABLE MedicalRecords (
    MedicalRecordId INT IDENTITY(1,1) PRIMARY KEY,
    VisitId INT NOT NULL,
    Diagnosis NVARCHAR(200) NOT NULL,
    ClinicalNotes NVARCHAR(500) NOT NULL,
    RecordDate DATETIME NOT NULL,
    IsEncrypted BIT DEFAULT 0 NOT NULL,
    FOREIGN KEY (VisitId) REFERENCES Visits(VisitId)
);

CREATE TABLE Prescriptions (
    PrescriptionId INT IDENTITY(1,1) PRIMARY KEY,
    VisitId INT NOT NULL,
    PrescriptionDate DATETIME NOT NULL,
    Instructions NVARCHAR(200) NOT NULL,
    FOREIGN KEY (VisitId) REFERENCES Visits(VisitId)
);

CREATE TABLE MedicineInventory (
    MedicineId INT IDENTITY(1,1) PRIMARY KEY,
    MedicineName NVARCHAR(100) NOT NULL,
    SupplierId INT NOT NULL,
    QuantityInStock INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    ExpirationDate DATE NOT NULL,
    BatchNumber NVARCHAR(50) NOT NULL,
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(SupplierId)
);

CREATE TABLE PrescriptionDetails (
    PrescriptionDetailId INT IDENTITY(1,1) PRIMARY KEY,
    PrescriptionId INT NOT NULL,
    MedicineId INT NOT NULL,
    Dosage NVARCHAR(50) NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (PrescriptionId) REFERENCES Prescriptions(PrescriptionId),
    FOREIGN KEY (MedicineId) REFERENCES MedicineInventory(MedicineId)
);

CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    SupplierId INT NOT NULL,
    MedicineId INT NOT NULL,
    Quantity INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    DeliveryDate DATETIME NULL,
    Status NVARCHAR(20) NOT NULL,
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(SupplierId),
    FOREIGN KEY (MedicineId) REFERENCES MedicineInventory(MedicineId)
);

CREATE TABLE InventoryTransactions (
    TransactionId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NULL,
    MedicineId INT NOT NULL,
    TransactionType NVARCHAR(20) NOT NULL,
    Quantity INT NOT NULL,
    TransactionDate DATETIME NOT NULL,
    Description NVARCHAR(200) NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (MedicineId) REFERENCES MedicineInventory(MedicineId)
);

CREATE TABLE Invoices (
    InvoiceId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    InvoiceType NVARCHAR(20) NOT NULL,
    PrescriptionId INT NULL,
    VisitId INT NULL,
    TotalAmount DECIMAL(10,2) NOT NULL,
    InvoiceDate DATETIME NOT NULL,
    Description NVARCHAR(200) NULL,
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (PrescriptionId) REFERENCES Prescriptions(PrescriptionId),
    FOREIGN KEY (VisitId) REFERENCES Visits(VisitId)
);

CREATE TABLE PaymentTransactions (
    TransactionId INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceId INT NOT NULL,
    Amount DECIMAL(10,2) NOT NULL,
    TransactionDate DATETIME NOT NULL,
    PaymentMethod NVARCHAR(50) NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    FOREIGN KEY (InvoiceId) REFERENCES Invoices(InvoiceId)
);

CREATE TABLE Reminders (
    ReminderId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    AppointmentId INT NULL,
    VisitId INT NULL,
    ReminderDate DATETIME NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId),
    FOREIGN KEY (VisitId) REFERENCES Visits(VisitId)
);

CREATE TABLE LabRequests (
    RequestId INT IDENTITY(1,1) PRIMARY KEY,
    VisitId INT NOT NULL,
    LabId INT NULL,
    TestType NVARCHAR(100) NOT NULL,
    RequestDate DATETIME NOT NULL,
    ResultDate DATETIME NULL,
    Result NVARCHAR(500) NULL,
    Status NVARCHAR(20) NOT NULL,
    FOREIGN KEY (VisitId) REFERENCES Visits(VisitId),
    FOREIGN KEY (LabId) REFERENCES Labs(LabId)
);

--NHẬP DỮ LIỆU
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Address, SocialSecurityNumber, IsEncrypted) VALUES (N'Nguyễn', N'Văn A', '1990-05-12', N'Nam', '0912345678', N'123 Đường Láng, Hà Nội', '123-45-6789', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Address, SocialSecurityNumber, IsEncrypted) VALUES (N'Trần', N'Thị B', '1985-08-20', N'Nữ', '0987654321', N'45 Lê Lợi, TP.HCM', '987-65-4321', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Address, SocialSecurityNumber, IsEncrypted) VALUES (N'Lê', N'Văn C', '1995-03-15', N'Nam', '0901234567', N'78 Trần Phú, Đà Nẵng', NULL, 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Address, SocialSecurityNumber, IsEncrypted) VALUES (N'Phạm', N'Thị D', '1978-11-25', N'Nữ', '0934567890', N'56 Nguyễn Huệ, Huế', '456-78-9123', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Address, SocialSecurityNumber, IsEncrypted) VALUES (N'Hoàng', N'Văn E', '2000-01-10', N'Nam', '0978123456', N'12 Hùng Vương, Nha Trang', NULL, 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Address, SocialSecurityNumber, IsEncrypted) VALUES (N'Đỗ', N'Thị F', '1992-07-30', N'Nữ', '0918765432', N'34 Bạch Đằng, Hải Phòng', '321-54-9876', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Address, SocialSecurityNumber, IsEncrypted) VALUES (N'Bùi', N'Văn G', '1980-09-18', N'Nam', '0945678901', N'67 Lý Thường Kiệt, Cần Thơ', NULL, 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Address, SocialSecurityNumber, IsEncrypted) VALUES (N'Vũ', N'Thị H', '1988-12-05', N'Nữ', '0967891234', N'89 Điện Biên Phủ, Vinh', '654-32-1987', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Address, SocialSecurityNumber, IsEncrypted) VALUES (N'Đặng', N'Văn I', '1998-04-22', N'Nam', '0923456789', N'23 Pasteur, Quy Nhơn', NULL, 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Address, SocialSecurityNumber, IsEncrypted) VALUES (N'Ngô', N'Thị K', '1983-06-14', N'Nữ', '0956781234', N'90 Trường Chinh, Đà Lạt', '789-12-3456', 0);

INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (N'Nguyễn', N'Minh T', N'Nội khoa', 'BS12345', N'T2-T6: 08:00-16:00');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (N'Trần', N'Hồng P', N'Nhi khoa', 'BS67890', N'T3-T7: 09:00-17:00');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (N'Lê', N'Văn Q', N'Tim mạch', 'BS54321', N'T2-T5: 07:00-15:00');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (N'Phạm', N'Thị R', N'Sản khoa', 'BS98765', N'T4-CN: 08:00-16:00');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (N'Hoàng', N'Văn S', N'Xương khớp', 'BS13579', N'T3-T6: 10:00-18:00');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (N'Đỗ', N'Thị T', N'Da liễu', 'BS24680', N'T2-T7: 08:00-16:00');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (N'Bùi', N'Văn U', N'Tai mũi họng', 'BS11223', N'T5-CN: 09:00-17:00');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (N'Vũ', N'Thị V', N'Mắt', 'BS33445', N'T3-T6: 07:00-15:00');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (N'Đặng', N'Văn X', N'Răng hàm mặt', 'BS55667', N'T2-CN: 08:00-16:00');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (N'Ngô', N'Thị Y', N'Thần kinh', 'BS77889', N'T4-T7: 10:00-18:00');

INSERT INTO Staff (FirstName, LastName, Role, Contact, HireDate) VALUES (N'Nguyễn', N'Thị Z', N'Y tá', '0912345678', '2020-01-15');
INSERT INTO Staff (FirstName, LastName, Role, Contact, HireDate) VALUES (N'Trần', N'Văn A1', N'Lễ tân', '0987654321', '2021-03-10');
INSERT INTO Staff (FirstName, LastName, Role, Contact, HireDate) VALUES (N'Lê', N'Thị B1', N'Kế toán', '0901234567', '2019-07-22');
INSERT INTO Staff (FirstName, LastName, Role, Contact, HireDate) VALUES (N'Phạm', N'Văn C1', N'Quản lý', '0934567890', '2018-11-05');
INSERT INTO Staff (FirstName, LastName, Role, Contact, HireDate) VALUES (N'Hoàng', N'Thị D1', N'Y tá', '0978123456', '2022-02-18');
INSERT INTO Staff (FirstName, LastName, Role, Contact, HireDate) VALUES (N'Đỗ', N'Văn E1', N'Bảo vệ', '0918765432', '2020-09-30');
INSERT INTO Staff (FirstName, LastName, Role, Contact, HireDate) VALUES (N'Bùi', N'Thị F1', N'Lễ tân', '0945678901', '2021-12-12');
INSERT INTO Staff (FirstName, LastName, Role, Contact, HireDate) VALUES (N'Vũ', N'Văn G1', N'Kỹ thuật viên', '0967891234', '2019-04-25');
INSERT INTO Staff (FirstName, LastName, Role, Contact, HireDate) VALUES (N'Đặng', N'Thị H1', N'Y tá', '0923456789', '2023-01-08');
INSERT INTO Staff (FirstName, LastName, Role, Contact, HireDate) VALUES (N'Ngô', N'Văn I1', N'Kế toán', '0956781234', '2020-06-14');

INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES (N'Công ty Dược A', N'Nguyễn Văn X', '0912345678', 'duoca@gmail.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES (N'Công ty Dược B', N'Trần Thị Y', '0987654321', 'duocb@gmail.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES (N'Công ty Dược C', N'Lê Văn Z', '0901234567', 'duocc@gmail.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES (N'Công ty Dược D', N'Phạm Thị T', '0934567890', 'duocd@gmail.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES (N'Công ty Dược E', N'Hoàng Văn U', '0978123456', 'duoce@gmail.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES (N'Công ty Dược F', N'Đỗ Thị V', '0918765432', 'duocf@gmail.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES (N'Công ty Dược G', N'Bùi Văn W', '0945678901', 'duocg@gmail.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES (N'Công ty Dược H', N'Vũ Thị X', '0967891234', 'duoch@gmail.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES (N'Công ty Dược I', N'Đặng Văn Y', '0923456789', 'duoci@gmail.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES (N'Công ty Dược K', N'Ngô Thị Z', '0956781234', 'duock@gmail.com');

INSERT INTO Labs (LabName, Address) VALUES (N'Phòng xét nghiệm A', N'123 Nguyễn Trãi, Hà Nội');
INSERT INTO Labs (LabName, Address) VALUES (N'Phòng xét nghiệm B', N'45 Lê Đại Hành, TP.HCM');
INSERT INTO Labs (LabName, Address) VALUES (N'Phòng xét nghiệm C', N'78 Trần Hưng Đạo, Đà Nẵng');
INSERT INTO Labs (LabName, Address) VALUES (N'Phòng xét nghiệm D', N'56 Lý Tự Trọng, Huế');
INSERT INTO Labs (LabName, Address) VALUES (N'Phòng xét nghiệm E', N'12 Nguyễn Văn Cừ, Nha Trang');
INSERT INTO Labs (LabName, Address) VALUES (N'Phòng xét nghiệm F', N'34 Hùng Vương, Hải Phòng');
INSERT INTO Labs (LabName, Address) VALUES (N'Phòng xét nghiệm G', N'67 Phạm Ngũ Lão, Cần Thơ');
INSERT INTO Labs (LabName, Address) VALUES (N'Phòng xét nghiệm H', N'89 Hai Bà Trưng, Vinh');
INSERT INTO Labs (LabName, Address) VALUES (N'Phòng xét nghiệm I', N'23 Lê Lợi, Quy Nhơn');
INSERT INTO Labs (LabName, Address) VALUES (N'Phòng xét nghiệm K', N'90 Trường Chinh, Đà Lạt');

INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status) VALUES (1, 1, '2025-03-17 08:00:00', N'Đã xác nhận');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status) VALUES (2, 2, '2025-03-17 09:30:00', N'Chờ xác nhận');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status) VALUES (3, 3, '2025-03-18 10:00:00', N'Đã xác nhận');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status) VALUES (4, 4, '2025-03-18 14:00:00', N'Đã hủy');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status) VALUES (5, 5, '2025-03-19 08:30:00', N'Đã xác nhận');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status) VALUES (6, 6, '2025-03-19 15:00:00', N'Chờ xác nhận');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status) VALUES (7, 7, '2025-03-20 09:00:00', N'Đã xác nhận');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status) VALUES (8, 8, '2025-03-20 11:00:00', N'Đã xác nhận');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status) VALUES (9, 9, '2025-03-21 13:30:00', N'Chờ xác nhận');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status) VALUES (10, 10, '2025-03-21 16:00:00', N'Đã xác nhận');

INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (1, 1, 1, 1, '2025-03-17 08:15:00', N'Đau bụng');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (2, 2, 2, 2, '2025-03-17 09:45:00', N'Sốt cao');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (3, 3, 3, 3, '2025-03-18 10:15:00', N'Khó thở');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (4, 4, 4, NULL, '2025-03-18 14:30:00', N'Đau lưng');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (5, 5, 5, 5, '2025-03-19 08:45:00', N'Đau khớp');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (6, 6, 6, 6, '2025-03-19 15:15:00', N'Ngứa da');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (7, 7, 7, 7, '2025-03-20 09:15:00', N'Đau tai');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (8, 8, 8, 8, '2025-03-20 11:15:00', N'Mắt đỏ');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (9, 9, 9, 9, '2025-03-21 13:45:00', N'Đau răng');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (10, 10, 10, 10, '2025-03-21 16:15:00', N'Đau đầu');

INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, Weight, Height, RecordDate) VALUES (1, '120/80', 72, 36.6, 65.5, 170.0, '2025-03-17 08:20:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, Weight, Height, RecordDate) VALUES (2, '130/85', 80, 38.2, 55.0, 160.0, '2025-03-17 09:50:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, Weight, Height, RecordDate) VALUES (3, '140/90', 88, 37.0, 70.0, 175.0, '2025-03-18 10:20:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, Weight, Height, RecordDate) VALUES (4, '115/75', 68, 36.8, 60.0, 165.0, '2025-03-18 14:35:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, Weight, Height, RecordDate) VALUES (5, '125/80', 75, 36.9, 72.5, 172.0, '2025-03-19 08:50:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, Weight, Height, RecordDate) VALUES (6, '118/78', 70, 36.7, 58.0, 158.0, '2025-03-19 15:20:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, Weight, Height, RecordDate) VALUES (7, '122/82', 74, 37.1, 68.0, 168.0, '2025-03-20 09:20:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, Weight, Height, RecordDate) VALUES (8, '135/88', 82, 37.3, 62.0, 163.0, '2025-03-20 11:20:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, Weight, Height, RecordDate) VALUES (9, '128/84', 78, 36.5, 66.0, 171.0, '2025-03-21 13:50:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, Weight, Height, RecordDate) VALUES (10, '130/86', 76, 37.2, 70.5, 174.0, '2025-03-21 16:20:00');

INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (1, N'Viêm dạ dày', N'Đau vùng thượng vị, buồn nôn', '2025-03-17 08:30:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (2, N'Cảm cúm', N'Sốt, ho, đau họng', '2025-03-17 10:00:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (3, N'Suy hô hấp nhẹ', N'Khó thở khi gắng sức', '2025-03-18 10:30:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (4, N'Đau lưng cơ học', N'Đau khi cúi người', '2025-03-18 14:45:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (5, N'Viêm khớp', N'Sưng nhẹ khớp gối', '2025-03-19 09:00:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (6, N'Chàm', N'Ngứa và đỏ da', '2025-03-19 15:30:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (7, N'Viêm tai giữa', N'Đau tai trái', '2025-03-20 09:30:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (8, N'Viêm kết mạc', N'Mắt đỏ, chảy nước mắt', '2025-03-20 11:30:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (9, N'Sâu răng', N'Đau nhức răng hàm', '2025-03-21 14:00:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (10, N'Đau nửa đầu', N'Đau đầu bên phải', '2025-03-21 16:30:00', 0);

INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (1, '2025-03-17 08:35:00', N'Uống sau ăn, 2 lần/ngày');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (2, '2025-03-17 10:05:00', N'Uống trước ăn, 3 lần/ngày');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (3, '2025-03-18 10:35:00', N'Uống khi cần, không quá 4 lần/ngày');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (4, '2025-03-18 14:50:00', N'Uống sau ăn, 1 lần/ngày');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (5, '2025-03-19 09:05:00', N'Uống trước ăn, 2 lần/ngày');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (6, '2025-03-19 15:35:00', N'Bôi ngoài da, 2 lần/ngày');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (7, '2025-03-20 09:35:00', N'Uống sau ăn, 3 lần/ngày');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (8, '2025-03-20 11:35:00', N'Small drops, 2 lần/ngày');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (9, '2025-03-21 14:05:00', N'Uống trước ăn, 1 lần/ngày');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (10, '2025-03-21 16:35:00', N'Uống khi đau, không quá 3 lần/ngày');

INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES (N'Paracetamol', 1, 100, 5000.00, '2026-03-01', 'PAR001');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES (N'Amoxicillin', 2, 50, 10000.00, '2026-06-01', 'AMO002');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES (N'Ibuprofen', 3, 80, 7000.00, '2025-12-01', 'IBU003');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES (N'Omeprazole', 4, 60, 12000.00, '2026-09-01', 'OME004');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES (N'Cream Betamethasone', 5, 30, 25000.00, '2025-11-01', 'BET005');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES (N'Augmentin', 6, 40, 15000.00, '2026-02-01', 'AUG006');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES (N'Dexamethasone', 7, 70, 8000.00, '2026-04-01', 'DEX007');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES (N'Eye drops Levofloxacin', 8, 20, 30000.00, '2025-10-01', 'LEV008');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES (N'Ciprofloxacin', 9, 90, 9000.00, '2026-07-01', 'CIP009');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES (N'Metformin', 10, 50, 11000.00, '2026-08-01', 'MET010');

INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (1, 1, N'500mg', 10, 5000.00);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (2, 2, N'250mg', 15, 10000.00);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (3, 3, N'200mg', 20, 7000.00);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (4, 4, N'20mg', 10, 12000.00);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (5, 5, N'0.1%', 5, 25000.00);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (6, 6, N'625mg', 12, 15000.00);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (7, 7, N'4mg', 8, 8000.00);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (8, 8, N'0.5%', 3, 30000.00);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (9, 9, N'500mg', 10, 9000.00);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (10, 10, N'500mg', 15, 11000.00);

INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, Status) VALUES (1, 1, 50, '2025-03-10 09:00:00', '2025-03-15 14:00:00', N'Đã giao');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, Status) VALUES (2, 2, 30, '2025-03-11 10:00:00', NULL, N'Đang xử lý');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, Status) VALUES (3, 3, 40, '2025-03-12 11:00:00', '2025-03-16 15:00:00', N'Đã giao');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, Status) VALUES (4, 4, 20, '2025-03-13 12:00:00', NULL, N'Đang xử lý');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, Status) VALUES (5, 5, 15, '2025-03-14 13:00:00', '2025-03-17 16:00:00', N'Đã giao');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, Status) VALUES (6, 6, 25, '2025-03-15 14:00:00', NULL, N'Đang xử lý');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, Status) VALUES (7, 7, 35, '2025-03-16 15:00:00', '2025-03-18 09:00:00', N'Đã giao');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, Status) VALUES (8, 8, 10, '2025-03-17 16:00:00', NULL, N'Đang xử lý');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, Status) VALUES (9, 9, 45, '2025-03-18 09:00:00', '2025-03-20 10:00:00', N'Đã giao');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, Status) VALUES (10, 10, 30, '2025-03-19 10:00:00', NULL, N'Đang xử lý');

INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (1, 1, N'Nhập kho', 50, '2025-03-15 14:00:00', N'Nhập từ nhà cung cấp A');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (NULL, 2, N'Xuất kho', 15, '2025-03-17 10:10:00', N'Xuất cho đơn thuốc');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (3, 3, N'Nhập kho', 40, '2025-03-16 15:00:00', N'Nhập từ nhà cung cấp C');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (NULL, 4, N'Xuất kho', 10, '2025-03-18 14:55:00', N'Xuất cho đơn thuốc');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (5, 5, N'Nhập kho', 15, '2025-03-17 16:00:00', N'Nhập từ nhà cung cấp E');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (NULL, 6, N'Xuất kho', 12, '2025-03-19 15:40:00', N'Xuất cho đơn thuốc');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (7, 7, N'Nhập kho', 35, '2025-03-18 09:00:00', N'Nhập từ nhà cung cấp G');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (NULL, 8, N'Xuất kho', 3, '2025-03-20 11:40:00', N'Xuất cho đơn thuốc');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (9, 9, N'Nhập kho', 45, '2025-03-20 10:00:00', N'Nhập từ nhà cung cấp I');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (NULL, 10, N'Xuất kho', 15, '2025-03-21 16:40:00', N'Xuất cho đơn thuốc');

INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, Description) VALUES (1, N'Thuốc', 1, 1, 50000.00, '2025-03-17 08:40:00', N'Hóa đơn thuốc');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, Description) VALUES (2, N'Thuốc', 2, 2, 150000.00, '2025-03-17 10:10:00', N'Hóa đơn thuốc');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, Description) VALUES (3, N'Khám bệnh', NULL, 3, 200000.00, '2025-03-18 10:40:00', N'Hóa đơn khám');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, Description) VALUES (4, N'Thuốc', 4, 4, 120000.00, '2025-03-18 14:55:00', N'Hóa đơn thuốc');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, Description) VALUES (5, N'Thuốc', 5, 5, 125000.00, '2025-03-19 09:10:00', N'Hóa đơn thuốc');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, Description) VALUES (6, N'Thuốc', 6, 6, 180000.00, '2025-03-19 15:40:00', N'Hóa đơn thuốc');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, Description) VALUES (7, N'Khám bệnh', NULL, 7, 150000.00, '2025-03-20 09:40:00', N'Hóa đơn khám');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, Description) VALUES (8, N'Thuốc', 8, 8, 90000.00, '2025-03-20 11:40:00', N'Hóa đơn thuốc');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, Description) VALUES (9, N'Thuốc', 9, 9, 90000.00, '2025-03-21 14:10:00', N'Hóa đơn thuốc');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, Description) VALUES (10, N'Thuốc', 10, 10, 165000.00, '2025-03-21 16:40:00', N'Hóa đơn thuốc');

INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, Status) VALUES (1, 50000.00, '2025-03-17 08:45:00', N'Tiền mặt', N'Hoàn tất');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, Status) VALUES (2, 150000.00, '2025-03-17 10:15:00', N'Thẻ tín dụng', N'Hoàn tất');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, Status) VALUES (3, 200000.00, '2025-03-18 10:45:00', N'Tiền mặt', N'Hoàn tất');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, Status) VALUES (4, 120000.00, '2025-03-18 15:00:00', N'Chuyển khoản', N'Hoàn tất');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, Status) VALUES (5, 125000.00, '2025-03-19 09:15:00', N'Tiền mặt', N'Hoàn tất');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, Status) VALUES (6, 180000.00, '2025-03-19 15:45:00', N'Thẻ tín dụng', N'Hoàn tất');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, Status) VALUES (7, 150000.00, '2025-03-20 09:45:00', N'Tiền mặt', N'Hoàn tất');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, Status) VALUES (8, 90000.00, '2025-03-20 11:45:00', N'Chuyển khoản', N'Hoàn tất');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, Status) VALUES (9, 90000.00, '2025-03-21 14:15:00', N'Tiền mặt', N'Hoàn tất');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, Status) VALUES (10, 165000.00, '2025-03-21 16:45:00', N'Thẻ tín dụng', N'Hoàn tất');

INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, Status) VALUES (1, 1, NULL, '2025-03-16 08:00:00', N'Đã gửi');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, Status) VALUES (2, 2, NULL, '2025-03-16 09:00:00', N'Chưa gửi');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, Status) VALUES (3, 3, NULL, '2025-03-17 10:00:00', N'Đã gửi');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, Status) VALUES (4, 4, NULL, '2025-03-17 14:00:00', N'Đã hủy');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, Status) VALUES (5, 5, NULL, '2025-03-18 08:00:00', N'Đã gửi');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, Status) VALUES (6, 6, NULL, '2025-03-18 15:00:00', N'Chưa gửi');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, Status) VALUES (7, 7, NULL, '2025-03-19 09:00:00', N'Đã gửi');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, Status) VALUES (8, 8, NULL, '2025-03-19 11:00:00', N'Đã gửi');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, Status) VALUES (9, 9, NULL, '2025-03-20 13:00:00', N'Chưa gửi');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, Status) VALUES (10, 10, NULL, '2025-03-20 16:00:00', N'Đã gửi');

INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, Status) VALUES (1, 1, N'Xét nghiệm máu', '2025-03-17 08:50:00', '2025-03-18 10:00:00', N'Bình thường', N'Hoàn tất');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, Status) VALUES (2, 2, N'Xét nghiệm nước tiểu', '2025-03-17 10:20:00', NULL, NULL, N'Đang xử lý');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, Status) VALUES (3, 3, N'X-quang ngực', '2025-03-18 10:50:00', '2025-03-19 09:00:00', N'Phổi bình thường', N'Hoàn tất');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, Status) VALUES (4, 4, N'Siêu âm lưng', '2025-03-18 15:00:00', NULL, NULL, N'Đang xử lý');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, Status) VALUES (5, 5, N'Xét nghiệm máu', '2025-03-19 09:20:00', '2025-03-20 11:00:00', N'CRP tăng nhẹ', N'Hoàn tất');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, Status) VALUES (6, 6, N'Xét nghiệm da', '2025-03-19 15:50:00', NULL, NULL, N'Đang xử lý');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, Status) VALUES (7, 7, N'Xét nghiệm tai', '2025-03-20 09:50:00', '2025-03-21 10:00:00', N'Viêm tai giữa', N'Hoàn tất');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, Status) VALUES (8, 8, N'Xét nghiệm mắt', '2025-03-20 11:50:00', NULL, NULL, N'Đang xử lý');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, Status) VALUES (9, 9, N'Xét nghiệm răng', '2025-03-21 14:20:00', '2025-03-22 09:00:00', N'Sâu răng nặng', N'Hoàn tất');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, Status) VALUES (10, 10, N'MRI đầu', '2025-03-21 16:50:00', NULL, NULL, N'Đang xử lý');