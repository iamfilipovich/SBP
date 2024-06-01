using Microsoft.AspNetCore.Mvc;
using Hotel.Controllers; // Assuming HotelService is in the Services namespace
using Hotel.Models;
using Hotel.Repositories;

namespace Hotel.Controllers
{
    public class HoteliController : Controller
    {
            private readonly IHotelRepository _hotelRepository;

        public HoteliController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public IActionResult Index()
        {
            return View(_hotelRepository.GetAllHotels());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(hotels hotel)
        {
            _hotelRepository.Create(hotel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string Name)
        {
            var md = _hotelRepository.GetHotelsDetails(Name);
            return View(md);
        }

        [HttpPost]
        public IActionResult EditPost(string _id, hotels hotel)
        {
            _hotelRepository.Update(_id, hotel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string Name)
        {
            var md = _hotelRepository.GetHotelsDetails(Name);
            return View(md);
        }

        [HttpPost]
        public IActionResult DeletePost(string ImeHotela)
        {
            _hotelRepository.Delete(ImeHotela);
            return RedirectToAction("Index");
        }
    }
}
