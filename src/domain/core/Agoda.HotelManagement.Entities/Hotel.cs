using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agoda.HotelManagement.Entities
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        public string City { get; set; }
        public string Room { get; set; }
        public int Price { get; set; }
    }
}
