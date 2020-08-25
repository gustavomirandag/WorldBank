using System;
using System.Collections.Generic;
using System.Text;

namespace WorldBank.Common.Domain.Interfaces.Repositories
{
    public interface IRepository<TKey,T> : IQueryRepository<TKey,T>, ICommandRepository<TKey,T>
    {
    }
}
