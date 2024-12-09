using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportProject.Data.Dtos;
using TransportProject.Data.Entities;
using TransportProject.Service.Abstract;
using TransportProject.Service.Concrete;

namespace TransportProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        public readonly JobService _jobService;

        public JobController(JobService jobService)
        {
            _jobService = jobService;
        }

       
        [HttpGet("GetAll")]
        public IActionResult GetAll() {
            var data= _jobService.GetAllJob();
            return Ok(data);

        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var data = _jobService.GetByIdJob(id);
            return Ok(data);

        }
        [HttpGet("GetJobByUserId")]
        public IActionResult GetJobByUserId(int id)
        {
            var data = _jobService.GetJobByUserId(id);
            return Ok(data);

        }
        [HttpGet("GetActiveJobByUserId")]
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
        public IActionResult Add(AddJobRequest add)
        {

            var result=_jobService.AddJob(add.CreateJob, add.Departure, add.Destination);
            return Ok(result);

            
        }
        [HttpPost("AddPhotoJobById")]
        public async Task<IActionResult> AddPhotoJob([FromForm] string id, IFormFile photo)
        {
            var result= await _jobService.AddPhotoJob(id, photo);
            return Ok(result);
        }
      
        [HttpPost("ChangeJobActiveById")]
        public IActionResult ChangeJobActive(int id)
        {
            var data = _jobService.ChangeJobActive(id);
            return Ok(data);

        }
        [HttpPost("ChangeJobInActiveById")]
        public IActionResult ChangeJobInActive(int id)
        {
            var data = _jobService.ChangeJobInActive(id);
            return Ok(data);

        }
        [HttpPost("UpdateJob")]
        public IActionResult UpdateJob(AddJobRequest add)
        {
            var result = _jobService.Update(add.CreateJob, add.Departure, add.Destination);
            return Ok(result);


        }
    }
}
