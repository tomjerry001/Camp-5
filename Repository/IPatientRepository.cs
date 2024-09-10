using PatientManagmentSystem.Models;

namespace PatientManagmentSystem.Repository
{
	public interface IPatientRepository
	{
		IEnumerable<Patient> GetAllPatients();
        void AddPatient(Patient patient);
        Patient GetPatientById(int? patientId);
        void UpdatePatient(Patient patient);
        void DeletePatient(int? patientId);


    }
}
