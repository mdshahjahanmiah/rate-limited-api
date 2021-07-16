using Agoda.HotelManagement.DataObjects.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.HotelManagement.Domain.Interfaces
{
    public interface IHotelManager
    {
        List<Hotel> GetByCity(string name, string sortByPrice);
        List<Hotel> GetByRoom(string type, string sortByPrice);
    }
}
