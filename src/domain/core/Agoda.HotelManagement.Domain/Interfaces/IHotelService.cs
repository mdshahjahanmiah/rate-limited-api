using Agoda.HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agoda.HotelManagement.Domain.Interfaces
{
    public interface IHotelService
    {
        IQueryable<Hotel> GetByCity(string name, string sortByPrice);
        IQueryable<Hotel> GetByRoom(string type, string sortByPrice);
    }
}
