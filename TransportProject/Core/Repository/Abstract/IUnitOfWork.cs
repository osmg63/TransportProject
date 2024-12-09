namespace TransportProject.Core.Repository.Abstract
{
    public interface IUnitOfWork
    {
        IJobRepository JobRepository { get; }
        IUserRepository UserRepository { get; }
        IOfferRepository OfferRepository { get; }
        IVehicleRepository VehicleRepository { get; }
        IDepartureAddressRepository DepartureAddressRepository { get; }
        IDestinationAddressRepository DestinationAddressRepository { get; }
        ICityRepository CityRepository { get; }
        IMessageRepository MessageRepository { get; }


        Task<int> SaveChangeAsync();
    }
}
