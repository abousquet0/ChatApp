using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new RoomLoginViewModel());
        }

        public IActionResult LoginToRoom(RoomLoginViewModel roomLoginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", new RoomLoginViewModel());
            }
            else
                return RedirectToAction("ChatRoom", "Chat");
        }

        [HttpGet]
        public ViewResult CreateRoom()
        {
            return View(new CreateRoomViewModel());
        }

        [HttpPost]
        [ActionName("CreateRoom")]
        public IActionResult CreateRoomPost(string roomName, string password)
        {
            return View();
        }
    }
}