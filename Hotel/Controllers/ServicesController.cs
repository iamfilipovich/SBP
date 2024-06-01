using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServicesRepository _serviceRepository;

        public ServicesController(IServicesRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public IActionResult Index()
        {
            return View(_serviceRepository.GetAllServices());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(services service)
        {
            _serviceRepository.Create(service);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string Name)
        {
            var md = _serviceRepository.GetServiceDetails(Name);
            return View(md);
        }

        [HttpPost]
        public IActionResult EditPost(string _id, services service)
        {
            _serviceRepository.Update(_id, service);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string Name)
        {
            var md = _serviceRepository.GetServiceDetails(Name);
            return View(md);
        }

        [HttpPost]
        public IActionResult DeletePost(string Naziv)
        {
            _serviceRepository.Delete(Naziv);
            return RedirectToAction("Index");
        }
    }
}
