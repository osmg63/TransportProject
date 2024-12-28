using TransportProject.Data.Entities;

namespace TransportProject.Data.Dtos.VehicleDtos
{
    public class ResponseVehicle
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string VehiclePhoto { get; set; }
        public int UserId { get; set; }
    }
}
