using TransportProject.Core.Repository.Concrete;
using TransportProject.Data.Dtos.VehicleDtos;
using TransportProject.Data.Entities;

namespace TransportProject.Core.Repository.Abstract
{
    public interface IVehicleRepository:IBaseRepository<Vehicle>
    {
        Task<List<ResponseVehicle>> GetByUserIdVehicles(int id);
    }
}
