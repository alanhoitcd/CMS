﻿-- Tạo cơ sở dữ liệu CMS
CREATE DATABASE CMS;
GO

-- Chuyển sang sử dụng cơ sở dữ liệu CMS
USE CMS;
GO

-- Tạo bảng Users
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
	--Fullname NVARCHAR(100) NOT NULL,
	--SSN NVARCHAR(12) NOT NULL,
    PasswordHash NVARCHAR(256) NOT NULL,
    RoleUsers NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    SecurityQuestion NVARCHAR(256) NOT NULL,
    SecurityAnswerHash NVARCHAR(256) NOT NULL,
    LastLogin DATETIME NULL,
    IsActive BIT DEFAULT 1 NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Patients (
    PatientId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender NVARCHAR(6) NOT NULL CHECK (Gender IN ('Male', 'Female', 'Nam', 'Nữ')),
    PhoneNumber NVARCHAR(15) NOT NULL CHECK (PhoneNumber LIKE '[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
    AddressPatients NVARCHAR(100) NOT NULL,
    SocialSecurityNumber NVARCHAR(12) NOT NULL
        CHECK (SocialSecurityNumber LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
        UNIQUE, -- Thêm ràng buộc UNIQUE ở đây
    IsEncrypted BIT DEFAULT 0 NOT NULL
);

CREATE TABLE Doctors (
    DoctorId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Specialty NVARCHAR(50) NOT NULL,
    LicenseNumber NVARCHAR(20) UNIQUE NOT NULL,
    Schedule NVARCHAR(100) NOT NULL,
);

CREATE TABLE Staff (
    StaffId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    RoleStaff NVARCHAR(50) NOT NULL,
    Contact NVARCHAR(15) NOT NULL CHECK (Contact LIKE '[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
    HireDate DATE NOT NULL CHECK (HireDate <= GETDATE())
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
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate)
VALUES ('user1', 'hashedpass1', 'Admin', 'user1@example.com', 'What is your pet name?', 'hashedanswer1', '2025-04-01 10:00:00', 1, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate)
VALUES ('user2', 'hashedpass2', 'User', 'user2@example.com', 'What is your favorite color?', 'hashedanswer2', NULL, 1, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate)
VALUES ('user3', 'hashedpass3', 'Moderator', 'user3@example.com', 'What is your first school?', 'hashedanswer3', '2025-03-15 14:30:00', 1, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate)
VALUES ('user4', 'hashedpass4', 'User', 'user4@example.com', 'What is your mother maiden name?', 'hashedanswer4', NULL, 0, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate)
VALUES ('user5', 'hashedpass5', 'Admin', 'user5@example.com', 'What is your favorite book?', 'hashedanswer5', '2025-04-05 09:15:00', 1, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate)
VALUES ('user6', 'hashedpass6', 'User', 'user6@example.com', 'What is your first car?', 'hashedanswer6', NULL, 1, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate)
VALUES ('user7', 'hashedpass7', 'Moderator', 'user7@example.com', 'What is your favorite movie?', 'hashedanswer7', '2025-02-20 16:45:00', 1, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate)
VALUES ('user8', 'hashedpass8', 'User', 'user8@example.com', 'What is your childhood nickname?', 'hashedanswer8', NULL, 0, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate)
VALUES ('user9', 'hashedpass9', 'Admin', 'user9@example.com', 'What is your favorite food?', 'hashedanswer9', '2025-04-06 08:00:00', 1, GETDATE());
INSERT INTO Users (Username, PasswordHash, RoleUsers, Email, SecurityQuestion, SecurityAnswerHash, LastLogin, IsActive, CreatedDate)
VALUES ('user10', 'hashedpass10', 'User', 'user10@example.com', 'What is your dream destination?', 'hashedanswer10', NULL, 1, GETDATE());

INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) 
VALUES ('John', 'Doe', '1980-05-15', 'Male', '123-456-7890', '123 Main St', '111111111111', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) 
VALUES ('Jane', 'Smith', '1990-08-22', 'Female', '234-567-8901', '456 Oak St', '222222222222', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) 
VALUES ('Alex', 'Brown', '1975-03-10', 'Female', '345-678-9012', '789 Pine St', '333333333333', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) 
VALUES ('Mary', 'Johnson', '1985-12-01', 'Female', '456-789-0123', '101 Maple St', '444444444444', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) 
VALUES ('Peter', 'Parker', '1995-07-19', 'Male', '567-890-1234', '202 Cedar St', '555555555555', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) 
VALUES ('Lisa', 'Davis', '1988-09-25', 'Female', '678-901-2345', '303 Birch St', '666666666666', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) 
VALUES ('Tom', 'Wilson', '1970-11-30', 'Male', '789-012-3456', '404 Elm St', '777777777777', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) 
VALUES ('Emma', 'Taylor', '1992-02-14', 'Female', '890-123-4567', '505 Spruce St', '888888888888', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) 
VALUES ('James', 'Moore', '1983-06-08', 'Male', '901-234-5678', '606 Willow St', '999999999999', 0);
INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted) 
VALUES ('Sarah', 'Lee', '1998-04-17', 'Female', '012-345-6789', '707 Ash St', '000000000000', 0);

INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) 
VALUES ('Robert', 'Miller', 'Cardiology', 'LIC001', 'Mon-Fri 9-5');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) 
VALUES ('Susan', 'Clark', 'Pediatrics', 'LIC002', 'Tue-Sat 10-6');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) 
VALUES ('David', 'Lewis', 'Neurology', 'LIC003', 'Mon-Wed 8-4');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) 
VALUES ('Emily', 'Walker', 'Orthopedics', 'LIC004', 'Wed-Fri 9-5');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) 
VALUES ('Michael', 'Hall', 'Dermatology', 'LIC005', 'Mon-Fri 10-6');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) 
VALUES ('Laura', 'Allen', 'Oncology', 'LIC006', 'Tue-Thu 8-4');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) 
VALUES ('Chris', 'Young', 'Psychiatry', 'LIC007', 'Mon-Fri 9-5');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) 
VALUES ('Anna', 'King', 'Gastroenterology', 'LIC008', 'Wed-Sat 10-6');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) 
VALUES ('Mark', 'Wright', 'Urology', 'LIC009', 'Mon-Thu 8-4');
INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule) 
VALUES ('Kelly', 'Scott', 'Endocrinology', 'LIC010', 'Tue-Fri 9-5');

