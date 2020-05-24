using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ludus.Model
{
    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
