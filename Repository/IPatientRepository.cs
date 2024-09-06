using PatientManagmentSystem.Models;

namespace PatientManagmentSystem.Repository
{
	public interface IPatientRepository
	{
		IEnumerable<Patient> GetAllPatients();
	}
}
