using alar.DAL.Classes.UserClasses;
using alar.Presentation.Models.SecurityModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alar.Presentation.AutoMapping
{
    public class AutoMapingManager:Profile
    {
        public AutoMapingManager()
        {
            CreateMap<UserClass, CustomerUserRegisterModel>();
            CreateMap<CustomerUserRegisterModel,UserClass>();
        }
    }
}
