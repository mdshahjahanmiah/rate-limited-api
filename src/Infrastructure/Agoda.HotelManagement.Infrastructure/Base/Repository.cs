using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Agoda.HotelManagement.Infrastructure.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public Repository(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        
        public IEnumerable<T> Get()
        {
            return _unitOfWork.QueriesContext.Set<T>().AsQueryable<T>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.QueriesContext.Set<T>().Where(predicate).AsQueryable<T>();
        }
    }
}
