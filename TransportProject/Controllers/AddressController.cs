using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportProject.Service.Abstract;
using TransportProject.Service.Concrete;

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
