using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.HotelManagement.DataObjects.Models
{
    public class Hotel
    {
        public Hotel() { }
        public Hotel(int hotelId, string city, string room, int price)
        {
            HotelId = hotelId;
            City = city;
            Room = room;
            Price = price;
        }
        public int HotelId { get; set; }
        public string City { get; set; }
        public string Room { get; set; }
        public int Price { get; set; }
    }
}
