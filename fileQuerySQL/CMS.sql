CREATE DATABASE CMS_test;
GO

USE CMS_test;
GO 

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    RoleUsers NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    SecurityQuestion VARBINARY(MAX) NOT NULL,
    SecurityAnswerHash VARBINARY(MAX) NOT NULL,
    LastLogin DATETIME NULL,
    IsActive BIT DEFAULT 1 NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);


CREATE TABLE Patients (
    PatientId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender NVARCHAR(1) NOT NULL CHECK (Gender IN ('M', 'F', 'O')),
    PhoneNumber NVARCHAR(15) NOT NULL CHECK (PhoneNumber LIKE '[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
    AddressPatients NVARCHAR(100) NOT NULL,
    SocialSecurityNumber NVARCHAR(11) NULL CHECK (SocialSecurityNumber LIKE '[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9][0-9][0-9]' OR SocialSecurityNumber IS NULL),
    IsEncrypted BIT DEFAULT 0 NOT NULL
);

CREATE TABLE Doctors (
    DoctorId INT IDENTITY(1,1) PRIMARY KEY,
	UserId INT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Specialty NVARCHAR(50) NOT NULL,
    LicenseNumber NVARCHAR(20) UNIQUE NOT NULL,
    Schedule NVARCHAR(100) NOT NULL,
	FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Staff (
    StaffId INT IDENTITY(1,1) PRIMARY KEY,
	UserId INT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    RoleStaff NVARCHAR(50) NOT NULL,
    Contact NVARCHAR(15) NOT NULL CHECK (Contact LIKE '[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
    HireDate DATE NOT NULL CHECK (HireDate <= GETDATE()),
	FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Suppliers (
    SupplierId INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName NVARCHAR(100) NOT NULL,
    ContactPerson NVARCHAR(50) NOT NULL,
    Phone NVARCHAR(15) NOT NULL CHECK (Phone LIKE '[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
    Email NVARCHAR(100) NOT NULL
);

CREATE TABLE Labs (
    LabId INT IDENTITY(1,1) PRIMARY KEY,
    LabName NVARCHAR(100) NOT NULL,
    LabAddress NVARCHAR(200) NOT NULL
);

CREATE TABLE UserSessions (
    SessionId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    LoginTime DATETIME NOT NULL DEFAULT GETDATE(),
    LogoutTime DATETIME NULL, -- Bỏ CHECK ở cấp cột
    IpAddress NVARCHAR(45) NULL,
    Token NVARCHAR(256) NULL,
    IsActive BIT DEFAULT 1 NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    CONSTRAINT Check_LogoutTime CHECK (LogoutTime >= LoginTime OR LogoutTime IS NULL) -- Định nghĩa CHECK ở cấp bảng
);

CREATE TABLE Appointments (
    AppointmentId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    AppointmentDate DATETIME NOT NULL CHECK (AppointmentDate >= GETDATE()),
    AppointmentsStatus NVARCHAR(20) NOT NULL CHECK (AppointmentsStatus IN ('Scheduled', 'Completed', 'Cancelled')),
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);

CREATE TABLE Visits (
    VisitId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    StaffId INT NULL,
    AppointmentId INT NULL,
    VisitDate DATETIME NOT NULL CHECK (VisitDate >= GETDATE()),
    ChiefComplaint NVARCHAR(200) NOT NULL,
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId),
    FOREIGN KEY (StaffId) REFERENCES Staff(StaffId),
    FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId)
);

CREATE TABLE VitalSigns (
    VitalSignId INT IDENTITY(1,1) PRIMARY KEY,
    VisitId INT NOT NULL,
    BloodPressure NVARCHAR(10) NOT NULL CHECK (BloodPressure LIKE '[0-9][0-9][0-9]/[0-9][0-9]'),
    HeartRate INT NOT NULL CHECK (HeartRate BETWEEN 30 AND 200),
    Temperature DECIMAL(5,2) NOT NULL CHECK (Temperature BETWEEN 30 AND 45),
    WeightPatient DECIMAL(5,2) NOT NULL CHECK (WeightPatient BETWEEN 1 AND 300),
    HeightPatient DECIMAL(5,2) NOT NULL CHECK (HeightPatient BETWEEN 30 AND 250),
    RecordDate DATETIME NOT NULL CHECK (RecordDate >= GETDATE()),
    FOREIGN KEY (VisitId) REFERENCES Visits(VisitId)
);

CREATE TABLE MedicalRecords (
    MedicalRecordId INT IDENTITY(1,1) PRIMARY KEY,
    VisitId INT NOT NULL,
    Diagnosis NVARCHAR(200) NOT NULL,
    ClinicalNotes NVARCHAR(500) NOT NULL,
    RecordDate DATETIME NOT NULL CHECK (RecordDate >= GETDATE()),
    IsEncrypted BIT DEFAULT 0 NOT NULL,
    FOREIGN KEY (VisitId) REFERENCES Visits(VisitId)
);

CREATE TABLE Prescriptions (
    PrescriptionId INT IDENTITY(1,1) PRIMARY KEY,
    VisitId INT NOT NULL,
    PrescriptionDate DATETIME NOT NULL CHECK (PrescriptionDate >= GETDATE()),
    Instructions NVARCHAR(200) NOT NULL,
    FOREIGN KEY (VisitId) REFERENCES Visits(VisitId)
);

CREATE TABLE MedicineInventory (
    MedicineId INT IDENTITY(1,1) PRIMARY KEY,
    MedicineName NVARCHAR(100) NOT NULL,
    SupplierId INT NOT NULL,
    QuantityInStock INT NOT NULL CHECK (QuantityInStock >= 0),
    UnitPrice DECIMAL(10,2) NOT NULL CHECK (UnitPrice >= 0),
    ExpirationDate DATE NOT NULL CHECK (ExpirationDate >= GETDATE()),
    BatchNumber NVARCHAR(50) NOT NULL,
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(SupplierId)
);

CREATE TABLE PrescriptionDetails (
    PrescriptionDetailId INT IDENTITY(1,1) PRIMARY KEY,
    PrescriptionId INT NOT NULL,
    MedicineId INT NOT NULL,
    Dosage NVARCHAR(50) NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    UnitPrice DECIMAL(10,2) NOT NULL CHECK (UnitPrice >= 0),
    FOREIGN KEY (PrescriptionId) REFERENCES Prescriptions(PrescriptionId),
    FOREIGN KEY (MedicineId) REFERENCES MedicineInventory(MedicineId)
);

CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    SupplierId INT NOT NULL,
    MedicineId INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    OrderDate DATETIME NOT NULL CHECK (OrderDate <= GETDATE()),
    DeliveryDate DATETIME NULL,
    OrdersStatus NVARCHAR(20) NOT NULL CHECK (OrdersStatus IN ('Pending', 'Delivered', 'Cancelled')),
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(SupplierId),
    FOREIGN KEY (MedicineId) REFERENCES MedicineInventory(MedicineId),
	CONSTRAINT Check_DeliveryDate CHECK (DeliveryDate >= OrderDate OR DeliveryDate IS NULL) -- Định nghĩa CHECK ở cấp bảng
);

CREATE TABLE InventoryTransactions (
    TransactionId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NULL,
    MedicineId INT NOT NULL,
    TransactionType NVARCHAR(20) NOT NULL CHECK (TransactionType IN ('In', 'Out')),
    Quantity INT NOT NULL CHECK (Quantity > 0),
    TransactionDate  DATETIME NOT NULL CHECK (TransactionDate <= GETDATE()),
    Description NVARCHAR(200) NULL,--check lai
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (MedicineId) REFERENCES MedicineInventory(MedicineId)
);

CREATE TABLE Invoices (
    InvoiceId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    InvoiceType NVARCHAR(20) NOT NULL CHECK (InvoiceType IN ('Visit', 'Prescription')),
    PrescriptionId INT NULL,
    VisitId INT NULL,
    TotalAmount DECIMAL(10,2) NOT NULL CHECK (TotalAmount >= 0),
    InvoiceDate DATETIME NOT NULL CHECK (InvoiceDate <= GETDATE()),
    InvoicesDescription NVARCHAR(200) NULL,
	CHECK (PrescriptionId IS NOT NULL OR VisitId IS NOT NULL),
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (PrescriptionId) REFERENCES Prescriptions(PrescriptionId),
    FOREIGN KEY (VisitId) REFERENCES Visits(VisitId)
);

CREATE TABLE PaymentTransactions (
    TransactionId INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceId INT NOT NULL,
    Amount DECIMAL(10,2) NOT NULL CHECK (Amount >= 0),
    TransactionDate DATETIME NOT NULL CHECK (TransactionDate <= GETDATE()),
    PaymentMethod NVARCHAR(50) NOT NULL CHECK (PaymentMethod IN ('Cash', 'Card', 'Insurance')),
    PaymentTransactionsStatus NVARCHAR(20) NOT NULL CHECK (PaymentTransactionsStatus IN ('Pending', 'Completed', 'Failed')),
    FOREIGN KEY (InvoiceId) REFERENCES Invoices(InvoiceId)
);

CREATE TABLE Reminders (
    ReminderId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    AppointmentId INT NULL,
    VisitId INT NULL,
    ReminderDate DATETIME NOT NULL CHECK (ReminderDate >= GETDATE()),
    StatusReminders NVARCHAR(20) NOT NULL CHECK (StatusReminders IN ('Pending', 'Sent', 'Failed')),
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId),
    FOREIGN KEY (VisitId) REFERENCES Visits(VisitId)
);

CREATE TABLE LabRequests (
    RequestId INT IDENTITY(1,1) PRIMARY KEY,
    VisitId INT NOT NULL,
    LabId INT NULL,
    TestType NVARCHAR(100) NOT NULL,
    RequestDate DATETIME NOT NULL CHECK (RequestDate <= GETDATE()),
    ResultDate DATETIME NULL,
    Result NVARCHAR(500) NULL,
    StatusLabRequests NVARCHAR(20) NOT NULL CHECK (StatusLabRequests IN ('Pending', 'Completed', 'Cancelled')),
    FOREIGN KEY (VisitId) REFERENCES Visits(VisitId),
    FOREIGN KEY (LabId) REFERENCES Labs(LabId),
	CONSTRAINT Check_ResultDate CHECK (ResultDate >= RequestDate OR ResultDate IS NULL)
);

--
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate) VALUES ('user1', 'hash1', 'Admin', 'user1@example.com', 0x1234, 0x5678, NULL, 1, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate) VALUES ('user2', 'hash2', 'Doctor', 'user2@example.com', 0x1234, 0x5678, '2025-03-16 10:00:00', 1, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate) VALUES ('user3', 'hash3', 'Staff', 'user3@example.com', 0x1234, 0x5678, NULL, 1, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate) VALUES ('user4', 'hash4', 'Doctor', 'user4@example.com', 0x1234, 0x5678, '2025-03-15 09:00:00', 1, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate) VALUES ('user5', 'hash5', 'Staff', 'user5@example.com', 0x1234, 0x5678, NULL, 1, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate) VALUES ('user6', 'hash6', 'Admin', 'user6@example.com', 0x1234, 0x5678, '2025-03-14 14:00:00', 1, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate) VALUES ('user7', 'hash7', 'Doctor', 'user7@example.com', 0x1234, 0x5678, NULL, 1, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate) VALUES ('user8', 'hash8', 'Staff', 'user8@example.com', 0x1234, 0x5678, '2025-03-13 08:00:00', 1, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate) VALUES ('user9', 'hash9', 'Admin', 'user9@example.com', 0x1234, 0x5678, NULL, 1, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate) VALUES ('user10', 'hash10', 'Doctor', 'user10@example.com', 0x1234, 0x5678, '2025-03-12 12:00:00', 1, GETDATE());

INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) VALUES ('John', 'Doe', '1990-05-15', 'M', '123-456-7890', '123 Main St', '123-45-6789', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) VALUES ('Jane', 'Smith', '1985-08-22', 'F', '234-567-8901', '456 Oak St', '234-56-7890', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) VALUES ('Alex', 'Johnson', '1995-03-10', 'O', '345-678-9012', '789 Pine St', NULL, 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) VALUES ('Emily', 'Brown', '1988-12-01', 'F', '456-789-0123', '101 Elm St', '345-67-8901', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) VALUES ('Michael', 'Davis', '1992-07-19', 'M', '567-890-1234', '202 Cedar St', '456-78-9012', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) VALUES ('Sarah', 'Wilson', '1993-09-25', 'F', '678-901-2345', '303 Birch St', NULL, 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) VALUES ('David', 'Taylor', '1980-11-30', 'M', '789-012-3456', '404 Maple St', '567-89-0123', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) VALUES ('Laura', 'Moore', '1991-04-14', 'F', '890-123-4567', '505 Spruce St', '678-90-1234', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) VALUES ('Chris', 'Anderson', '1987-06-08', 'M', '901-234-5678', '606 Willow St', NULL, 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) VALUES ('Anna', 'Thomas', '1994-02-27', 'F', '012-345-6789', '707 Ash St', '789-01-2345', 0);

