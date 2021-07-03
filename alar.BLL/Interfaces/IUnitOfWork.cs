using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace alar.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        IAppBaseRepositoriys BaseRepositoriys { get; }

        ISecurityRepository SecurityRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