INSERT INTO Staff (FirstName, LastName, RoleStaff, Contact, HireDate) 
VALUES ('Nancy', 'Green', 'Nurse', '123-456-7890', '2020-01-15');
INSERT INTO Staff (FirstName, LastName, RoleStaff, Contact, HireDate) 
VALUES ('Brian', 'Adams', 'Receptionist', '234-567-8901', '2021-03-22');
INSERT INTO Staff (FirstName, LastName, RoleStaff, Contact, HireDate) 
VALUES ('Linda', 'Baker', 'Technician', '345-678-9012', '2019-07-10');
INSERT INTO Staff (FirstName, LastName, RoleStaff, Contact, HireDate) 
VALUES ('Paul', 'Gonzalez', 'Nurse', '456-789-0123', '2022-05-01');
INSERT INTO Staff (FirstName, LastName, RoleStaff, Contact, HireDate) 
VALUES ('Diana', 'Nelson', 'Receptionist', '567-890-1234', '2023-02-19');
INSERT INTO Staff (FirstName, LastName, RoleStaff, Contact, HireDate) 
VALUES ('Steve', 'Carter', 'Technician', '678-901-2345', '2020-11-30');
INSERT INTO Staff (FirstName, LastName, RoleStaff, Contact, HireDate) 
VALUES ('Julia', 'Mitchell', 'Nurse', '789-012-3456', '2021-09-14');
INSERT INTO Staff (FirstName, LastName, RoleStaff, Contact, HireDate) 
VALUES ('Kevin', 'Perez', 'Receptionist', '890-123-4567', '2022-12-08');
INSERT INTO Staff (FirstName, LastName, RoleStaff, Contact, HireDate) 
VALUES ('Rachel', 'Roberts', 'Technician', '901-234-5678', '2018-06-17');
INSERT INTO Staff (FirstName, LastName, RoleStaff, Contact, HireDate) 
VALUES ('George', 'Turner', 'Nurse', '012-345-6789', '2023-04-01');

INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) 
VALUES ('MediSupply', 'Tom Hardy', '123-456-7890', 'tom@medisupply.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) 
VALUES ('PharmaCorp', 'Jane Fox', '234-567-8901', 'jane@pharmacorp.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) 
VALUES ('HealthDist', 'Mark Lane', '345-678-9012', 'mark@healthdist.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email)
VALUES ('BioTech', 'Sara Cole', '456-789-0123', 'sara@biotech.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) 
VALUES ('MediWorld', 'John Bale', '567-890-1234', 'john@mediworld.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) 
VALUES ('CarePharma', 'Lisa Ray', '678-901-2345', 'lisa@carepharma.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) 
VALUES ('DrugMart', 'Paul Dean', '789-012-3456', 'paul@drugmart.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) 
VALUES ('LifeSupply', 'Emma Wood', '890-123-4567', 'emma@lifesupply.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) 
VALUES ('HealCo', 'Mike Hill', '901-234-5678', 'mike@healco.com');
INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email) 
VALUES ('PharmaPlus', 'Anna Bell', '012-345-6789', 'anna@pharmaplus.com');

INSERT INTO Labs (LabName, LabAddress) VALUES ('CityLab', '123 Lab St, City');
INSERT INTO Labs (LabName, LabAddress) VALUES ('MediTest', '456 Test Rd, Town');
INSERT INTO Labs (LabName, LabAddress) VALUES ('HealthLab', '789 Health Ave, Village');
INSERT INTO Labs (LabName, LabAddress) VALUES ('BioLab', '101 Bio St, City');
INSERT INTO Labs (LabName, LabAddress) VALUES ('CareLab', '202 Care Rd, Town');
INSERT INTO Labs (LabName, LabAddress) VALUES ('TrueTest', '303 True Ave, Village');
INSERT INTO Labs (LabName, LabAddress) VALUES ('LifeLab', '404 Life St, City');
INSERT INTO Labs (LabName, LabAddress) VALUES ('PureLab', '505 Pure Rd, Town');
INSERT INTO Labs (LabName, LabAddress) VALUES ('WellLab', '606 Well Ave, Village');
INSERT INTO Labs (LabName, LabAddress) VALUES ('ProLab', '707 Pro St, City');

INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) 
VALUES (1, 1, '2026-03-20 10:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) 
VALUES (2, 2, '2026-03-21 14:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) 
VALUES (3, 3, '2026-03-22 09:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) 
VALUES (4, 4, '2026-03-23 11:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) 
VALUES (5, 5, '2026-03-24 15:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) 
VALUES (6, 6, '2026-03-25 13:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) 
VALUES (7, 7, '2026-03-26 10:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) 
VALUES (8, 8, '2026-03-27 14:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) 
VALUES (9, 9, '2026-03-28 09:00', 'Scheduled');
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, AppointmentsStatus) 
VALUES (10, 10, '2026-03-29 11:00', 'Scheduled');

INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) 
VALUES (1, 1, 1, 1, '2026-03-20 10:00', 'Chest pain');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) 
VALUES (2, 2, 2, 2, '2026-03-21 14:00', 'Fever');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) 
VALUES (3, 3, 3, 3, '2026-03-22 09:00', 'Headache');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) 
VALUES (4, 4, 4, 4, '2026-03-23 11:00', 'Back pain');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) 
VALUES (5, 5, 5, 5, '2026-03-24 15:00', 'Cough');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) 
VALUES (6, 6, 6, 6, '2026-03-25 13:00', 'Fatigue');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) 
VALUES (7, 7, 7, 7, '2026-03-26 10:00', 'Sore throat');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) 
VALUES (8, 8, 8, 8, '2026-03-27 14:00', 'Rash');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) 
VALUES (9, 9, 9, 9, '2026-03-28 09:00', 'Stomach pain');
INSERT INTO Visits (PatientId, DoctorId, StaffId, AppointmentId, VisitDate, ChiefComplaint) 
VALUES (10, 10, 10, 10, '2026-03-29 11:00', 'Dizziness');

INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) 
VALUES (1, '120/80', 75, 36.6, 70.5, 170.0, '2026-03-20 10:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) 
VALUES (2, '130/85', 80, 37.2, 65.0, 165.0, '2026-03-21 14:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) 
VALUES (3, '115/75', 70, 36.8, 80.0, 175.0, '2026-03-22 09:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) 
VALUES (4, '140/90', 85, 37.0, 90.0, 180.0, '2026-03-23 11:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) 
VALUES (5, '125/80', 78, 36.9, 60.0, 160.0, '2026-03-24 15:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) 
VALUES (6, '118/78', 72, 36.7, 75.0, 168.0, '2026-03-25 13:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) 
VALUES (7, '135/88', 82, 37.1, 85.0, 172.0, '2026-03-26 10:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) 
VALUES (8, '122/82', 76, 36.5, 68.0, 166.0, '2026-03-27 14:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) 
VALUES (9, '128/84', 79, 37.3, 78.0, 170.0, '2026-03-28 09:00');
INSERT INTO VitalSigns (VisitId, BloodPressure, HeartRate, Temperature, WeightPatient, HeightPatient, RecordDate) 
VALUES (10, '130/86', 81, 36.9, 82.0, 174.0, '2026-03-29 11:00');

INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) 
VALUES (1, 'Angina', 'Patient reports chest pain.', '2026-03-20 10:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) 
VALUES (2, 'Flu', 'Fever and fatigue noted.', '2026-03-21 14:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) 
VALUES (3, 'Migraine', 'Recurrent headaches.', '2026-03-22 09:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) 
VALUES (4, 'Sciatica', 'Lower back pain.', '2026-03-23 11:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) 
VALUES (5, 'Bronchitis', 'Persistent cough.', '2026-03-24 15:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) 
VALUES (6, 'Fatigue', 'No specific cause found.', '2026-03-25 13:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) 
VALUES (7, 'Pharyngitis', 'Sore throat for 3 days.', '2026-03-26 10:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) 
VALUES (8, 'Eczema', 'Rash on arms.', '2026-03-27 14:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) 
VALUES (9, 'Gastritis', 'Stomach pain after meals.', '2026-03-28 09:00', 0);
INSERT INTO MedicalRecords (VisitId, Diagnosis, ClinicalNotes, RecordDate, IsEncrypted) 
VALUES (10, 'Vertigo', 'Dizziness reported.', '2026-03-29 11:00', 0);

INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) 
VALUES (1, '2026-03-20 10:00', 'Take 1 pill daily');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) 
VALUES (2, '2026-03-21 14:00', 'Take 2 pills every 6 hours');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) 
VALUES (3, '2026-03-22 09:00', 'Take 1 pill as needed');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) 
VALUES (4, '2026-03-23 11:00', 'Take 1 pill twice daily');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) 
VALUES (5, '2026-03-24 15:00', 'Take 1 pill every 8 hours');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) 
VALUES (6, '2026-03-25 13:00', 'Take 1 pill daily');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) 
VALUES (7, '2026-03-26 10:00', 'Take 2 pills every 12 hours');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) 
VALUES (8, '2026-03-27 14:00', 'Apply cream twice daily');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) 
VALUES (9, '2026-03-28 09:00', 'Take 1 pill before meals');
INSERT INTO Prescriptions (VisitId, PrescriptionDate, Instructions) 
VALUES (10, '2026-03-29 11:00', 'Take 1 pill as needed');

INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) 
VALUES ('Aspirin', 1, 100, 0.50, '2026-03-18', 'B001');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) 
VALUES ('Paracetamol', 2, 200, 0.30, '2026-06-18', 'B002');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) 
VALUES ('Ibuprofen', 3, 150, 0.75, '2026-09-18', 'B003');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) 
VALUES ('Amoxicillin', 4, 80, 1.20, '2026-12-18', 'B004');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) 
VALUES ('Cetirizine', 5, 120, 0.60, '2027-03-18', 'B005');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) 
VALUES ('Omeprazole', 6, 90, 1.50, '2027-06-18', 'B006');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) 
VALUES ('Loratadine', 7, 110, 0.80, '2027-09-18', 'B007');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) 
VALUES ('Metformin', 8, 130, 1.00, '2027-12-18', 'B008');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) 
VALUES ('Atorvastatin', 9, 140, 1.25, '2028-03-18', 'B009');
INSERT INTO MedicineInventory (MedicineName, SupplierId, QuantityInStock, UnitPrice, ExpirationDate, BatchNumber) 
VALUES ('Losartan', 10, 160, 1.10, '2028-06-18', 'B010');

INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) 
VALUES (1, 1, '1 pill', 30, 0.50);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) 
VALUES (2, 2, '2 pills', 20, 0.30);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) 
VALUES (3, 3, '1 pill', 15, 0.75);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) 
VALUES (4, 4, '1 pill', 10, 1.20);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) 
VALUES (5, 5, '1 pill', 25, 0.60);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) 
VALUES (6, 6, '1 pill', 30, 1.50);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) 
VALUES (7, 7, '2 pills', 20, 0.80);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) 
VALUES (8, 8, 'Apply cream', 15, 1.00);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) 
VALUES (9, 9, '1 pill', 30, 1.25);
INSERT INTO PrescriptionDetails (PrescriptionId, MedicineId, Dosage, Quantity, UnitPrice) 
VALUES (10, 10, '1 pill', 10, 1.10);

INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) 
VALUES (1, 1, 50, '2025-03-10 10:00', '2025-03-15 10:00', 'Delivered');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) 
VALUES (2, 2, 100, '2025-03-11 14:00', NULL, 'Pending');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) 
VALUES (3, 3, 75, '2025-03-12 09:00', '2025-03-17 09:00', 'Delivered');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) 
VALUES (4, 4, 40, '2025-03-13 11:00', NULL, 'Pending');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) 
VALUES (5, 5, 60, '2025-03-14 15:00', '2025-03-18 15:00', 'Delivered');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) 
VALUES (6, 6, 45, '2025-03-15 13:00', NULL, 'Pending');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) 
VALUES (7, 7, 55, '2025-03-16 10:00', '2025-03-18 10:00', 'Delivered');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) 
VALUES (8, 8, 65, '2025-03-17 14:00', NULL, 'Pending');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) 
VALUES (9, 9, 70, '2025-03-18 09:00', '2025-03-18 09:00', 'Delivered');
INSERT INTO Orders (SupplierId, MedicineId, Quantity, OrderDate, DeliveryDate, OrdersStatus) 
VALUES (10, 10, 80, '2025-03-18 11:00', NULL, 'Pending');

INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) 
VALUES (1, 1, 'In', 50, '2025-03-15 10:00', 'Received from supplier');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) 
VALUES (NULL, 2, 'Out', 20, '2025-03-18 14:00', 'Dispensed to patient');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) 
VALUES (3, 3, 'In', 75, '2025-03-17 09:00', 'Received from supplier');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) 
VALUES (NULL, 4, 'Out', 10, '2025-03-18 11:00', 'Dispensed to patient');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) 
VALUES (5, 5, 'In', 60, '2025-03-18 15:00', 'Received from supplier');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) 
VALUES (NULL, 6, 'Out', 30, '2025-03-18 13:00', 'Dispensed to patient');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) 
VALUES (7, 7, 'In', 55, '2025-03-18 10:00', 'Received from supplier');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) 
VALUES (NULL, 8, 'Out', 15, '2025-03-18 14:00', 'Dispensed to patient');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) 
VALUES (9, 9, 'In', 70, '2025-03-18 09:00', 'Received from supplier');
INSERT INTO InventoryTransactions (OrderId, MedicineId, TransactionType, Quantity, TransactionDate, Description) 
VALUES (NULL, 10, 'Out', 10, '2025-03-18 11:00', 'Dispensed to patient');

INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) 
VALUES (1, 'Visit', NULL, 1, 50.00, '2025-03-18 10:00', 'Consultation fee');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) 
VALUES (2, 'Prescription', 2, NULL, 6.00, '2025-03-18 14:00', 'Medicine cost');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) 
VALUES (3, 'Visit', NULL, 3, 50.00, '2025-03-18 09:00', 'Consultation fee');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) 
VALUES (4, 'Prescription', 4, NULL, 12.00, '2025-03-18 11:00', 'Medicine cost');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) 
VALUES (5, 'Visit', NULL, 5, 50.00, '2025-03-18 15:00', 'Consultation fee');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) 
VALUES (6, 'Prescription', 6, NULL, 45.00, '2025-03-18 13:00', 'Medicine cost');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) 
VALUES (7, 'Visit', NULL, 7, 50.00, '2025-03-18 10:00', 'Consultation fee');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) 
VALUES (8, 'Prescription', 8, NULL, 15.00, '2025-03-18 14:00', 'Medicine cost');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) 
VALUES (9, 'Visit', NULL, 9, 50.00, '2025-03-18 09:00', 'Consultation fee');
INSERT INTO Invoices (PatientId, InvoiceType, PrescriptionId, VisitId, TotalAmount, InvoiceDate, InvoicesDescription) 
VALUES (10, 'Prescription', 10, NULL, 11.00, '2025-03-18 11:00', 'Medicine cost');

INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) 
VALUES (1, 50.00, '2025-03-18 10:00', 'Cash', 'Completed');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) 
VALUES (2, 6.00, '2025-03-18 14:00', 'Card', 'Completed');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) 
VALUES (3, 50.00, '2025-03-18 09:00', 'Insurance', 'Pending');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) 
VALUES (4, 12.00, '2025-03-18 11:00', 'Cash', 'Completed');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) 
VALUES (5, 50.00, '2025-03-18 15:00', 'Card', 'Completed');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) 
VALUES (6, 45.00, '2025-03-18 13:00', 'Insurance', 'Pending');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) 
VALUES (7, 50.00, '2025-03-18 10:00', 'Cash', 'Completed');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) 
VALUES (8, 15.00, '2025-03-18 14:00', 'Card', 'Completed');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) 
VALUES (9, 50.00, '2025-03-18 09:00', 'Insurance', 'Pending');
INSERT INTO PaymentTransactions (InvoiceId, Amount, TransactionDate, PaymentMethod, PaymentTransactionsStatus) 
VALUES (10, 11.00, '2025-03-18 11:00', 'Cash', 'Completed');

INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) 
VALUES (1, 1, NULL, '2026-03-20 10:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) 
VALUES (2, 2, NULL, '2026-03-20 14:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) 
VALUES (3, 3, NULL, '2026-03-21 09:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) 
VALUES (4, 4, NULL, '2026-03-22 11:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) 
VALUES (5, 5, NULL, '2026-03-23 15:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) 
VALUES (6, 6, NULL, '2026-03-24 13:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) 
VALUES (7, 7, NULL, '2026-03-25 10:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) 
VALUES (8, 8, NULL, '2026-03-26 14:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) 
VALUES (9, 9, NULL, '2026-03-27 09:00', 'Pending');
INSERT INTO Reminders (PatientId, AppointmentId, VisitId, ReminderDate, StatusReminders) 
VALUES (10, 10, NULL, '2026-03-28 11:00', 'Pending');

INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) 
VALUES (1, 1, 'Blood Test', '2025-03-18 10:00', NULL, NULL, 'Pending');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) 
VALUES (2, 2, 'X-Ray', '2025-03-18 14:00', '2025-03-18 16:00', 'Normal', 'Completed');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) 
VALUES (3, 3, 'MRI', '2025-03-18 09:00', NULL, NULL, 'Pending');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) 
VALUES (4, 4, 'Urine Test', '2025-03-18 11:00', '2025-03-18 13:00', 'Normal', 'Completed');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) 
VALUES (5, 5, 'Blood Test', '2025-03-18 15:00', NULL, NULL, 'Pending');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) 
VALUES (6, 6, 'CT Scan', '2025-03-18 13:00', '2025-03-18 15:00', 'Normal', 'Completed');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) 
VALUES (7, 7, 'Blood Test', '2025-03-18 10:00', NULL, NULL, 'Pending');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) 
VALUES (8, 8, 'Skin Biopsy', '2025-03-18 14:00', '2025-03-18 16:00', 'Normal', 'Completed');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) 
VALUES (9, 9, 'Blood Test', '2025-03-18 09:00', NULL, NULL, 'Pending');
INSERT INTO LabRequests (VisitId, LabId, TestType, RequestDate, ResultDate, Result, StatusLabRequests) 
VALUES (10, 10, 'Ultrasound', '2025-03-18 11:00', '2025-03-18 13:00', 'Normal', 'Completed');

