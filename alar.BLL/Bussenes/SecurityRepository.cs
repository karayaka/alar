using alar.BLL.Interfaces;
using alar.DAL.AlarDataContext;
using alar.DAL.Classes.UserClasses;
using alar.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alar.BLL.Bussenes
{
    public class SecurityRepository:ISecurityRepository
    {
        private readonly DataContext context;
        public SecurityRepository(DataContext _context)
        {
            context = _context;
        }
        /// <summary>
        /// Oturumsuz Kullanıcı ekleme İşlemleri İçin
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserClass> AddUser(UserClass user)
        {
            try
            {
                user.CreatedBy = 0;
                user.LastUpdateBy = 0;
                await context.Users.AddAsync(user);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<UserClass> Login(string UserName, string Password)
        {
            return await context.Users.FirstOrDefaultAsync(t => (t.UserName == UserName || t.Email == UserName)
            && t.Password == Password&&t.ObjectStatus==ObjectStatus.NonDeleted);            
        }

        public bool VerifyEmail(string email)
        {
            return context.Users.Any(t => t.Email == email.Trim());
        }

        public bool VerifyUserName(string userName)
        {
            return context.Users.Any(t => t.UserName == userName.Trim());
        }

    }
}
