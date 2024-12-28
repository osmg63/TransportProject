using AutoMapper;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.DbContexts;
using TransportProject.Data.Dtos.JobDtos;
using TransportProject.Data.Entities;
using TransportProject.Data.Entities.Location;
using TransportProject.Data.Filters;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace TransportProject.Core.Repository.Concrete
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        private readonly TransportDbContext _context;
        private readonly IMapper _mapper;
        public JobRepository(TransportDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
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
                            UserId = job.UserId,
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
                            UserId = job.UserId,

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
                            UserId = job.UserId,

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
                            UserId = job.UserId,

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

        public async Task<PaginationResult<ViewJobDto>> GetPaginationView(FilterDto filter)
        {

            var ordersQuery = from job in _context.Job
                              join departureAddress in _context.DepartureAddress on job.DepartureAddressId equals departureAddress.Id
                              join destinationAddress in _context.DestinationAddress on job.DestinationAddressId equals destinationAddress.Id
                              join departureCity in _context.Cities on departureAddress.CityId equals departureCity.Id
                              join departureDistrict in _context.Districts on departureAddress.DistrictId equals departureDistrict.Id
                              join departureNeighborhood in _context.Neighborhoods on departureAddress.NeighborhoodId equals departureNeighborhood.Id
                              join destinationCity in _context.Cities on destinationAddress.CityId equals destinationCity.Id
                              join destinationDistrict in _context.Districts on destinationAddress.DistrictId equals destinationDistrict.Id
                              join destinationNeighborhood in _context.Neighborhoods on destinationAddress.NeighborhoodId equals destinationNeighborhood.Id
                              select new ViewJobDto
                              {
                                  Id = job.Id,
                                  JobName = job.JobName,
                                  JobDescription = job.JobDescription,
                                  JobDate = job.JobDate,
                                  JobPrice = job.JobPrice,
                                  Active = job.IsActive,
                                  UserId = job.UserId,
                                  DepartureAddressId = job.DepartureAddressId,
                                  DestinationAddressId = job.DestinationAddressId,
                                  DepartuerLatitude = departureAddress.Latitude,
                                  DepartureLongitude = departureAddress.Longitude,
                                  DepartureCityId = departureAddress.CityId,
                                  DepartureDistrictId = departureAddress.DistrictId,
                                  DepartureNeighborhoodId = departureAddress.NeighborhoodId,
                                  DepartureCityName = departureCity.CityName,
                                  DepartureDistrictName = departureDistrict.DistrictName,
                                  DepartureNeighborhoodName = departureNeighborhood.NeighborhoodName,
                                  DestinationLatitude = destinationAddress.Latitude,
                                  DestinationLongitude = destinationAddress.Longitude,
                                  DestinationCityId = destinationAddress.CityId,
                                  DestinationDistrictId = destinationAddress.DistrictId,
                                  DestinationNeighborhoodId = destinationAddress.NeighborhoodId,
                                  DestinationCityName = destinationCity.CityName,
                                  DestinationDistrictName = destinationDistrict.DistrictName,
                                  DestinationNeighborhoodName = destinationNeighborhood.NeighborhoodName
                              };

            ordersQuery = ordersQuery.ToFilterView(filter);

            var totalCount = await ordersQuery.CountAsync();

            var totalPages = 0;
            var hasNextPage = false;
            var hasPreviousPage = false;

            filter.Offset = Math.Max(0, filter.Offset);
            filter.Limit = Math.Max(1, filter.Limit);
            if (filter.Limit > 0)
            {
                totalPages = (int)Math.Ceiling(totalCount / (double)filter.Limit);
                hasNextPage = (filter.Offset / filter.Limit) < totalPages - 1;
                hasPreviousPage = filter.Offset > 0;
            }

            var items = await ordersQuery
                .Skip(filter.Offset * filter.Limit)
                .Take(filter.Limit)
                .ToListAsync();

            return new PaginationResult<ViewJobDto>
            {
                Items = items,
                HasNextPage = hasNextPage,
                HasPreviousPage = hasPreviousPage,
                TotalPages = totalPages,
                TotalCount = totalCount
            };
        }







    }
}
