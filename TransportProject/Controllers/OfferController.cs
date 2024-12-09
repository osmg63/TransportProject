using Microsoft.AspNetCore.Mvc;
using TransportProject.Data.Dtos;
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
        public IActionResult GetAll() { 
            var  data=_offerService.GetAllOffer();

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
        public IActionResult Delete(int id)
        {
          var data=  _offerService.OfferDelete(id);
            return Ok(data);

        }

        [HttpPost("ChangeOfferActiveById")]
        public IActionResult ChangeOfferActive(int id)
        {
            var data =_offerService.ChangeOfferActive(id);
            return Ok(data);

        }
        [HttpPost("ChangeOfferInActiveById")]
        public IActionResult ChangeOfferInActive(int id)
        {
            var data = _offerService.ChangeOfferInActive(id);
            return Ok(data);

        }
        [HttpPost("AddOffer")]
        public IActionResult Add(RequestOfferDto offer)
        {
            var result = _offerService.AddOffer(offer);
            return Ok(result);
        }
    }
}
