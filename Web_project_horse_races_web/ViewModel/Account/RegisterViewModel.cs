using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_db.Repository;

namespace Web_project_horse_races_web.ViewModel.Account
{
    public class RegisterViewModel
    {
        public string ?Name { set; get; }
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is incorrect")]
        public string Email { set; get; }
        
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Password does't match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { set; get; }
        [Required]
        public int RoleId { set; get; }  
        public static IEnumerable<UserRole> GetUserRoles()
        {
            return new UserRolesRepository().GetAll();
        }
    }
}
