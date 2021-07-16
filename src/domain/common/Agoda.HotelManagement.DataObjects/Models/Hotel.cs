using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Agoda.HotelManagement.DataObjects.Models
{
    /// <summary>
    ///   Represents hotel class as a sequence of object units.
    ///</summary>
    public class Hotel
    {
        public Hotel() 
        {

        }

        /// <summary>
        ///     Initializes a new instance of the hotel object to the value indicated
        ///     by all members.
        /// </summary>
        public Hotel(int hotelId, string city, string room, int price)
        {
            HotelId = hotelId;
            City = city;
            Room = room;
            Price = price;
        }

        /// <summary>
        ///     Gets and sets the hotel id in the current object.
        /// </summary>
        /// <returns>
        ///     The hotel id in the current object.
        ///</returns>
        [JsonPropertyName("hotel_id")]
        public int HotelId { get; set; }

        /// <summary>
        ///     Gets and sets the city in the current object.
        /// </summary>
        /// <returns>
        ///     The city in the current object.
        ///</returns>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        ///     Gets and sets the room in the current object.
        /// </summary>
        /// <returns>
        ///     The room in the current object.
        ///</returns>
        [JsonPropertyName("room")]
        public string Room { get; set; }

        /// <summary>
        ///     Gets and sets the price in the current object.
        /// </summary>
        /// <returns>
        ///     The price in the current object.
        ///</returns>
        [JsonPropertyName("price")]
        public int Price { get; set; }
    }
}
