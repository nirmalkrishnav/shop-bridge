using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopBridge.DTOs
{
    public class User
    {
        [Required(ErrorMessage = "UserName is required")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
         ErrorMessage = "Please enter a valid email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Passwords must be 8 character long")]
        //[RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W)",
        // ErrorMessage = "Please enter a valid Password")]
        public string Password { get; set; }

    }
}
