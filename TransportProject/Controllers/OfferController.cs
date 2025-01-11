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
        [HttpGet("GetOfferByUserId/{id}")]
        public IActionResult GetOffersByUserId(int id) { 
        
            var data=_offerService.GetOfferByUserId(id);
            return Ok(data);
        
        }
        [HttpGet("GetUserOfferJob/{userId}/{jobId}")]
        public IActionResult GetUserOfferJob(int userId,int jobId)
        {

            var data = _offerService.GetUserOfferJob(userId,jobId);

            return Ok(data);

        }
        [HttpGet("GetOfferAcceptByUserId/{id}")]
        public IActionResult GetOfferAcceptByUserId(int id)
        {

            var data = _offerService.GetOfferAcceptByUserId(id);
            return Ok(data);

        }
        
        [HttpGet("GetOfferByJobIdUser/{id}")]
        public IActionResult GetOfferByJobIdUser(int id)
        {

            var data = _offerService.GetOfferByJobIdUser(id);
            return Ok(data);

        }
        [HttpDelete("OfferDeleteById/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          var data=await  _offerService.OfferDelete(id);
            return Ok(data);

        }

        [HttpPost("ChangeOfferActiveById/{id}")]
        public async Task<IActionResult> ChangeOfferActive(int id)
        {
            var data =await _offerService.ChangeOfferActive(id);
            return Ok(data);

        }
        [HttpPost("ChangeOfferInActiveById/{id}")]
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
        [HttpPost("OfferAcceptByOfferId/{id}")]
        public async Task<IActionResult> OfferAcceptByOfferId(int id)
        {
            var result = await _offerService.OfferAcceptByOfferId(id);
            return Ok(result);
        }
    }
}
