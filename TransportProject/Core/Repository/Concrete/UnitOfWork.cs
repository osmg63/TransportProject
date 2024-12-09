using TransportProject.Core.Repository.Abstract;
using TransportProject.Data;

namespace TransportProject.Core.Repository.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TransportDbContext _context;
        private IJobRepository _jobRepository;
        private IOfferRepository _offerRepository;
        private IUserRepository _userRepository;
        private IVehicleRepository _vehicleRepository;
        private IDepartureAddressRepository _departureAddressRepository;
        private IDestinationAddressRepository _destinationAddressRepository;
        private ICityRepository _cityRepository;
        private IMessageRepository _messageRepository;

        public UnitOfWork(TransportDbContext context)
        {
            _context = context;
        }



        public IJobRepository JobRepository=> _jobRepository ??= new JobRepository(_context);
        public IDepartureAddressRepository DepartureAddressRepository => _departureAddressRepository ??= new DepartureAddressRepository(_context);
        public IDestinationAddressRepository DestinationAddressRepository => _destinationAddressRepository ??= new DestinationAddressRepository(_context);



        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

        public IOfferRepository OfferRepository => _offerRepository ??= new OfferRepository(_context);

        public IVehicleRepository VehicleRepository => _vehicleRepository ??= new VehicleRepository(_context);

        public ICityRepository CityRepository => _cityRepository ??= new CityRepository(_context);

        public IMessageRepository MessageRepository => _messageRepository ??= new MessageRepository(_context);

        public async Task<int> SaveChangeAsync()
        {
         return await  _context.SaveChangesAsync();
        }
    }
}
