using ChatApp.Data;
using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        IRepositoryWrapper _repositoryWrapper;
        public ChatController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IActionResult ChatRoom()
        {
            List<Message> messages = _repositoryWrapper.Message.FindAll()?.OrderByDescending(m => m.Date).ToList();
            return View(messages);
        }

        public async Task<IActionResult> Create(Message message)
        {
            if (ModelState.IsValid)
            {
                _repositoryWrapper.Message.Create(message);
            }
            return View();
        }
    }
}
