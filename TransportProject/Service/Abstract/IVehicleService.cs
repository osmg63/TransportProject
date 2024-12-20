using TransportProject.Data.Dtos.VehicleDtos;
using TransportProject.Data.Entities;

namespace TransportProject.Service.Abstract
{
    public interface IVehicleService
    {
        Task<ResponseVehicle> Add(RequestVehicle vehicle);
        Task<List<ResponseVehicle>> GetByUserIdVehicles(int id);
        Task<bool> Remove(int id);
        Task<List<ResponseVehicle>> GetAll();
        Task<ResponseVehicle> GetById(int id);
        Task<ResponseVehicle> Update(ResponseVehicle vehicle);
    }
}
