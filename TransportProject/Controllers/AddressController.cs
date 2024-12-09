using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportProject.Service.Concrete;

namespace TransportProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }


        [HttpGet("GetAllCity")]
        public IActionResult GetAllCity()
        {
           var data= _addressService.GetAllCity();
            return Ok(data);



        }
        [HttpGet("GetAllDistrictByCityId")]
        public IActionResult GetAllDistrictByCityId(int id)
        {
            var data = _addressService.GetDistrictById(id);
            return Ok(data);



        }
        [HttpGet("GetAllNeighborhoodByDistrictId")]
        public IActionResult GetAllNeighborhoodByDistrictId(int id)
        {
            var data = _addressService.GetNeighborhoodById(id);
            return Ok(data);



        }




    }
}
