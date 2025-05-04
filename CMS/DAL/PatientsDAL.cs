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

        public void Insert(Patients_DML t)
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
    }
}
