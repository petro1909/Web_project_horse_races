﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_project_horse_races_db.Model
{
    public enum Role {
        USER,
        BOOKMAKER,
        ADMIN
    }
    public class UserRole
    {
        public int Id {set; get;}
        public Role RoleName { set; get; }
        public List<BaseUser> Users { set; get; }
    }
}
