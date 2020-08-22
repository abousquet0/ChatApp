using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public string Content { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public ChatRoom ChatRoom { get; set; }
        [ForeignKey(nameof(ChatRoom))]
        public int ChatRoomID { get; set; }
    }
}
