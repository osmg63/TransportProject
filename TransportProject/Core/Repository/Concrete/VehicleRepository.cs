using TransportProject.Core.Repository.Abstract;
using TransportProject.Data;
using TransportProject.Data.Entities;

namespace TransportProject.Core.Repository.Concrete
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        private readonly TransportDbContext _context;
        public VehicleRepository(TransportDbContext context):base(context) {
        
            _context = context;
        }
    }
}
