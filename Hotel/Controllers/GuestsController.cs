using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class GuestsController : Controller
    {
        private readonly IGuestsRepository _guestsRepository;

        public GuestsController(IGuestsRepository guestsRepository)
        {
            _guestsRepository = guestsRepository;
        }
        public IActionResult Index()
        {
            return View(_guestsRepository.GetAllGuests());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(guests guest)
        {
            _guestsRepository.Create(guest);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string Name)
        {
            var md = _guestsRepository.GetGuestDetails(Name);
            return View(md);
        }

        [HttpPost]
        public IActionResult EditPost(string _id, guests guest)
        {
            _guestsRepository.Update(_id, guest);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string Name)
        {
            var md = _guestsRepository.GetGuestDetails(Name);
            return View(md);
        }

        [HttpPost]
        public IActionResult DeletePost(string Ime)
        {
            _guestsRepository.Delete(Ime);
            return RedirectToAction("Index");
        }
    }
}
