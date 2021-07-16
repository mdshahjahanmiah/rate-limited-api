using Agoda.HotelManagement.Entities;
using Agoda.HotelManagement.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agoda.HotelManagement.Infrastructure.Domain
{
    public class HotelManagementRepository : IHotelManagementRepository
    {
        private readonly IRepository<Hotel> _repository;
        public HotelManagementRepository(IRepository<Hotel> repository)
        {
            _repository = repository;
        }

        public IQueryable<Hotel> GetByCity(string name, string sortByPrice)
        {
            var result = _repository.Get(c => c.City == name);
            return result;
        }

        public IQueryable<Hotel> GetByRoom(string type, string sortByPrice)
        {
            var result = _repository.Get(c => c.Room == type);
            return result;
        }
    }
}
