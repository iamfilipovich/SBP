using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationsRepository _reservationsRepository;

        public ReservationController(IReservationsRepository reservationsRepository)
        {
            _reservationsRepository = reservationsRepository;
        }
        public IActionResult Index()
        {
            return View(_reservationsRepository.GetAllReservations());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(reservations reservation)
        {
            _reservationsRepository.Create(reservation);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string Name)
        {
            var md = _reservationsRepository.GetReservationDetails(Name);
            return View(md);
        }

        [HttpPost]
        public IActionResult EditPost(string _id, reservations reservation)
        {
            _reservationsRepository.Update(_id, reservation);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string Id)
        {
            var md = _reservationsRepository.GetReservationDetails(Id);
            return View(md);
        }

        [HttpPost]
        public IActionResult DeletePost(string GostId)
        {
            _reservationsRepository.Delete(GostId);
            return RedirectToAction("Index");
        }
    }
}
