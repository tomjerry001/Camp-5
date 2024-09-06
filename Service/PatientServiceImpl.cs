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
        public IEnumerable<Patient> GetAllPatients()
		{
			return _patientRepository.GetAllPatients();	
		}
	}
}
