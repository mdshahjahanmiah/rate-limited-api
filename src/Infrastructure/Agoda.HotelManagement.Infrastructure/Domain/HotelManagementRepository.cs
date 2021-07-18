using Agoda.HotelManagement.Entities;
using Agoda.HotelManagement.Infrastructure.Base;
using System.Linq;
using System.Threading.Tasks;

namespace Agoda.HotelManagement.Infrastructure.Domain
{
    public class HotelManagementRepository : IHotelManagementRepository
    {
        private readonly IRepository<Hotel> _repository;
        public HotelManagementRepository(IRepository<Hotel> repository)
        {
            _repository = repository;
        }

        public async Task<IQueryable<Hotel>> GetByCity(string name)
        {
            var result = await _repository.Get(c => c.City == name);
            return result;
        }

        public async Task<IQueryable<Hotel>> GetByRoom(string type)
        {
            var result = await _repository.Get(c => c.Room == type);
            return result;
        }
    }
}
