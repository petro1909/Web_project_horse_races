using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public class User
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool BanState { set; get; }
        public List<UserBet> UserBets { set; get; }
        public decimal MoneyBalance { set; get; }
        public int RoleId { set; get; }
        public UserRole Role { set; get; }

        public User() : base() { }

        public User(string name, string email, string password) 
        {
            Name = name;
            Email = email;
            Password = password;
            MoneyBalance = 0;
            UserBets = new List<UserBet>();
        }

        public override string ToString()
        {
            return $"User : [\n" +
                $"\tName : {Name}\n" +
                $"\tEmail : {Email}\n" +
                $"\tPassword : {Password}" +
                $"\tIs Banned : {BanState}" +
                $"\tMoneyBalance : {MoneyBalance}\n";
        }
    }
}
