using System;
using System.Collections.Generic;

#nullable disable

namespace Web_project_horse_races_db.Model
{
    public class BaseUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool BanState { set; get; }
        public int RoleId { set; get; }
        public UserRole Role { set; get; }

        public BaseUser() { }
        public BaseUser(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }


        public override string ToString()
        {
            return $"User [\n" +
                $"\tId : {Id}\n" +
                $"\tName : {Name}\n" +
                $"\tEmail : {Email}\n" +
                $"\tPassword : {Password}\n" + 
                $"]";
        }
    }
}
