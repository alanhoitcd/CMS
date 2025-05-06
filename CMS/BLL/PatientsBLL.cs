using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DAL;

namespace CMS.BLL
{
    public class PatientsBLL
    {
        PatientsDAL t = new PatientsDAL();
        public bool checkPatientsBySSN(string SSN)
        {
            return t.checkPatientsBySSN(SSN) > 0;
        }

        public bool checkPatientsByID(int patientID)
        {
            return t.checkPatientsByID(patientID) > 0;
        }
        public bool checkPatientsByFirstName(string firstName)
        {
            return t.checkPatientsByFirstName(firstName) > 0;
        }
        public bool checkPatientsByPhoneNumber(string phoneNumber)
        {
            return t.checkPatientsByPhoneNumber(phoneNumber) > 0;
        }
    }
}
