using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generali.UI.Models.Login
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid username")]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid password")]
        public string Password { get; set; }
    }
}