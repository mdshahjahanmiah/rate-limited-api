using Agoda.HotelManagement.Domain.Interfaces;
using Agoda.HotelManagement.Entities;
using Agoda.HotelManagement.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agoda.HotelManagement.Domain.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelManagementRepository _hotelManagementRepository;
        public HotelService(IHotelManagementRepository hotelManagementRepository)
        {
            _hotelManagementRepository = hotelManagementRepository;
        }
       
        public async Task<IQueryable<Hotel>> GetByCity(string name)
        {
            return await _hotelManagementRepository.GetByCity(name);
        }

        public async Task<IQueryable<Hotel>> GetByRoom(string type)
        {
            return await _hotelManagementRepository.GetByRoom(type);
        }


    }
    
}
