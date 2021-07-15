using Agoda.HotelManagement.Domain.Interfaces;
using Agoda.HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agoda.HotelManagement.Domain.Services
{
    public class HotelService : IHotelService
    {
        public IQueryable<Hotel> GetByCity(string name, string sortByPrice)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Hotel> GetByRoom(string type, string sortByPrice)
        {
            throw new NotImplementedException();
        }
    }
}
