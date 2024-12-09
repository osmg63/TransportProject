using TransportProject.Core.Repository.Abstract;
using TransportProject.Data;
using TransportProject.Data.Dtos;
using TransportProject.Data.Entities.Location;

namespace TransportProject.Core.Repository.Concrete
{
    public class CityRepository:BaseRepository<City>,ICityRepository
    {
        public readonly TransportDbContext _context;

        public CityRepository(TransportDbContext context):base(context) {
        
            _context = context;
        }

        public List<DistrictResponseDto> GetDistrictWithCity(int id)
        {
            var query= from  city in  _context.Cities
                       where city.Id == id
                       join district in _context.Districts on city.Id equals district.CityId
                       select new DistrictResponseDto { 
                            Id = district.Id,
                            CityId = district.CityId,
                            DistrictName=district.DistrictName
                       };

            return query.ToList();



        }
        public List<NeighborhoodResponseDto> GetNeighborhoodWithDistrict(int id)
        {
            var query = from district in _context.Districts
                        where district.Id == id
                        join neighborhood in _context.Neighborhoods on district.Id equals neighborhood.DistrictId
                        select new NeighborhoodResponseDto { 
                            Id=neighborhood.Id,
                            DistrictId=neighborhood.DistrictId,
                            NeighborhoodName=neighborhood.NeighborhoodName,
                            PostalCode=neighborhood.PostalCode,

                        };

            return query.ToList();



        }










    }
}
