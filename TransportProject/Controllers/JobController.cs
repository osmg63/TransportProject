using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportProject.Data.Dtos.JobDtos;
using TransportProject.Data.Entities;
using TransportProject.Data.Filters;
using TransportProject.Service.Abstract;
using TransportProject.Service.Concrete;

namespace TransportProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        public readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

       
        [HttpGet("GetAll")]
        public IActionResult GetAll() {
            var data= _jobService.GetAllJob();
            return Ok(data);

        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var data = _jobService.GetByIdJob(id);
            return Ok(data);

        }
        [HttpGet("GetJobByUserId/{id}")]
        public IActionResult GetJobByUserId(int id)
        {
            var data = _jobService.GetJobByUserId(id);
            return Ok(data);

        }
        [HttpGet("GetActiveJobByUserId/{id}")]
        public IActionResult GetActiveJobByUserId(int id)
        {
            var data = _jobService.GetActiveJobByUserId(id);
            return Ok(data);

        }
        [HttpGet("download-photo/{fileName}")]
        public async Task<IActionResult> DownloadPhoto(string fileName)
        {
            try
            {
                var fileStream = await _jobService.GetPhotoAsync(fileName);
                return File(fileStream, "application/octet-stream", fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error downloading file: {ex.Message}");
            }
        }

        [HttpPost("AddJob")]
        public async Task<IActionResult> Add(AddJobRequest add)
        {

            var result=await _jobService.AddJob(add.CreateJob, add.Departure, add.Destination);
            return Ok(result);

            
        }
        [HttpPost("AddPhotoJobById")]
        public async Task<IActionResult> AddPhotoJob([FromForm] string id, IFormFile photo)
        {
            var result= await _jobService.AddPhotoJob(id, photo);
            return Ok(result);
        }
      
        [HttpPost("ChangeJobActiveById/{id}")]
        public async Task<IActionResult> ChangeJobActive(int id)
        {
            var data = await _jobService.ChangeJobActive(id);
            return Ok(data);

        }
        [HttpPost("ChangeJobInActiveById/{id}")]
        public async Task<IActionResult> ChangeJobInActive(int id)
        {
            var data = await _jobService.ChangeJobInActive(id);
            return Ok(data);

        }
        [HttpPost("UpdateJob")]
        public async Task<IActionResult> UpdateJob(AddJobRequest add)
        {
            var result = await _jobService.Update(add.CreateJob, add.Departure, add.Destination);
            return Ok(result);


        }
        [HttpPost("Pagination")]
        public async Task<IActionResult> GetPaginationView(FilterDto filter)
        {
            var data = await _jobService.GetPaginationView(filter);

            return Ok(data);
        }
    }
}
