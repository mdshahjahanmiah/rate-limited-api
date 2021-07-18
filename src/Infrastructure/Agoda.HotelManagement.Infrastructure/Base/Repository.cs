using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agoda.HotelManagement.Infrastructure.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public Repository(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IQueryable<T>> Get()
        {
            return await Task.Run(() => _unitOfWork.QueriesContext.Set<T>().AsQueryable<T>());
        }

        public async Task<IQueryable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => _unitOfWork.QueriesContext.Set<T>().Where(predicate).AsQueryable<T>());
        }
    }
}
