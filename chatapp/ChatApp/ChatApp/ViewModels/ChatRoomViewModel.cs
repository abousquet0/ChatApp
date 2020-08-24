using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.ViewModels
{
    public class ChatRoomViewModel
    {
        public List<Message> Messages { get; set; }
        public int RoomID { get; set; }
        public string CurrentUser { get; set; }
    }
}
