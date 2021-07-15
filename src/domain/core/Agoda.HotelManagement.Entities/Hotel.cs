using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.HotelManagement.Entities
{
    public class Hotel : BaseEntity
    {
        public Hotel(string city, int hotelId, string room, decimal price)
        {
            City = city;
            HotelId = hotelId;
            Room = room;
            Price = price;
        }
        public string City { get; set; }
        public int HotelId { get; set; }
        public string Room { get; set; }
        public decimal Price { get; set; }
    }
}
