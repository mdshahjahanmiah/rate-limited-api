using Agoda.HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.HotelManagement.Domain.Interfaces
{
    public interface IHotelManager
    {
        void GetByCity(string name, string sortByPrice);
        void GetByRoom(string type, string sortByPrice);
    }
}
