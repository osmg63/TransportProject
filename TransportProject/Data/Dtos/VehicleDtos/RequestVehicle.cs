using TransportProject.Data.Entities;

namespace TransportProject.Data.Dtos.VehicleDtos
{
    public class RequestVehicle
    {
        public string Description { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int  UserId { get; set; }
    }
}