--
--tạo các procedure------------------------------------------------------------------------------
go --procedure select all patient
create procedure getALlPatients
as begin 
select PatientId, FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber from Patients
end
------------------------------------------------------------------------------

go --procedure check patient  by ssn
create procedure checkPatientsBySSN
@SocialSecurityNumber NVARCHAR(12)
as begin
select count(SocialSecurityNumber) from Patients where SocialSecurityNumber = @SocialSecurityNumber
end
------------------------------------------------------------------------------
go --procedure check patient by id
create procedure checkPatientsByID
@PatientId INT
as begin
select count(PatientId) from Patients where PatientId = @PatientId
end
------------------------------------------------------------------------------

go --procedure insert patient
CREATE PROCEDURE insertPatient (
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @DateOfBirth DATE,
    @Gender NVARCHAR(6),
    @PhoneNumber NVARCHAR(15),
    @AddressPatients NVARCHAR(100),
    @SocialSecurityNumber NVARCHAR(12),
    @IsEncrypted BIT = 0
)
AS
BEGIN
    INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, AddressPatients, SocialSecurityNumber, IsEncrypted)
    VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @PhoneNumber, @AddressPatients, @SocialSecurityNumber, @IsEncrypted);
END;
------------------------------------------------------------------------------

go --procedure update patient by ssn(CCCD)	
CREATE PROCEDURE updatePatientBySSN (
	@PatientId INT,
    @SocialSecurityNumber NVARCHAR(12), -- Tham số đầu vào là SocialSecurityNumber để xác định bệnh nhân
    @FirstName NVARCHAR(50) = NULL,    -- Tham số đầu vào cho FirstName (cho phép giá trị NULL nếu không muốn cập nhật)
    @LastName NVARCHAR(50) = NULL,     -- Tham số đầu vào cho LastName (cho phép giá trị NULL nếu không muốn cập nhật)
    @DateOfBirth DATE = NULL,        -- Tham số đầu vào cho DateOfBirth (cho phép giá trị NULL nếu không muốn cập nhật)
    @Gender NVARCHAR(6) = NULL,        -- Tham số đầu vào cho Gender (cho phép giá trị NULL nếu không muốn cập nhật)
    @PhoneNumber NVARCHAR(15) = NULL,   -- Tham số đầu vào cho PhoneNumber (cho phép giá trị NULL nếu không muốn cập nhật)
    @AddressPatients NVARCHAR(100) = NULL,-- Tham số đầu vào cho AddressPatients (cho phép giá trị NULL nếu không muốn cập nhật)
    @IsEncrypted BIT = NULL           -- Tham số đầu vào cho IsEncrypted (cho phép giá trị NULL nếu không muốn cập nhật)
)
AS
BEGIN
        -- Thực hiện cập nhật các trường nếu giá trị tương ứng được cung cấp (không phải là NULL)
        UPDATE Patients
        SET
            FirstName = ISNULL(@FirstName, FirstName),       -- Nếu @FirstName là NULL, giữ nguyên giá trị hiện tại
            LastName = ISNULL(@LastName, LastName),         -- Tương tự cho các trường khác
            DateOfBirth = ISNULL(@DateOfBirth, DateOfBirth),
            Gender = ISNULL(@Gender, Gender),
            PhoneNumber = ISNULL(@PhoneNumber, PhoneNumber),
            AddressPatients = ISNULL(@AddressPatients, AddressPatients),
            IsEncrypted = ISNULL(@IsEncrypted, IsEncrypted),
			SocialSecurityNumber = ISNULL(@SocialSecurityNumber, SocialSecurityNumber)
        WHERE
            PatientId = @PatientId;
END
------------------------------------------------------------------------------

go --procedure delete patient
CREATE PROCEDURE deletePatient (
	@PatientId INT
)
AS
BEGIN
	delete Patients where PatientId = @PatientId;
END;
------------------------------------------------------------------------------

go --procedure Select patient by ssn
CREATE PROCEDURE SelectPatietBySSN (
	@SocialSecurityNumber NVARCHAR(12)
)
AS
BEGIN
	select * from Patients where SocialSecurityNumber = @SocialSecurityNumber;
END;
------------------------------------------------------------------------------

go --procedure Select check Patient sBy FirstName
CREATE PROCEDURE checkPatientsByFirstName (
	@FirstName NVARCHAR(50)
)
AS
BEGIN
	select count(PatientId) from Patients where FirstName = @FirstName;
END;
------------------------------------------------------------------------------

go --procedure Select check Patient sBy Phone
CREATE PROCEDURE checkPatientsByPhoneNumber (
	@PhoneNumber NVARCHAR(15)
)
AS
BEGIN
	select count(PatientId) from Patients where PhoneNumber = @PhoneNumber;
END;
------------------------------------------------------------------------------

go --procedure Select all by firstname
CREATE PROCEDURE getALlPatientsByFirstName (
    @FirstName NVARCHAR(50)
)
AS
BEGIN
	select * from Patients where FirstName = @FirstName;
END;
------------------------------------------------------------------------------

