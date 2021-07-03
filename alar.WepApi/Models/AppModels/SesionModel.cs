using alar.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alar.WepApi.Models.AppModels
{
    public class SesionModel
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserImageMin { get; set; }

        public string UserImageLarge { get; set; }

        public string UserImageOrjin { get; set; }

        public string Token { get; set; }

        public UserTypes UserTypes { get; set; }
    }
}
