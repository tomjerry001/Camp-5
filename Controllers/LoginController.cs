using DemoCoreMVCJune2024.Models;
using DemoCoreMVCJune2024.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DemoCoreMVCJune2024.Controllers
{
    public class LoginController : Controller
    {
        // feild
        private readonly ILoginRepository _loginRepository;

        //Dependency Injection

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        //URL: https://localhost:7005/Login/Index
        [HttpGet]
        public IActionResult Index()
        {
            // Passing the message to the view using ViewBag
            // ViewBag dynamic property that allows you 
            // to pass data from the controller to the view
            ViewBag.Message = "Welcome ";
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind] Login login)
        {
            try
            {
                //call repository Implementation
                string result = _loginRepository.UserCredentials(login);
                if (result =="Admin")
                {
                    ViewBag.Username = login.Username;
                    return View("Admin");
                    //return RedirectToAction("Index", "Home");     
                }
                else if(result=="Doctor")
                {
                    ViewBag.Username = login.Username;
                    return View("Doctor");
                    //return RedirectToAction("Index", "Home");  
                }
                else
                {
                    //ModelState.AddModelError("UserName", "invalid UserName ");
                    ModelState.AddModelError("password", "invalid UserName / password");
                }
                //call repository Implementation
                return View(login);
            }
            catch
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SignUp([Bind] Login login)
        {
            if (ModelState.IsValid)
            {
                _loginRepository.Insertuser(login);
                ViewBag.Message = "Created successfully";
                ModelState.Clear();
            }
            return View(login);
        }
    }
}
