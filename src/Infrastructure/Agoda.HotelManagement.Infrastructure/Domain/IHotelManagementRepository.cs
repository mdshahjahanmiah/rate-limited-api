using Agoda.HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agoda.HotelManagement.Infrastructure.Domain
{
    public interface IHotelManagementRepository
    {
        Task<IQueryable<Hotel>> GetByCity(string name);

        Task<IQueryable<Hotel>> GetByRoom(string type);
    }
}
