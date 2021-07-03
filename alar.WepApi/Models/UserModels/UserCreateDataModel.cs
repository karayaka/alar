using alar.DAL.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alar.WepApi.Models.UserModels
{
    public class UserCreateDataModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int? CustomerID { get; set; }

        public IFormFile File { get; set; }

        public UserTypes UserTypes { get; set; }
    }
}
