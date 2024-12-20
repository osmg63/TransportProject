using AutoMapper;
using System.Runtime.InteropServices;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.Dtos.VehicleDtos;
using TransportProject.Data.Entities;
using TransportProject.Service.Abstract;

namespace TransportProject.Service.Concrete
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public VehicleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseVehicle> Add(RequestVehicle vehicle)
        {
            var data = _mapper.Map<Vehicle>(vehicle);
            var result = await _unitOfWork.VehicleRepository.Add(data);
            await _unitOfWork.SaveChangeAsync();
            return _mapper.Map<ResponseVehicle>(result);

        }

        public async Task<List<ResponseVehicle>> GetAll()
        {
           var data=await _unitOfWork.VehicleRepository.GetAll();
            return _mapper.Map<List<ResponseVehicle>>(data);
        }

        public async Task<ResponseVehicle> GetById(int id)
        {
            var data= await _unitOfWork.VehicleRepository.Get(x=>x.Id == id);
            return _mapper.Map<ResponseVehicle>(data);
        }

        public async Task<List<ResponseVehicle>> GetByUserIdVehicles(int id)
        {
            var data =await _unitOfWork.VehicleRepository.GetByUserIdVehicles(id);
            return data;
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                var data = await _unitOfWork.VehicleRepository.Get(x => x.Id == id);
                await _unitOfWork.VehicleRepository.Delete(data);
                await _unitOfWork.SaveChangeAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("Kullanıcı silinemedi"+ex.Message);

            }
           
            
        }

        public async Task<ResponseVehicle> Update(ResponseVehicle vehicle)
        {
            try
            {
                var data = await _unitOfWork.VehicleRepository.Get(x => x.Id == vehicle.Id);
                _mapper.Map(vehicle, data);
                await _unitOfWork.SaveChangeAsync();
                return _mapper.Map<ResponseVehicle>(data);

            }
            catch (Exception ex) {
                throw new Exception("update basarisiz");
            
            }
            
        
        }


    }
}
