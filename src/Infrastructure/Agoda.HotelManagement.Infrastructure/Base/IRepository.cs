using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Agoda.HotelManagement.Infrastructure.Base
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
    }
}
