using PatientManagmentSystem.Models;

namespace PatientManagmentSystem.Service
{
	public interface IPatientService
	{
		IEnumerable<Patient> GetAllPatients();
        void AddPatient(Patient patient);
        Patient GetPatientById(int? patientId);
        void UpdatePatient(Patient patient);

        void DeletePatient(int? patientId);



    }
}
