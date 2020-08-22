using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.ViewModels
{
    public class CreateRoomViewModel
    {
        [Required(ErrorMessage = "Please enter a room name.")]
        public string RoomName { get; set; }
        [Required(ErrorMessage = "Please enter a password.")]
        public string Password { get; set; }
    }
}
