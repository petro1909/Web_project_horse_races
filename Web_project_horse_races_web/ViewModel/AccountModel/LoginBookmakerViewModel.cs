using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web_project_horse_races_web.ViewModel.AccountModel
{
    public class LoginBookmakerViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}
