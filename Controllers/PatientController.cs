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
			return View();
		}

		// GET: PatientController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: PatientController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
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
			return View();
		}

		// POST: PatientController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
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
			return View();
		}

		// POST: PatientController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
