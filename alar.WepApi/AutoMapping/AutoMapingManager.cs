using alar.DAL.Classes.UserClasses;
using alar.WepApi.Models.UserModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alar.WepApi.AutoMapping
{
    public class AutoMapingManager:Profile
    {
        public AutoMapingManager()
        {
            CreateMap<UserClass, UserCreateDataModel>();
            CreateMap<UserCreateDataModel, UserClass>();
        }
        
    }
}
