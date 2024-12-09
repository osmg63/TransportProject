using TransportProject.Core.Repository.Abstract;
using TransportProject.Data;
using TransportProject.Data.Dtos;
using TransportProject.Data.Entities;
using TransportProject.Data.Entities.Location;

namespace TransportProject.Core.Repository.Concrete
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        private readonly TransportDbContext _context;
        public JobRepository(TransportDbContext context) : base(context)
        {
            _context = context;

        }
        public List<ViewJobDto> GetAllJob()
        {
            var query = from job in _context.Job
                        join departureAddress in _context.DepartureAddress on job.DepartureAddressId equals departureAddress.Id
                        join destinationAddress in _context.DestinationAddress on job.DestinationAddressId equals destinationAddress.Id
                        join city in _context.Cities on departureAddress.CityId equals city.Id
                        join district in _context.Districts on departureAddress.DistrictId equals district.Id
                        join neighborhood in _context.Neighborhoods on departureAddress.NeighborhoodId equals neighborhood.Id
                        join cityDestination in _context.Cities on destinationAddress.CityId equals cityDestination.Id
                        join districtDestination in _context.Districts on destinationAddress.DistrictId equals districtDestination.Id
                        join neighborhoodDestination in _context.Neighborhoods on destinationAddress.NeighborhoodId equals neighborhoodDestination.Id
                        select new ViewJobDto()
                        {
                            Id = job.Id,
                            JobName = job.JobName,
                            JobDescription = job.JobDescription,
                            JobDate = job.JobDate,
                            JobPrice = job.JobPrice,
                            Photo=job.Photo,
                            Active = job.IsActive,
                            DepartureAddressId = job.DepartureAddressId,
                            DestinationAddressId = job.DestinationAddressId,
                            DepartuerLatitude = departureAddress.Latitude,
                            DepartureCityId = departureAddress.CityId,
                            DepartureDistrictId = departureAddress.DistrictId,
                            DepartureNeighborhoodId= departureAddress.NeighborhoodId,
                            DepartureCityName = city.CityName,
                            DepartureDistrictName = district.DistrictName,
                            DestinationLatitude = destinationAddress.Latitude,
                            DestinationCityId = destinationAddress.CityId,
                            DestinationDistrictId = destinationAddress.DistrictId,
                            DestinationNeighborhoodId = destinationAddress.NeighborhoodId,
                            DepartureNeighborhoodName = neighborhood.NeighborhoodName,
                            DestinationCityName = cityDestination.CityName,
                            DestinationDistrictName = districtDestination.DistrictName,
                            DestinationNeighborhoodName = neighborhoodDestination.NeighborhoodName,
                        };
            return query.ToList();
        }
        public ViewJobDto GetById(int id)
        {
            var query = from job in _context.Job
                        where job.Id == id
                        join departureAddress in _context.DepartureAddress on job.DepartureAddressId equals departureAddress.Id
                        join destinationAddress in _context.DestinationAddress on job.DestinationAddressId equals destinationAddress.Id
                        join city in _context.Cities on departureAddress.CityId equals city.Id
                        join district in _context.Districts on departureAddress.DistrictId equals district.Id
                        join neighborhood in _context.Neighborhoods on departureAddress.NeighborhoodId equals neighborhood.Id
                        join cityDestination in _context.Cities on destinationAddress.CityId equals cityDestination.Id
                        join districtDestination in _context.Districts on destinationAddress.DistrictId equals districtDestination.Id
                        join neighborhoodDestination in _context.Neighborhoods on destinationAddress.NeighborhoodId equals neighborhoodDestination.Id
                        select new ViewJobDto()
                        {
                            Id = job.Id,
                            JobName = job.JobName,
                            JobDescription = job.JobDescription,
                            JobDate = job.JobDate,
                            JobPrice = job.JobPrice,
                            Active = job.IsActive,
                            DepartureAddressId = job.DepartureAddressId,
                            DestinationAddressId = job.DestinationAddressId,
                            DepartuerLatitude = departureAddress.Latitude,
                            DepartureCityId = departureAddress.CityId,
                            DepartureDistrictId = departureAddress.DistrictId,
                            DepartureNeighborhoodId = departureAddress.NeighborhoodId,
                            DepartureCityName = city.CityName,
                            DepartureDistrictName = district.DistrictName,
                            DestinationLatitude = destinationAddress.Latitude,
                            DestinationCityId = destinationAddress.CityId,
                            DestinationDistrictId = destinationAddress.DistrictId,
                            DestinationNeighborhoodId = destinationAddress.NeighborhoodId,
                            DepartureNeighborhoodName = neighborhood.NeighborhoodName,
                            DestinationCityName = cityDestination.CityName,
                            DestinationDistrictName = districtDestination.DistrictName,
                            DestinationNeighborhoodName = neighborhoodDestination.NeighborhoodName,
                        };
            return query.FirstOrDefault();
        }
        public List<ViewJobDto> GetJobByUserId(int id)
        {
            var query = from job in _context.Job
                        join user in _context.Users  on job.UserId equals id
                        join departureAddress in _context.DepartureAddress on job.DepartureAddressId equals departureAddress.Id
                        join destinationAddress in _context.DestinationAddress on job.DestinationAddressId equals destinationAddress.Id
                        join city in _context.Cities on departureAddress.CityId equals city.Id
                        join district in _context.Districts on departureAddress.DistrictId equals district.Id
                        join neighborhood in _context.Neighborhoods on departureAddress.NeighborhoodId equals neighborhood.Id
                        join cityDestination in _context.Cities on destinationAddress.CityId equals cityDestination.Id
                        join districtDestination in _context.Districts on destinationAddress.DistrictId equals districtDestination.Id
                        join neighborhoodDestination in _context.Neighborhoods on destinationAddress.NeighborhoodId equals neighborhoodDestination.Id
                        select new ViewJobDto()
                        {
                            Id = job.Id,
                            JobName = job.JobName,
                            JobDescription = job.JobDescription,
                            JobDate = job.JobDate,
                            JobPrice = job.JobPrice,
                            Active = job.IsActive,
                            DepartureAddressId = job.DepartureAddressId,
                            DestinationAddressId = job.DestinationAddressId,
                            DepartuerLatitude = departureAddress.Latitude,
                            DepartureCityId = departureAddress.CityId,
                            DepartureDistrictId = departureAddress.DistrictId,
                            DepartureNeighborhoodId = departureAddress.NeighborhoodId,
                            DepartureCityName = city.CityName,
                            DepartureDistrictName = district.DistrictName,
                            DestinationLatitude = destinationAddress.Latitude,
                            DestinationCityId = destinationAddress.CityId,
                            DestinationDistrictId = destinationAddress.DistrictId,
                            DestinationNeighborhoodId = destinationAddress.NeighborhoodId,
                            DepartureNeighborhoodName = neighborhood.NeighborhoodName,
                            DestinationCityName = cityDestination.CityName,
                            DestinationDistrictName = districtDestination.DistrictName,
                            DestinationNeighborhoodName = neighborhoodDestination.NeighborhoodName,
                        };
            return query.ToList();
        }

        public List<ViewJobDto> GetActiveJobByUserId(int id)
        {
            var query = from job in _context.Job
                        where job.IsActive==true
                        join user in _context.Users on job.UserId equals id
                        join departureAddress in _context.DepartureAddress on job.DepartureAddressId equals departureAddress.Id
                        join destinationAddress in _context.DestinationAddress on job.DestinationAddressId equals destinationAddress.Id
                        join city in _context.Cities on departureAddress.CityId equals city.Id
                        join district in _context.Districts on departureAddress.DistrictId equals district.Id
                        join neighborhood in _context.Neighborhoods on departureAddress.NeighborhoodId equals neighborhood.Id
                        join cityDestination in _context.Cities on destinationAddress.CityId equals cityDestination.Id
                        join districtDestination in _context.Districts on destinationAddress.DistrictId equals districtDestination.Id
                        join neighborhoodDestination in _context.Neighborhoods on destinationAddress.NeighborhoodId equals neighborhoodDestination.Id
                        select new ViewJobDto()
                        {
                            Id = job.Id,
                            JobName = job.JobName,
                            JobDescription = job.JobDescription,
                            JobDate = job.JobDate,
                            JobPrice = job.JobPrice,
                            Active = job.IsActive,
                            DepartureAddressId = job.DepartureAddressId,
                            DestinationAddressId = job.DestinationAddressId,
                            DepartuerLatitude = departureAddress.Latitude,
                            DepartureCityId = departureAddress.CityId,
                            DepartureDistrictId = departureAddress.DistrictId,
                            DepartureNeighborhoodId = departureAddress.NeighborhoodId,
                            DepartureCityName = city.CityName,
                            DepartureDistrictName = district.DistrictName,
                            DestinationLatitude = destinationAddress.Latitude,
                            DestinationCityId = destinationAddress.CityId,
                            DestinationDistrictId = destinationAddress.DistrictId,
                            DestinationNeighborhoodId = destinationAddress.NeighborhoodId,
                            DepartureNeighborhoodName = neighborhood.NeighborhoodName,
                            DestinationCityName = cityDestination.CityName,
                            DestinationDistrictName = districtDestination.DistrictName,
                            DestinationNeighborhoodName = neighborhoodDestination.NeighborhoodName,
                        };
            return query.ToList();
        }






    }
}
