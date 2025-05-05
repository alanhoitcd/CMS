using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DML;

namespace CMS.DAL
{
    public class PatientsDAL
    {
        public int checkPatientsBySSN(string SSN)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DAL.sqlDatabase.getConnectString()))
                {
                    conn.Open();
                    string query = "checkPatientsBySSN @SSN";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = SSN;
                        return (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return 0;
            }
        }
        public int checkPatientsByID(int patientID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DAL.sqlDatabase.getConnectString()))
                {
                    conn.Open();
                    string query = "checkPatientsByID @patientID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@patientID", SqlDbType.NVarChar).Value = patientID;
                        return (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return 0;
            }
        }

        public void Insert(PatientsDML t)
        {
            using (SqlConnection connection = new SqlConnection(sqlDatabase.getConnectString()))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("insertPatient", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = t.FirstName1;
                        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = t.LastName1;
                        cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = t.DateOfBirth1;
                        cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = t.Gender1;
                        cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = t.PhoneNumber1;
                        cmd.Parameters.Add("@AddressPatients", SqlDbType.NVarChar).Value = t.AddressPatients1;
                        cmd.Parameters.Add("@SocialSecurityNumber", SqlDbType.NVarChar).Value = t.SocialSecurityNumber1;

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void Update(PatientsDML t)
        {
            string query = "updatePatientBySSN";
            using (SqlConnection connection = new SqlConnection(DAL.sqlDatabase.getConnectString()))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    /*      PatientId INT IDENTITY(1,1) PRIMARY KEY,
                            FirstName NVARCHAR(50) NOT NULL,
                            LastName NVARCHAR(50) NOT NULL,
                            DateOfBirth DATE NOT NULL,
                            Gender NVARCHAR(6) NOT NULL CHECK (Gender IN ('Male', 'Female', 'Nam', 'Nữ')),
                            PhoneNumber NVARCHAR(15) NOT NULL CHECK (PhoneNumber LIKE '[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
                            AddressPatients NVARCHAR(100) NOT NULL,
                            SocialSecurityNumber NVARCHAR(11) NULL CHECK (SocialSecurityNumber LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR SocialSecurityNumber IS NULL),
                            IsEncrypted BIT DEFAULT 0 NOT NULL*/
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PatientId", SqlDbType.NVarChar).Value = t.PatientId1;
                    cmd.Parameters.Add("@SocialSecurityNumber", SqlDbType.NVarChar).Value = t.SocialSecurityNumber1;
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = t.FirstName1;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = t.LastName1;
                    cmd.Parameters.Add("@DateOfBirth   ", SqlDbType.NVarChar).Value = t.DateOfBirth1;
                    cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = t.Gender1;
                    cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = t.PhoneNumber1;
                    cmd.Parameters.Add("@AddressPatients", SqlDbType.NVarChar).Value = t.AddressPatients1;

                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
