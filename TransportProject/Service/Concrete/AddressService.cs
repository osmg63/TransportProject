using AutoMapper;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.Dtos;
using TransportProject.Data.Entities.Location;

namespace TransportProject.Service.Concrete
{
    public class AddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public List<CityResponseDto> GetAllCity() {
            var data= _mapper.Map<List<CityResponseDto>>(  _unitOfWork.CityRepository.GetAll());
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







    }
}
