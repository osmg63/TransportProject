using TransportProject.Data.Dtos.AddressDtos;
using TransportProject.Data.Entities.Location;

namespace TransportProject.Core.Repository.Abstract
{
    public interface ICityRepository:IBaseRepository<City>
    {
        List<NeighborhoodResponseDto> GetNeighborhoodWithDistrict(int id);
        List<DistrictResponseDto> GetDistrictWithCity(int id);
    }
}
