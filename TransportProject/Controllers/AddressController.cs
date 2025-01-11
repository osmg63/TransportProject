using Microsoft.AspNetCore.Mvc;
using TransportProject.Service.Abstract;

namespace TransportProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }


        [HttpGet("GetAllCity")]
        public async Task<IActionResult> GetAllCity()
        {
           var data= await _addressService.GetAllCity();
            return Ok(data);



        }
        [HttpGet("GetAllDistrictByCityId/{id}")]
        public IActionResult GetAllDistrictByCityId(int id)
        {
            var data = _addressService.GetDistrictById(id);
            return Ok(data);



        }
        [HttpGet("GetAllNeighborhoodByDistrictId/{id}")]
        public IActionResult GetAllNeighborhoodByDistrictId(int id)
        {
            var data = _addressService.GetNeighborhoodById(id);
            return Ok(data);



        }
        [HttpGet("GetCityByName/{name}")]
        public async Task<IActionResult> GetCityByName(string name)
        {
            var data =await _addressService.GetCityByName(name);
            return Ok(data);



        }




    }
}
