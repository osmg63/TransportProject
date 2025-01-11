using Microsoft.EntityFrameworkCore;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.DbContexts;
using TransportProject.Data.Dtos.VehicleDtos;
using TransportProject.Data.Entities;

namespace TransportProject.Core.Repository.Concrete
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        private readonly TransportDbContext _context;
        public VehicleRepository(TransportDbContext context):base(context) {
        
            _context = context;
        }

        public async Task<List<ResponseVehicle>> GetByUserIdVehicles(int id)
        {
            var query=from vehicle in _context.Vehicles
                      join user in _context.Vehicles on id equals user.UserId
                      where vehicle.UserId == id
                      select new ResponseVehicle { 
                            Id = vehicle.Id,
                            UserId = user.UserId,
                            Brand = vehicle.Brand,
                            Model = vehicle.Model,
                            Description = vehicle.Description,
                            VehiclePhoto=vehicle.VehiclePhoto,
                      };
            return await query.ToListAsync();
        }
        








    }
}
