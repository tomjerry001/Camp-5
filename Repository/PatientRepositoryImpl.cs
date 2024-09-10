using PatientManagmentSystem.Models;
using System.Data;
using System.Data.SqlClient;

namespace PatientManagmentSystem.Repository
{
	public class PatientRepositoryImpl : IPatientRepository
	{
		private readonly string connectionString;

        public PatientRepositoryImpl(IConfiguration configuration)
        {
			connectionString = configuration.GetConnectionString("ConnectionMVCWin");
        }

        public void AddPatient(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddPatient", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@NewPatientId", patient.PatientId);
                cmd.Parameters.AddWithValue("@RegistrationNo", patient.RegistrationNo);
                cmd.Parameters.AddWithValue("@PatientName", patient.PatientName);
                cmd.Parameters.AddWithValue("@DOB", patient.DOB);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@PhoneNo", patient.PhoneNo);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }

        }

        public void DeletePatient(int? patientId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeletePatient", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientId", patientId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }

        public IEnumerable<Patient> GetAllPatients()
		{
			List<Patient> patients = new List<Patient>();
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					SqlCommand command = new SqlCommand("sp_GetAllPatients", connection);
					command.CommandType = CommandType.StoredProcedure;
					connection.Open();

					SqlDataReader dr = command.ExecuteReader();
					while (dr.Read())
					{
						Patient patient = new Patient();
						patient.PatientId = Convert.ToInt32(dr["PatientId"].ToString());
						patient.RegistrationNo = Convert.ToInt32(dr["RegistrationNo"].ToString()) ;
						patient.PatientName = dr["PatientName"].ToString();
						patient.DOB = Convert.ToDateTime(dr["DOB"]);
						patient.Gender = dr["Gender"].ToString();
						patient.Address = dr["Address"].ToString();
						patient.PhoneNo = dr["PhoneNo"].ToString();

						patients.Add(patient);
					}
					connection.Close();
				}
				return patients;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

        public Patient GetPatientById(int? patientId)
        {
            Patient patient = new Patient();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetPatientById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PatientId", patientId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    patient.PatientId = Convert.ToInt32(dr["PatientId"].ToString());
                    patient.RegistrationNo = Convert.ToInt32(dr["RegistrationNo"].ToString());
                    patient.PatientName = dr["PatientName"].ToString();
                    patient.DOB = Convert.ToDateTime(dr["DOB"]);
                    patient.Gender = dr["Gender"].ToString();
                    patient.Address = dr["Address"].ToString();
                    patient.PhoneNo = dr["PhoneNo"].ToString();

                }
                con.Close();
            }
            return patient;

        }

        public void UpdatePatient(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EditPatient", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientId", patient.PatientId);
                cmd.Parameters.AddWithValue("@RegistrationNo", patient.RegistrationNo);
                cmd.Parameters.AddWithValue("@PatientName", patient.PatientName);
                cmd.Parameters.AddWithValue("@DOB", patient.DOB);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@PhoneNo", patient.PhoneNo);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }

        }
    }
}
