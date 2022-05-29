using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web_project_horse_races_web.ViewModel.Account
{
    public class LoginViewModel
    {
        [Required (ErrorMessage = "Email is required")]
        //[EmailAddress (ErrorMessage = "Email is incorrect")]
        public string Email { set; get; }
        
        [Required (ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}
