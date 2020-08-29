using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class ChatRoom
    {
        [Key]
        public int ChatRoomID { get; set; }
        [Required(ErrorMessage = "Please enter a room name.")]
        public string RoomName { get; set; }
        [Required(ErrorMessage = "Please enter a password.")]
        public string Password { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public string Guid { get; set; }
    }
}
