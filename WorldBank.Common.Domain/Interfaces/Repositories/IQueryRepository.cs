using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorldBank.Common.Domain.Interfaces.Repositories
{
    public interface IQueryRepository<TKey,T>
    {
        Task<T> ReadAsync(TKey id);
        IEnumerable<T> ReadAll();
        Task<IEnumerable<T>> ReadAllAsync();
    }
}
