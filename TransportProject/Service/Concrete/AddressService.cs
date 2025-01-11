using AutoMapper;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.Dtos.AddressDtos;
using TransportProject.Data.Entities.Location;
using TransportProject.Service.Abstract;

namespace TransportProject.Service.Concrete
{
    public class AddressService: IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<CityResponseDto>> GetAllCity() {
            var data= _mapper.Map<List<CityResponseDto>>( await _unitOfWork.CityRepository.GetAll());
            return data;
        }
        public List<DistrictResponseDto> GetDistrictById(int id) { 
        
            var data=_unitOfWork.CityRepository.GetDistrictWithCity(id);
            return data;
        }
        public List<NeighborhoodResponseDto> GetNeighborhoodById(int id) { 
        
            var data=_unitOfWork.CityRepository.GetNeighborhoodWithDistrict(id);
            return data;
        
        }
        public async Task<CityResponseDto> GetCityByName(string name) {

            var  data =await _unitOfWork.CityRepository.Get(x => x.CityName == name);
            if (data == null) return null;
           return _mapper.Map<CityResponseDto>(data);
           
        
        }







    }
}
