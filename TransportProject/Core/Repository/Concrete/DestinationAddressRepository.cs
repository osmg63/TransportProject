using System.ComponentModel;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.DbContexts;
using TransportProject.Data.Entities.Location;

namespace TransportProject.Core.Repository.Concrete
{
    public class DestinationAddressRepository : BaseRepository<DestinationAddress>, IDestinationAddressRepository
    {
        private readonly TransportDbContext _context;
        public DestinationAddressRepository(TransportDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
