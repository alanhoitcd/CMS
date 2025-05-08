using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DML;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace CMS.DAL
{
    public class DoctorsDAL
    {
        //string insert = "insertDoctors";
        //string update = "updateDoctors";
        //string delete = "deleteDoctors";

        private readonly string connectionString = sqlDatabase.getConnectString();

        public int CheckDoctorsByDoctorId(int doctorId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("checkDoctorsByDoctorId", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DoctorId", doctorId);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public int CheckDoctorsByLicenseNumber(string licenseNumber)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("checkDoctorsByLicenseNumber", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LicenseNumber", licenseNumber);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public int CheckDoctorsByFirstName(string firstName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("checkDoctorsByFirstName", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", firstName);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public int CheckDoctorsBySpecialty(string specialty)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("checkDoctorsBySpecialty", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Specialty", specialty);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public int CheckDoctorsBySchedule(string schedule)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("checkDoctorsBySchedule", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Schedule", schedule);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public DataTable GetAllDoctors()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("getALlDoctors", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Insert(DoctorsDML dml)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("insertDoctors", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", dml.FirstName1);
                    cmd.Parameters.AddWithValue("@LastName", dml.LastName1);
                    cmd.Parameters.AddWithValue("@Specialty", dml.Specialty1);
                    cmd.Parameters.AddWithValue("@LicenseNumber", dml.LicenseNumber1); // Đã sửa từ LircenseNumber1 thành LicenseNumber1
                    cmd.Parameters.AddWithValue("@Schedule", dml.Schedule1);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Update(DoctorsDML dml)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("updateDoctorById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoctorId", dml.DoctorId1);
                    cmd.Parameters.AddWithValue("@FirstName", dml.FirstName1);
                    cmd.Parameters.AddWithValue("@LastName", dml.LastName1);
                    cmd.Parameters.AddWithValue("@Specialty", dml.Specialty1);
                    cmd.Parameters.AddWithValue("@LicenseNumber", dml.LicenseNumber1);
                    cmd.Parameters.AddWithValue("@Schedule", dml.Schedule1);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Delete(DoctorsDML dml)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("deleteDoctorById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoctorId", dml.DoctorId1);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public DataTable GetDoctorById(int doctorId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("getDoctorById", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DoctorId", doctorId);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetDoctorsByFirstName(string firstName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("getDoctorsByFirstName", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", firstName);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetDoctorsBySpecialty(string specialty)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("getDoctorsBySpecialty", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Specialty", specialty);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetDoctorsByLicenseNumber(string licenseNumber)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("getDoctorsByLicenseNumber", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LicenseNumber", licenseNumber);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetDoctorsBySchedule(string schedule)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("getDoctorsBySchedule", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Schedule", schedule);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }



    }
}

