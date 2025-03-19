using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DML
{
    public class Patients_DML
    {
        /*
            PatientId INT IDENTITY(1,1) PRIMARY KEY,
            FirstName NVARCHAR(50) NOT NULL,
            LastName NVARCHAR(50) NOT NULL,
            DateOfBirth DATE NOT NULL,
            Gender NVARCHAR(1) NOT NULL CHECK (Gender IN ('M', 'F', 'O')),
            PhoneNumber NVARCHAR(15) NOT NULL CHECK (PhoneNumber LIKE '[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
            AddressPatients NVARCHAR(100) NOT NULL,
            SocialSecurityNumber NVARCHAR(11) NULL CHECK (SocialSecurityNumber LIKE '[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9][0-9][0-9]' OR SocialSecurityNumber IS NULL),
            IsEncrypted BIT DEFAULT 0 NOT NULL*/

        private int PatientId;
        private string FirstName;
        private string LastName;
        private DateTime DateOfBirth;
        private string Gender;
        private string PhoneNumber;
        private string AddressPatients;
        private string SocialSecurityNumber;
        private bool IsEncrypted;

        public Patients_DML()
        {
        }

        public Patients_DML(int patientId, string firstName, string lastName, DateTime dateOfBirth, string gender,
            string phoneNumber, string addressPatients, string socialSecurityNumber, bool isEncrypted)
        {
            PatientId1 = patientId;
            FirstName1 = firstName;
            LastName1 = lastName;
            DateOfBirth1 = dateOfBirth;
            Gender1 = gender;
            PhoneNumber1 = phoneNumber;
            AddressPatients1 = addressPatients;
            SocialSecurityNumber1 = socialSecurityNumber;
            IsEncrypted1 = isEncrypted;
        }

        public int PatientId1 { get => PatientId; set => PatientId = value; }
        public string FirstName1 { get => FirstName; set => FirstName = value; }
        public string LastName1 { get => LastName; set => LastName = value; }
        public DateTime DateOfBirth1 { get => DateOfBirth; set => DateOfBirth = value; }
        public string Gender1 { get => Gender; set => Gender = value; }
        public string PhoneNumber1 { get => PhoneNumber; set => PhoneNumber = value; }
        public string AddressPatients1 { get => AddressPatients; set => AddressPatients = value; }
        public string SocialSecurityNumber1 { get => SocialSecurityNumber; set => SocialSecurityNumber = value; }
        public bool IsEncrypted1 { get => IsEncrypted; set => IsEncrypted = value; }
    }
}
