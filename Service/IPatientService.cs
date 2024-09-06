using PatientManagmentSystem.Models;

namespace PatientManagmentSystem.Service
{
	public interface IPatientService
	{
		IEnumerable<Patient> GetAllPatients();
	}
}
