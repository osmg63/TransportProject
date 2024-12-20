using Microsoft.AspNetCore.Mvc;
using TransportProject.Data.Dtos.VehicleDtos;
using TransportProject.Service.Abstract;

namespace TransportProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        [HttpGet("GetByUserIdVehicles")]
        public async Task<IActionResult> GetByUserIdVehicles(int id)
        {
            var data=await _vehicleService.GetByUserIdVehicles(id);
            return Ok(data);
        }
        [HttpGet("GetAllVehicle")]
        public async Task<IActionResult> GetAll()
        {
            var data= await _vehicleService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data= await _vehicleService.GetById(id);
            return Ok(data);
        }



        [HttpDelete("Delete")]
        public async Task<IActionResult> Remove(int id)
        {
            var data= await _vehicleService.Remove(id);
            return Ok(data);

        }
        [HttpPost("AddVehicle")]
        public async Task<IActionResult> AddVehicle(RequestVehicle vehicle)
        {
            var data =await _vehicleService.Add(vehicle);
            return Ok(data);
        }

        [HttpPost("UpdateVehicle")]
        public async Task<IActionResult> UpdateVehicle(ResponseVehicle vehicle)
        {
            var data = await _vehicleService.Update(vehicle);
            return Ok(data);
        }















    }
}
