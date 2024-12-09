using TransportProject.Core.Repository.Abstract;
using TransportProject.Data;
using TransportProject.Data.Entities.Location;

namespace TransportProject.Core.Repository.Concrete
{
    public class DepartureAddressRepository : BaseRepository<DepartureAddress>, IDepartureAddressRepository
    {
        public readonly TransportDbContext _context;
        public DepartureAddressRepository(TransportDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
