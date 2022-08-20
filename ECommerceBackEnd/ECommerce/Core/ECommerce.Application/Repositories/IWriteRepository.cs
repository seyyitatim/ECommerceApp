using ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(IList<T> model);
        bool Update(T model);
        Task<bool> RemoveAsync(string id);
        bool Remove(T model);
        bool RemoveRange(IList<T> model);
        Task<int> SaveAsync();
    }
}
