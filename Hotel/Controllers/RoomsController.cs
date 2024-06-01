using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomsRepository _roomsRepository;

        public RoomsController(IRoomsRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }
        public IActionResult Index()
        {
            return View(_roomsRepository.GetAllRooms());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(rooms room)
        {
            _roomsRepository.Create(room);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string Name)
        {
            var md = _roomsRepository.GetRoomDetails(Name);
            return View(md);
        }

        [HttpPost]
        public IActionResult EditPost(string _id, rooms room)
        {
            _roomsRepository.Update(_id, room);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string Name)
        {
            var md = _roomsRepository.GetRoomDetails(Name);
            return View(md);
        }

        [HttpPost]
        public IActionResult DeletePost(string TipSobe)
        {
            _roomsRepository.Delete(TipSobe);
            return RedirectToAction("Index");
        }
    }
}
