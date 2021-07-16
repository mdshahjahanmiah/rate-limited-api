using Agoda.HotelManagement.DataObjects.Models;
using Agoda.HotelManagement.Domain.Interfaces;
using Agoda.HotelManagement.Domain.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Agoda.HotelManagement.Common.Enums;

namespace Agoda.HotelManagement.Domain.Managers
{
    public class HotelManager : IHotelManager
    {
        private readonly IHotelService _hotelService;
        public HotelManager(IHotelService hotelService) 
        {
            _hotelService = hotelService;
        }
        public List<Hotel> GetByCity(string name, string sortByPrice)
        {
            var result = _hotelService.GetByCity(name, sortByPrice);
            if (result == null) return new List<Hotel>();

            if (!string.IsNullOrEmpty(sortByPrice)) result = result.OrderByWithDirection(x => x.Price, SortType.IsDescending(sortByPrice));
            return (result.Select(item => HotelMapper.ToObject(item))).ToList();

        }

        public List<Hotel> GetByRoom(string type, string sortByPrice)
        {
            var result = _hotelService.GetByRoom(type, sortByPrice);
            if (result == null) return new List<Hotel>();

            if (!string.IsNullOrEmpty(sortByPrice)) result = result.OrderByWithDirection(x => x.Price, SortType.IsDescending(sortByPrice));
            return (result.Select(item => HotelMapper.ToObject(item))).ToList();
        }
    }
}
