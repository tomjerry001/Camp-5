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
	}
}
