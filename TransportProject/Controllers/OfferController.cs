using Microsoft.AspNetCore.Mvc;
using TransportProject.Data.Dtos.OfferDtos;
using TransportProject.Service.Abstract;

namespace TransportProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }
       
        [HttpGet("GetAllOffer")]
        public async Task<IActionResult> GetAll() { 
            var  data= await _offerService.GetAllOffer();

            return Ok(data);
        
        }
        [HttpGet("GetOfferByUserId")]
        public IActionResult GetOffersByUserId(int id) { 
        
            var data=_offerService.GetOfferByUserId(id);
            return Ok(data);
        
        }
        [HttpGet("GetOfferAcceptByUserId")]
        public IActionResult GetOfferAcceptByUserId(int id)
        {

            var data = _offerService.GetOfferAcceptByUserId(id);
            return Ok(data);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
          var data=await  _offerService.OfferDelete(id);
            return Ok(data);

        }

        [HttpPost("ChangeOfferActiveById")]
        public async Task<IActionResult> ChangeOfferActive(int id)
        {
            var data =await _offerService.ChangeOfferActive(id);
            return Ok(data);

        }
        [HttpPost("ChangeOfferInActiveById")]
        public async Task<IActionResult> ChangeOfferInActive(int id)
        {
            var data =await _offerService.ChangeOfferInActive(id);
            return Ok(data);

        }
        [HttpPost("AddOffer")]
        public async  Task<IActionResult> Add(RequestOfferDto offer)
        {
            var result = await _offerService.AddOffer(offer);
            return Ok(result);
        }
    }
}
