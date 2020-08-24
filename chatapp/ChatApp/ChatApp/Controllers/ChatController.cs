using ChatApp.Data;
using ChatApp.Models;
using ChatApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        IRepositoryWrapper _repositoryWrapper;
        public ChatController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IActionResult ChatRoom(int chatRoomID)
        {
            ChatRoomViewModel chatRoomViewModel = new ChatRoomViewModel();
            chatRoomViewModel.CurrentUser = User.Identity.Name;
            chatRoomViewModel.Messages = _repositoryWrapper.Message.FindByContition(x => x.ChatRoomID == chatRoomID)?.OrderBy(m => m.Date).ToList();
            chatRoomViewModel.RoomID = chatRoomID;
            return View(chatRoomViewModel);
        }

        public async Task<IActionResult> Create(Message message)
        {
            message.UserName = User.Identity.Name;
            message.Date = DateTime.Now;

            _repositoryWrapper.Message.Create(message);
            _repositoryWrapper.Save();
            return Ok();
        }
    }
}