INSERT INTO Doctors (UserId, FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (2, 'James', 'Wilson', 'Cardiology', 'LIC001', 'Mon-Fri 9:00-17:00');
INSERT INTO Doctors (UserId, FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (4, 'Robert', 'Lee', 'Neurology', 'LIC002', 'Mon-Wed 10:00-18:00');
INSERT INTO Doctors (UserId, FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (7, 'Susan', 'Clark', 'Pediatrics', 'LIC003', 'Tue-Thu 8:00-16:00');
INSERT INTO Doctors (UserId, FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (10, 'Thomas', 'Harris', 'Orthopedics', 'LIC004', 'Mon-Fri 11:00-19:00');
INSERT INTO Doctors (UserId, FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (NULL, 'Linda', 'Walker', 'Dermatology', 'LIC005', 'Wed-Fri 9:00-15:00');
INSERT INTO Doctors (UserId, FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (NULL, 'Mark', 'Young', 'Oncology', 'LIC006', 'Mon-Thu 10:00-16:00');
INSERT INTO Doctors (UserId, FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (NULL, 'Nancy', 'King', 'Gastroenterology', 'LIC007', 'Tue-Fri 8:00-14:00');
INSERT INTO Doctors (UserId, FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (NULL, 'Paul', 'Scott', 'Urology', 'LIC008', 'Mon-Wed 9:00-17:00');
INSERT INTO Doctors (UserId, FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (NULL, 'Kelly', 'Green', 'Endocrinology', 'LIC009', 'Thu-Sat 10:00-18:00');
INSERT INTO Doctors (UserId, FirstName, LastName, Specialty, LicenseNumber, Schedule) VALUES (NULL, 'Brian', 'Adams', 'Psychiatry', 'LIC010', 'Mon-Fri 12:00-20:00');

INSERT INTO Staff (UserId, FirstName, LastName, RoleStaff, Contact, HireDate) VALUES (3, 'Alice', 'Miller', 'Nurse', '123-456-7890', '2023-01-15');
INSERT INTO Staff (UserId, FirstName, LastName, RoleStaff, Contact, HireDate) VALUES (5, 'Tom', 'Evans', 'Receptionist', '234-567-8901', '2022-06-20');
INSERT INTO Staff (UserId, FirstName, LastName, RoleStaff, Contact, HireDate) VALUES (8, 'Emma', 'White', 'Technician', '345-678-9012', '2021-09-10');
INSERT INTO Staff (UserId, FirstName, LastName, RoleStaff, Contact, HireDate) VALUES (NULL, 'Peter', 'Hall', 'Nurse', '456-789-0123', '2023-03-01');
INSERT INTO Staff (UserId, FirstName, LastName, RoleStaff, Contact, HireDate) VALUES (NULL, 'Grace', 'Lopez', 'Receptionist', '567-890-1234', '2022-11-25');
INSERT INTO Staff (UserId, FirstName, LastName, RoleStaff, Contact, HireDate) VALUES (NULL, 'Henry', 'Turner', 'Technician', '678-901-2345', '2021-12-15');
INSERT INTO Staff (UserId, FirstName, LastName, RoleStaff, Contact, HireDate) VALUES (NULL, 'Olivia', 'Carter', 'Nurse', '789-012-3456', '2023-02-10');
INSERT INTO Staff (UserId, FirstName, LastName, RoleStaff, Contact, HireDate) VALUES (NULL, 'Jack', 'Phillips', 'Receptionist', '890-123-4567', '2022-08-05');
INSERT INTO Staff (UserId, FirstName, LastName, RoleStaff, Contact, HireDate) VALUES (NULL, 'Sophia', 'Parker', 'Technician', '901-234-5678', '2021-10-30');
INSERT INTO Staff (UserId, FirstName, LastName, RoleStaff, Contact, HireDate) VALUES (NULL, 'Liam', 'Collins', 'Nurse', '012-345-6789', '2023-04-20');

INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES ('MediSupply Co.', 'John Carter', '123-456-7890', 'john@medisupply.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES ('PharmaCorp', 'Mary Evans', '234-567-8901', 'mary@pharmacorp.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES ('HealthGoods', 'David Lee', '345-678-9012', 'david@healthgoods.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES ('BioMed Inc.', 'Sarah Kim', '456-789-0123', 'sarah@biomed.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES ('Wellness Ltd.', 'Tom Brown', '567-890-1234', 'tom@wellness.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES ('DrugMart', 'Lisa White', '678-901-2345', 'lisa@drugmart.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES ('CarePharma', 'James Green', '789-012-3456', 'james@carepharma.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES ('MediTech', 'Anna Scott', '890-123-4567', 'anna@meditech.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES ('PharmaPlus', 'Mark Davis', '901-234-5678', 'mark@pharmaplus.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) VALUES ('HealthPro', 'Emily Clark', '012-345-6789', 'emily@healthpro.com');

INSERT INTO Labs (LabName, LabAddress) VALUES ('CityLab', '123 Lab St, City A');
INSERT INTO Labs (LabName, LabAddress) VALUES ('MediTest', '456 Test Rd, City B');
INSERT INTO Labs (LabName, LabAddress) VALUES ('BioLab', '789 Bio Ave, City C');
INSERT INTO Labs (LabName, LabAddress) VALUES ('HealthLab', '101 Health Ln, City D');
INSERT INTO Labs (LabName, LabAddress) VALUES ('PrimeLab', '202 Prime St, City E');
INSERT INTO Labs (LabName, LabAddress) VALUES ('CareLab', '303 Care Rd, City F');
INSERT INTO Labs (LabName, LabAddress) VALUES ('TrueLab', '404 True Ave, City G');
INSERT INTO Labs (LabName, LabAddress) VALUES ('LifeLab', '505 Life Ln, City H');
INSERT INTO Labs (LabName, LabAddress) VALUES ('ProLab', '606 Pro St, City I');
INSERT INTO Labs (LabName, LabAddress) VALUES ('WellLab', '707 Well Rd, City J');

INSERT INTO UserSessions (UserId, LoginTime, LogoutTime, IpAddress, Token, IsActive) VALUES (1, '2025-03-17 08:00:00', NULL, '192.168.1.1', 'token1', 1);
INSERT INTO UserSessions (UserId, LoginTime, LogoutTime, IpAddress, Token, IsActive) VALUES (2, '2025-03-17 09:00:00', '2025-03-17 17:00:00', '192.168.1.2', 'token2', 0);
INSERT INTO UserSessions (UserId, LoginTime, LogoutTime, IpAddress, Token, IsActive) VALUES (3, '2025-03-16 10:00:00', NULL, '192.168.1.3', 'token3', 1);
INSERT INTO UserSessions (UserId, LoginTime, LogoutTime, IpAddress, Token, IsActive) VALUES (4, '2025-03-16 11:00:00', '2025-03-16 19:00:00', '192.168.1.4', 'token4', 0);
INSERT INTO UserSessions (UserId, LoginTime, LogoutTime, IpAddress, Token, IsActive) VALUES (5, '2025-03-15 12:00:00', NULL, '192.168.1.5', 'token5', 1);
INSERT INTO UserSessions (UserId, LoginTime, LogoutTime, IpAddress, Token, IsActive) VALUES (6, '2025-03-15 13:00:00', '2025-03-15 21:00:00', '192.168.1.6', 'token6', 0);
INSERT INTO UserSessions (UserId, LoginTime, LogoutTime, IpAddress, Token, IsActive) VALUES (7, '2025-03-14 14:00:00', NULL, '192.168.1.7', 'token7', 1);
INSERT INTO UserSessions (UserId, LoginTime, LogoutTime, IpAddress, Token, IsActive) VALUES (8, '2025-03-14 15:00:00', '2025-03-14 23:00:00', '192.168.1.8', 'token8', 0);
INSERT INTO UserSessions (UserId, LoginTime, LogoutTime, IpAddress, Token, IsActive) VALUES (9, '2025-03-13 16:00:00', NULL, '192.168.1.9', 'token9', 1);
INSERT INTO UserSessions (UserId, LoginTime, LogoutTime, IpAddress, Token, IsActive) VALUES (10, '2025-03-13 17:00:00', '2025-03-13 01:00:00', '192.168.1.10', 'token10', 0);

INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) VALUES (1, 1, '2025-03-18 10:00:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) VALUES (2, 2, '2025-03-19 14:00:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) VALUES (3, 3, '2025-03-20 09:00:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) VALUES (4, 4, '2025-03-21 11:00:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) VALUES (5, 1, '2025-03-22 15:00:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) VALUES (6, 2, '2025-03-23 13:00:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) VALUES (7, 3, '2025-03-24 10:00:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) VALUES (8, 4, '2025-03-25 12:00:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) VALUES (9, 1, '2025-03-26 16:00:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) VALUES (10, 2, '2025-03-27 14:00:00', 'Scheduled');

INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (1, 1, 1, 1, '2025-03-18 10:00:00', 'Chest pain');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (2, 2, 2, 2, '2025-03-19 14:00:00', 'Headache');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (3, 3, 3, 3, '2025-03-20 09:00:00', 'Fever');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (4, 4, 4, 4, '2025-03-21 11:00:00', 'Back pain');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (5, 1, 5, 5, '2025-03-22 15:00:00', 'Cough');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (6, 2, 6, 6, '2025-03-23 13:00:00', 'Fatigue');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (7, 3, 7, 7, '2025-03-24 10:00:00', 'Sore throat');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (8, 4, 8, 8, '2025-03-25 12:00:00', 'Stomach pain');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (9, 1, 9, 9, '2025-03-26 16:00:00', 'Rash');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) VALUES (10, 2, 10, 10, '2025-03-27 14:00:00', 'Joint pain');

INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) VALUES (1, '120/80', 75, 36.6, 70.5, 175.0, '2025-03-18 10:00:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) VALUES (2, '130/85', 80, 37.0, 65.0, 160.0, '2025-03-19 14:00:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) VALUES (3, '110/70', 90, 38.2, 55.0, 150.0, '2025-03-20 09:00:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) VALUES (4, '140/90', 85, 36.8, 80.0, 180.0, '2025-03-21 11:00:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) VALUES (5, '125/82', 70, 37.5, 75.0, 170.0, '2025-03-22 15:00:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) VALUES (6, '115/75', 78, 36.9, 60.0, 165.0, '2025-03-23 13:00:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) VALUES (7, '135/88', 82, 37.2, 68.0, 168.0, '2025-03-24 10:00:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) VALUES (8, '128/84', 76, 36.7, 72.0, 172.0, '2025-03-25 12:00:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) VALUES (9, '118/78', 88, 37.1, 58.0, 155.0, '2025-03-26 16:00:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) VALUES (10, '132/86', 84, 37.3, 78.0, 178.0, '2025-03-27 14:00:00');

INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (1, 'Angina', 'Patient reports chest pain for 2 days.', '2025-03-18 10:00:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (2, 'Migraine', 'Recurrent headaches with nausea.', '2025-03-19 14:00:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (3, 'Influenza', 'High fever and body aches.', '2025-03-20 09:00:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (4, 'Lumbar strain', 'Lower back pain after lifting.', '2025-03-21 11:00:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (5, 'Bronchitis', 'Persistent cough with phlegm.', '2025-03-22 15:00:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (6, 'Chronic fatigue', 'Ongoing tiredness for weeks.', '2025-03-23 13:00:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (7, 'Pharyngitis', 'Sore throat and difficulty swallowing.', '2025-03-24 10:00:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (8, 'Gastritis', 'Epigastric pain after meals.', '2025-03-25 12:00:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (9, 'Contact dermatitis', 'Itchy rash on arms.', '2025-03-26 16:00:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) VALUES (10, 'Arthritis', 'Joint stiffness and swelling.', '2025-03-27 14:00:00', 0);

INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (1, '2025-03-18 10:00:00', 'Take 1 tablet daily for 5 days.');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (2, '2025-03-19 14:00:00', 'Take 2 tablets every 6 hours as needed.');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (3, '2025-03-20 09:00:00', 'Take 1 teaspoon every 4 hours.');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (4, '2025-03-21 11:00:00', 'Apply cream twice daily.');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (5, '2025-03-22 15:00:00', 'Take 1 tablet every 8 hours for 7 days.');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (6, '2025-03-23 13:00:00', 'Take 1 capsule daily for 10 days.');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (7, '2025-03-24 10:00:00', 'Gargle with solution 3 times daily.');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (8, '2025-03-25 12:00:00', 'Take 1 tablet before meals for 5 days.');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (9, '2025-03-26 16:00:00', 'Apply ointment twice daily for 7 days.');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) VALUES (10, '2025-03-27 14:00:00', 'Take 1 tablet daily for 30 days.');

INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES ('Aspirin', 1, 100, 0.50, '2026-03-17', 'B001');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES ('Ibuprofen', 2, 150, 0.75, '2026-06-17', 'B002');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES ('Paracetamol', 3, 200, 0.30, '2026-09-17', 'B003');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES ('Amoxicillin', 4, 80, 1.20, '2026-12-17', 'B004');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES ('Cough Syrup', 5, 50, 5.00, '2025-12-17', 'B005');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES ('Vitamin B12', 6, 120, 2.50, '2026-03-17', 'B006');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES ('Gargle Solution', 7, 60, 3.00, '2025-11-17', 'B007');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES ('Omeprazole', 8, 90, 1.50, '2026-02-17', 'B008');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES ('Hydrocortisone Cream', 9, 40, 4.00, '2025-10-17', 'B009');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) VALUES ('Celecoxib', 10, 70, 2.00, '2026-01-17', 'B010');

INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (1, 1, '1 tablet', 5, 0.50);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (2, 2, '2 tablets', 10, 0.75);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (3, 3, '1 teaspoon', 6, 0.30);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (4, 4, 'Apply twice daily', 1, 1.20);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (5, 5, '1 tablet', 7, 5.00);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (6, 6, '1 capsule', 10, 2.50);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (7, 7, 'Gargle 3 times', 3, 3.00);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (8, 8, '1 tablet', 5, 1.50);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (9, 9, 'Apply twice daily', 1, 4.00);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) VALUES (10, 10, '1 tablet', 30, 2.00);

INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) VALUES (1, 1, 50, '2025-03-10 09:00:00', '2025-03-15 09:00:00', 'Delivered');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) VALUES (2, 2, 100, '2025-03-11 10:00:00', NULL, 'Pending');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) VALUES (3, 3, 150, '2025-03-12 11:00:00', '2025-03-16 11:00:00', 'Delivered');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) VALUES (4, 4, 80, '2025-03-13 12:00:00', NULL, 'Pending');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) VALUES (5, 5, 60, '2025-03-14 13:00:00', '2025-03-17 13:00:00', 'Delivered');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) VALUES (6, 6, 120, '2025-03-15 14:00:00', NULL, 'Pending');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) VALUES (7, 7, 70, '2025-03-16 15:00:00', '2025-03-17 15:00:00', 'Delivered');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) VALUES (8, 8, 90, '2025-03-17 16:00:00', NULL, 'Pending');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) VALUES (9, 9, 50, '2025-03-17 08:00:00', '2025-03-17 10:00:00', 'Delivered');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) VALUES (10, 10, 100, '2025-03-17 09:00:00', NULL, 'Pending');

INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (1, 1, 'In', 50, '2025-03-15 09:00:00', 'Received from supplier');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (NULL, 2, 'Out', 10, '2025-03-17 10:00:00', 'Dispensed to patient');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (3, 3, 'In', 150, '2025-03-16 11:00:00', 'Received from supplier');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (NULL, 4, 'Out', 5, '2025-03-17 12:00:00', 'Dispensed to patient');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (5, 5, 'In', 60, '2025-03-17 13:00:00', 'Received from supplier');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (NULL, 6, 'Out', 10, '2025-03-17 14:00:00', 'Dispensed to patient');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (7, 7, 'In', 70, '2025-03-17 15:00:00', 'Received from supplier');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (NULL, 8, 'Out', 5, '2025-03-17 16:00:00', 'Dispensed to patient');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (9, 9, 'In', 50, '2025-03-17 10:00:00', 'Received from supplier');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) VALUES (NULL, 10, 'Out', 30, '2025-03-17 09:00:00', 'Dispensed to patient');

INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) VALUES (1, 'Visit', NULL, 1, 50.00, '2025-03-18 10:00:00', 'Consultation fee');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) VALUES (2, 'Prescription', 2, NULL, 7.50, '2025-03-19 14:00:00', 'Medication cost');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) VALUES (3, 'Visit', NULL, 3, 60.00, '2025-03-20 09:00:00', 'Consultation fee');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) VALUES (4, 'Prescription', 4, NULL, 1.20, '2025-03-21 11:00:00', 'Medication cost');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) VALUES (5, 'Visit', NULL, 5, 55.00, '2025-03-22 15:00:00', 'Consultation fee');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) VALUES (6, 'Prescription', 6, NULL, 25.00, '2025-03-23 13:00:00', 'Medication cost');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) VALUES (7, 'Visit', NULL, 7, 50.00, '2025-03-24 10:00:00', 'Consultation fee');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) VALUES (8, 'Prescription', 8, NULL, 7.50, '2025-03-25 12:00:00', 'Medication cost');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) VALUES (9, 'Visit', NULL, 9, 60.00, '2025-03-26 16:00:00', 'Consultation fee');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) VALUES (10, 'Prescription', 10, NULL, 60.00, '2025-03-27 14:00:00', 'Medication cost');

INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) VALUES (1, 50.00, '2025-03-18 10:00:00', 'Cash', 'Completed');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) VALUES (2, 7.50, '2025-03-19 14:00:00', 'Card', 'Completed');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) VALUES (3, 60.00, '2025-03-20 09:00:00', 'Insurance', 'Pending');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) VALUES (4, 1.20, '2025-03-21 11:00:00', 'Cash', 'Completed');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) VALUES (5, 55.00, '2025-03-22 15:00:00', 'Card', 'Completed');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) VALUES (6, 25.00, '2025-03-23 13:00:00', 'Insurance', 'Pending');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) VALUES (7, 50.00, '2025-03-24 10:00:00', 'Cash', 'Completed');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) VALUES (8, 7.50, '2025-03-25 12:00:00', 'Card', 'Completed');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) VALUES (9, 60.00, '2025-03-26 16:00:00', 'Insurance', 'Pending');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) VALUES (10, 60.00, '2025-03-27 14:00:00', 'Cash', 'Completed');

INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) VALUES (1, 1, NULL, '2025-03-18 08:00:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) VALUES (2, 2, NULL, '2025-03-19 12:00:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) VALUES (3, 3, NULL, '2025-03-20 07:00:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) VALUES (4, 4, NULL, '2025-03-21 09:00:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) VALUES (5, 5, NULL, '2025-03-22 13:00:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) VALUES (6, 6, NULL, '2025-03-23 11:00:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) VALUES (7, 7, NULL, '2025-03-24 08:00:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) VALUES (8, 8, NULL, '2025-03-25 10:00:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) VALUES (9, 9, NULL, '2025-03-26 14:00:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) VALUES (10, 10, NULL, '2025-03-27 12:00:00', 'Pending');

INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) VALUES (1, 1, 'Blood Test', '2025-03-18 10:00:00', NULL, NULL, 'Pending');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) VALUES (2, 2, 'MRI', '2025-03-19 14:00:00', '2025-03-20 14:00:00', 'Normal', 'Completed');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) VALUES (3, 3, 'Urine Test', '2025-03-20 09:00:00', NULL, NULL, 'Pending');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) VALUES (4, 4, 'X-Ray', '2025-03-21 11:00:00', '2025-03-22 11:00:00', 'Fracture detected', 'Completed');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) VALUES (5, 5, 'Blood Culture', '2025-03-22 15:00:00', NULL, NULL, 'Pending');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) VALUES (6, 6, 'CT Scan', '2025-03-23 13:00:00', '2025-03-24 13:00:00', 'No abnormalities', 'Completed');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) VALUES (7, 7, 'Throat Swab', '2025-03-24 10:00:00', NULL, NULL, 'Pending');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) VALUES (8, 8, 'Ultrasound', '2025-03-25 12:00:00', '2025-03-26 12:00:00', 'Normal', 'Completed');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) VALUES (9, 9, 'Skin Biopsy', '2025-03-26 16:00:00', NULL, NULL, 'Pending');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) VALUES (10, 10, 'Joint Fluid Analysis', '2025-03-27 14:00:00', '2025-03-28 14:00:00', 'Inflammation detected', 'Completed');