go --procedure Select all by firstname
CREATE PROCEDURE SelectPatietByPhoneNumber (
    @PhoneNumber NVARCHAR(15)
)
AS
BEGIN
	select * from Patients where PhoneNumber = @PhoneNumber;
END;
------------------------------------------------------------------------------
---- Procedure kiểm tra bác sĩ theo DoctorId
--GO
--CREATE PROCEDURE checkDoctorsByDoctorId
--    @DoctorId INT
--AS
--BEGIN
--    SELECT COUNT(DoctorId) FROM Doctors WHERE DoctorId = @DoctorId
--END;

---- Procedure kiểm tra bác sĩ theo LicenseNumber
--GO
--CREATE PROCEDURE checkDoctorsByLicenseNumber
--    @LicenseNumber NVARCHAR(20)
--AS
--BEGIN
--    SELECT COUNT(LicenseNumber) FROM Doctors WHERE LicenseNumber = @LicenseNumber
--END;

---- Procedure kiểm tra bác sĩ theo FirstName
--GO
--CREATE PROCEDURE checkDoctorsByFirstName
--    @FirstName NVARCHAR(50)
--AS
--BEGIN
--    SELECT COUNT(DoctorId) FROM Doctors WHERE FirstName = @FirstName
--END;

---- Procedure kiểm tra bác sĩ theo Specialty
--GO
--CREATE PROCEDURE checkDoctorsBySpecialty
--    @Specialty NVARCHAR(50)
--AS
--BEGIN
--    SELECT COUNT(DoctorId) FROM Doctors WHERE Specialty = @Specialty
--END;

---- Procedure kiểm tra bác sĩ theo Schedule
--GO
--CREATE PROCEDURE checkDoctorsBySchedule
--    @Schedule NVARCHAR(100)
--AS
--BEGIN
--    SELECT COUNT(DoctorId) FROM Doctors WHERE Schedule = @Schedule
--END;

---- Procedure lấy danh sách tất cả bác sĩ
--GO
--CREATE PROCEDURE getALlDoctors
--AS
--BEGIN
--    SELECT * FROM Doctors
--END;

---- Procedure thêm bác sĩ mới
--GO
--CREATE PROCEDURE insertDoctors
--    @UserId INT NULL,
--    @FirstName NVARCHAR(50),
--    @LastName NVARCHAR(50),
--    @Specialty NVARCHAR(50),
--    @LicenseNumber NVARCHAR(20),
--    @Schedule NVARCHAR(100)
--AS
--BEGIN
--    INSERT INTO Doctors (UserId, FirstName, LastName, Specialty, LicenseNumber, Schedule)
--    VALUES (@UserId, @FirstName, @LastName, @Specialty, @LicenseNumber, @Schedule);
--END;

---- Procedure cập nhật bác sĩ theo DoctorId
--GO
--CREATE PROCEDURE updateDoctorById
--    @DoctorId INT,
--    @UserId INT = NULL,
--    @FirstName NVARCHAR(50) = NULL,
--    @LastName NVARCHAR(50) = NULL,
--    @Specialty NVARCHAR(50) = NULL,
--    @LicenseNumber NVARCHAR(20) = NULL,
--    @Schedule NVARCHAR(100) = NULL
--AS
--BEGIN
--    UPDATE Doctors
--    SET
--        UserId = ISNULL(@UserId, UserId),
--        FirstName = ISNULL(@FirstName, FirstName),
--        LastName = ISNULL(@LastName, LastName),
--        Specialty = ISNULL(@Specialty, Specialty),
--        LicenseNumber = ISNULL(@LicenseNumber, LicenseNumber),
--        Schedule = ISNULL(@Schedule, Schedule)
--    WHERE DoctorId = @DoctorId;
--END;

---- Procedure xóa bác sĩ theo DoctorId
--GO
--CREATE PROCEDURE deleteDoctorById
--    @DoctorId INT
--AS
--BEGIN
--    DELETE FROM Doctors WHERE DoctorId = @DoctorId;
--END;

---- Procedure tìm kiếm bác sĩ theo DoctorId
--GO
--CREATE PROCEDURE getDoctorById
--    @DoctorId INT
--AS
--BEGIN
--    SELECT * FROM Doctors WHERE DoctorId = @DoctorId;
--END;

---- Procedure tìm kiếm bác sĩ theo FirstName
--GO
--CREATE PROCEDURE getDoctorsByFirstName
--    @FirstName NVARCHAR(50)
--AS
--BEGIN
--    SELECT * FROM Doctors WHERE FirstName = @FirstName;
--END;

---- Procedure tìm kiếm bác sĩ theo Specialty
--GO
--CREATE PROCEDURE getDoctorsBySpecialty
--    @Specialty NVARCHAR(50)
--AS
--BEGIN
--    SELECT * FROM Doctors WHERE Specialty = @Specialty;
--END;

---- Procedure tìm kiếm bác sĩ theo LicenseNumber
--GO
--CREATE PROCEDURE getDoctorsByLicenseNumber
--    @LicenseNumber NVARCHAR(20)
--AS
--BEGIN
--    SELECT * FROM Doctors WHERE LicenseNumber = @LicenseNumber;
--END;

