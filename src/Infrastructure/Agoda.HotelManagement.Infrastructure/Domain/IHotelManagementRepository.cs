using Agoda.HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agoda.HotelManagement.Infrastructure.Domain
{
    public interface IHotelManagementRepository
    {
        IQueryable<Hotel> GetByCity(string name, string sortByPrice);

        IQueryable<Hotel> GetByRoom(string type, string sortByPrice);
    }
}
