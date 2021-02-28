using alar.BLL.Interfaces;
using alar.DAL.AlarDataContext;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace alar.BLL.Bussenes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        public UnitOfWork(DataContext _context, IHttpContextAccessor _httpContextAccessor)
        {
            context = _context ?? throw new ArgumentNullException("context can not be null");
            httpContextAccessor = _httpContextAccessor;
        }

        private IAppBaseRepositoriys _BaseRepositoriys;

        public IAppBaseRepositoriys BaseRepositoriys
        {
            get => _BaseRepositoriys ?? (_BaseRepositoriys = new AppBaseRepository(context, httpContextAccessor));
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
