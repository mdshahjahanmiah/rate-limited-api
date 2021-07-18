using Agoda.HotelManagement.DataObjects.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agoda.HotelManagement.Domain.Interfaces
{
    public interface IHotelManager
    {
        Task<List<Hotel>> GetByCity(string name, string sortByPrice);
        Task<List<Hotel>> GetByRoom(string type, string sortByPrice);
    }
}
