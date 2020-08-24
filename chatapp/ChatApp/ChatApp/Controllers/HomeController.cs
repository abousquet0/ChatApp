using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading.Tasks;
using ChatApp.Data;
using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ChatApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IRepositoryWrapper _repositoryWrapper;
        public HomeController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public IActionResult Index()
        {
            return View(new ChatRoom());
        }

        public IActionResult LoginToRoom(ChatRoom chatRoom)
        {
            string chatRoomName = chatRoom.RoomName;
            string passwordHash = Tools.ComputeSha256Hash(chatRoom.Password);
            ChatRoom chat = _repositoryWrapper.ChatRoom.FindByContition(x => x.RoomName == chatRoomName && x.Password == passwordHash).FirstOrDefault();

            if (chat == null)
                ModelState.AddModelError("InvalidRoom", "Invalide room name or password.");

            if (!ModelState.IsValid)
            {
                return View("Index", new ChatRoom());
            }
            else
                return RedirectToAction("ChatRoom", "Chat", new { chatRoomID = chat.ChatRoomID });
        }

        [HttpGet]
        public ViewResult CreateRoom()
        {
            return View(new ChatRoom());
        }

        [HttpPost]
        [ActionName("CreateRoom")]
        public IActionResult CreateRoomPost(ChatRoom chatRoom)
        {
            if (_repositoryWrapper.ChatRoom.FindByContition(x => x.RoomName == chatRoom.RoomName).Count() != 0)
                ModelState.AddModelError("InvalidName", "A room already exist with this name.");
            
            if (!ModelState.IsValid)
                return View("CreateRoom", new ChatRoom());

            chatRoom.Password = Tools.ComputeSha256Hash(chatRoom.Password);
            _repositoryWrapper.ChatRoom.Create(chatRoom);
            _repositoryWrapper.Save();

            return RedirectToAction("ChatRoom", "Chat", new { id = chatRoom.ChatRoomID });
        }
    }
}