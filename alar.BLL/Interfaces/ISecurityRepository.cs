using alar.DAL.Classes.UserClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace alar.BLL.Interfaces
{
    public interface ISecurityRepository
    {
        Task<UserClass> AddUser(UserClass user);

        Task<UserClass> Login(string UserName, string Password);
        
        bool VerifyEmail(string email);

        bool VerifyUserName(string userName);
    }
}
