using alar.DAL.Classes.BaseObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace alar.DAL.Classes.UserClasses
{
    public class UserClass:BaseObject
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
