using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agoda.HotelManagement.Infrastructure.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> Get();
        Task<IQueryable<T>> Get(Expression<Func<T, bool>> predicate);
    }
}
