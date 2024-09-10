using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManagmentSystem.Models;
using PatientManagmentSystem.Repository;

namespace PatientManagmentSystem.Controllers
{
	public class PatientController : Controller
	{
		private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;	
        }
        // GET: PatientController
        public ActionResult Index()
		{
			List<Patient> listOfPatients = new List<Patient>();
			listOfPatients = _patientRepository.GetAllPatients().ToList();
			return View(listOfPatients);	
		}

		// GET: PatientController/Details/5
		public ActionResult Details(int id)
		{
		  Patient patient = _patientRepository.GetPatientById(id);	
			return View(patient);
		}

		// GET: PatientController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: PatientController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Patient patient)
		{
			try
			{
				_patientRepository.AddPatient(patient);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: PatientController/Edit/5
		public ActionResult Edit(int id)
		{
			Patient patient=_patientRepository.GetPatientById(id);
			return View(patient);
		}

		// POST: PatientController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Patient patient )
		{
			try
			{

				_patientRepository.UpdatePatient(patient);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: PatientController/Delete/5
		public ActionResult Delete(int id)
		{
			Patient patient = _patientRepository.GetPatientById(id);
			return View(patient);	
		}

		// POST: PatientController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				_patientRepository.DeletePatient(id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