---- Procedure tìm kiếm bác sĩ theo Schedule
--GO
--CREATE PROCEDURE getDoctorsBySchedule
--    @Schedule NVARCHAR(100)
--AS
--BEGIN
--    SELECT * FROM Doctors WHERE Schedule = @Schedule;
--END;



-- Procedure kiểm tra bác sĩ theo DoctorId
GO
CREATE PROCEDURE checkDoctorsByDoctorId
    @DoctorId INT
AS
BEGIN
    SELECT COUNT(DoctorId) FROM Doctors WHERE DoctorId = @DoctorId
END;

-- Procedure kiểm tra bác sĩ theo LicenseNumber
GO
CREATE PROCEDURE checkDoctorsByLicenseNumber
    @LicenseNumber NVARCHAR(20)
AS
BEGIN
    SELECT COUNT(LicenseNumber) FROM Doctors WHERE LicenseNumber = @LicenseNumber
END;

-- Procedure kiểm tra bác sĩ theo FirstName
GO
CREATE PROCEDURE checkDoctorsByFirstName
    @FirstName NVARCHAR(50)
AS
BEGIN
    SELECT COUNT(DoctorId) FROM Doctors WHERE FirstName = @FirstName
END;

-- Procedure kiểm tra bác sĩ theo Specialty
GO
CREATE PROCEDURE checkDoctorsBySpecialty
    @Specialty NVARCHAR(50)
AS
BEGIN
    SELECT COUNT(DoctorId) FROM Doctors WHERE Specialty = @Specialty
END;

-- Procedure kiểm tra bác sĩ theo Schedule
GO
CREATE PROCEDURE checkDoctorsBySchedule
    @Schedule NVARCHAR(100)
AS
BEGIN
    SELECT COUNT(DoctorId) FROM Doctors WHERE Schedule = @Schedule
END;

-- Procedure lấy danh sách tất cả bác sĩ
GO
CREATE PROCEDURE getALlDoctors
AS
BEGIN
    SELECT * FROM Doctors
END;

-- Procedure thêm bác sĩ mới
GO
CREATE PROCEDURE insertDoctors
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Specialty NVARCHAR(50),
    @LicenseNumber NVARCHAR(20),
    @Schedule NVARCHAR(100)
AS
BEGIN
    INSERT INTO Doctors (FirstName, LastName, Specialty, LicenseNumber, Schedule)
    VALUES (@FirstName, @LastName, @Specialty, @LicenseNumber, @Schedule);
END;

-- Procedure cập nhật bác sĩ theo DoctorId (bỏ @UserId)
GO
CREATE PROCEDURE updateDoctorById
    @DoctorId INT,
    @FirstName NVARCHAR(50) = NULL,
    @LastName NVARCHAR(50) = NULL,
    @Specialty NVARCHAR(50) = NULL,
    @LicenseNumber NVARCHAR(20) = NULL,
    @Schedule NVARCHAR(100) = NULL
AS
BEGIN
    UPDATE Doctors
    SET
        FirstName = ISNULL(@FirstName, FirstName),
        LastName = ISNULL(@LastName, LastName),
        Specialty = ISNULL(@Specialty, Specialty),
        LicenseNumber = ISNULL(@LicenseNumber, LicenseNumber),
        Schedule = ISNULL(@Schedule, Schedule)
    WHERE DoctorId = @DoctorId;
END;

-- Procedure xóa bác sĩ theo DoctorId
GO
CREATE PROCEDURE deleteDoctorById
    @DoctorId INT
AS
BEGIN
    DELETE FROM Doctors WHERE DoctorId = @DoctorId;
END;

-- Procedure tìm kiếm bác sĩ theo DoctorId
GO
CREATE PROCEDURE getDoctorById
    @DoctorId INT
AS
BEGIN
    SELECT * FROM Doctors WHERE DoctorId = @DoctorId;
END;

-- Procedure tìm kiếm bác sĩ theo FirstName
GO
CREATE PROCEDURE getDoctorsByFirstName
    @FirstName NVARCHAR(50)
AS
BEGIN
    SELECT * FROM Doctors WHERE FirstName = @FirstName;
END;

-- Procedure tìm kiếm bác sĩ theo Specialty
GO
CREATE PROCEDURE getDoctorsBySpecialty
    @Specialty NVARCHAR(50)
AS
BEGIN
    SELECT * FROM Doctors WHERE Specialty = @Specialty;
END;

-- Procedure tìm kiếm bác sĩ theo LicenseNumber
GO
CREATE PROCEDURE getDoctorsByLicenseNumber
    @LicenseNumber NVARCHAR(20)
AS
BEGIN
    SELECT * FROM Doctors WHERE LicenseNumber = @LicenseNumber;
END;

-- Procedure tìm kiếm bác sĩ theo Schedule
GO
CREATE PROCEDURE getDoctorsBySchedule
    @Schedule NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Doctors WHERE Schedule = @Schedule;
END;


