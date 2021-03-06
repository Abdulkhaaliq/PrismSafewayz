﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectSafeWayz.Models
{
    public class UsersModel
    {
        public string UserName { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public long Points { get; set; } = 200;
        public string Password { get; set; }

    }
}
