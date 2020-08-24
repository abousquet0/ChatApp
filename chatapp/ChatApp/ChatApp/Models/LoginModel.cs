using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter a username.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter a password.")]
        public string Password { get; set; }
    }
}
