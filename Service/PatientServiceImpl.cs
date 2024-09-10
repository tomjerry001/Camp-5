using PatientManagmentSystem.Models;
using PatientManagmentSystem.Repository;

namespace PatientManagmentSystem.Service
{
	public class PatientServiceImpl : IPatientService
	{
		private readonly IPatientRepository _patientRepository;

        public PatientServiceImpl(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;	
        }

        public void AddPatient(Patient patient)
        {
            _patientRepository.AddPatient(patient);
        }

        public void DeletePatient(int? patientId)
        {
            _patientRepository.DeletePatient(patientId);
        }

        public IEnumerable<Patient> GetAllPatients()
		{
			return _patientRepository.GetAllPatients();	
		}

        public Patient GetPatientById(int? patientId)
        {
            return _patientRepository.GetPatientById(patientId);
        }

        public void UpdatePatient(Patient patient)
        {
            _patientRepository.UpdatePatient(patient);
        }
    }
}
