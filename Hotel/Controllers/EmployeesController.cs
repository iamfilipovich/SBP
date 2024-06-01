using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesController(IEmployeesRepository employeesRepository)
        {
;
            _employeesRepository = employeesRepository;
        }
        public IActionResult Index()
        {
            return View(_employeesRepository.GetAllServices());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(employees employee)
        {
            _employeesRepository.Create(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string Name)
        {
            var md = _employeesRepository.GetServiceDetails(Name);
            return View(md);
        }

        [HttpPost]
        public IActionResult EditPost(string _id, employees employee)
        {
            _employeesRepository.Update(_id, employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string Name)
        {
            var md = _employeesRepository.GetServiceDetails(Name);
            return View(md);
        }

        [HttpPost]
        public IActionResult DeletePost(string Ime)
        {
            _employeesRepository.Delete(Ime);
            return RedirectToAction("Index");
        }
    }
}
