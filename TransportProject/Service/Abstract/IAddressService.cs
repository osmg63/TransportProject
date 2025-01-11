using TransportProject.Data.Dtos.AddressDtos;

namespace TransportProject.Service.Abstract;

public interface IAddressService
{
    Task<List<CityResponseDto>> GetAllCity();
    List<DistrictResponseDto> GetDistrictById(int id);
    List<NeighborhoodResponseDto> GetNeighborhoodById(int id);
    Task<CityResponseDto> GetCityByName(string name);

    }
