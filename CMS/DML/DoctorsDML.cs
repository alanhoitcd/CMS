using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DML
{
    public class DoctorsDML
    {
        /*      DoctorId INT IDENTITY(1,1) PRIMARY KEY,
                FirstName NVARCHAR(50) NOT NULL,
                LastName NVARCHAR(50) NOT NULL,
                Specialty NVARCHAR(50) NOT NULL,
                LicenseNumber NVARCHAR(20) UNIQUE NOT NULL,
                Schedule NVARCHAR(100) NOT NULL,*/

        private int DoctorId;
        private string FirstName;
        private string LastName;
        private string Specialty;
        private string LicenseNumber;
        private string Schedule;

        public DoctorsDML()
        {
        }

        public DoctorsDML(int doctorId, string firstName, string lastName, string specialty, string licenseNumber, string schedule)
        {
            DoctorId1 = doctorId;
            FirstName1 = firstName;
            LastName1 = lastName;
            Specialty1 = specialty;
            LicenseNumber1 = licenseNumber;
            Schedule1 = schedule;
        }

        public int DoctorId1 { get => DoctorId; set => DoctorId = value; }
        public string FirstName1 { get => FirstName; set => FirstName = value; }
        public string LastName1 { get => LastName; set => LastName = value; }
        public string Specialty1 { get => Specialty; set => Specialty = value; }
        public string LicenseNumber1 { get => LicenseNumber; set => LicenseNumber = value; }
        public string Schedule1 { get => Schedule; set => Schedule = value; }
    }
}
