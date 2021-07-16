using Agoda.HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.HotelManagement.Domain.Mappers
{
    public static class HotelMapper
    {
        public static DataObjects.Models.Hotel ToObject(this Hotel model) 
        {
            return new DataObjects.Models.Hotel()
            {
                HotelId = model.HotelId,
                City = model.City,
                Room = model.Room,
                Price = model.Price
            };
        }
    }
}
