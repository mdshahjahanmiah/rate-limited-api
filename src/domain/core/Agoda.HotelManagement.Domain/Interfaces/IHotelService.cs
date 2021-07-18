using Agoda.HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agoda.HotelManagement.Domain.Interfaces
{
    public interface IHotelService
    {
        Task<IQueryable<Hotel>> GetByCity(string name);
        Task<IQueryable<Hotel>> GetByRoom(string type);
    }
}
