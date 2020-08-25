using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorldBank.Common.Domain.Interfaces.Repositories
{
    public interface ICommandRepository<TKey,T>
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(TKey id);
        void Update(T entity);
        Task<int> SaveChangesAsync();
    }
}
