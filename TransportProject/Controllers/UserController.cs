using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportProject.Data.Dtos.UserDtos;
using TransportProject.Data.Validations;
using TransportProject.Service.Abstract;
using TransportProject.Service.Concrete;

namespace TransportProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMailService _mailService;


        public UserController(IUserService userService, IMailService mailService)
        {
            _userService = userService;
            _mailService = mailService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var data = await _userService.GetById(id);
            return Ok(data);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _userService.GetAll();
            return Ok(data);
        }
       
        [HttpGet("Mail-reset")]
        public async Task<IActionResult> MailForPasswordReset(string email)
        {

            await _mailService.SendPasswordMailAsync(email);
            return Ok();
        }
        [HttpGet("UserActiveFalse")]
        public async Task<IActionResult> UserActiveFalse(int id)
        {
            await _userService.UserActiveFalse(id);
            return Ok();
        }
        [HttpGet("download-photo/{fileName}")]
        public async Task<IActionResult> DownloadPhoto(string fileName)
        {
            try
            {
                var fileStream = await _userService.GetPhotoAsync(fileName);
                return File(fileStream, "application/octet-stream", fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error downloading file: {ex.Message}");
            }
        }
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult>  Add(RequestUserDto user)
        {
            var validator = new RequestUserDtoValidator();
            var resultValidator = validator.Validate(user);
            if (!resultValidator.IsValid)
            {
                var data = string.Join("; ", resultValidator.Errors.Select(x => x.ErrorMessage));
                return BadRequest(data);
            }
            await _userService.Add(user);
            return Ok();
        }
        [HttpPost("Update")]
        public  async Task<IActionResult> Update(RequestUserDto user)
        {
             var data=await _userService.Update(user);
            return  Ok(data);
        }
      
      

        [HttpPost("Reset-Password")]
        public  async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        {
            var validator = new ResetPasswordDtoValidator();
            var resultValidator = validator.Validate(dto);
            if (!resultValidator.IsValid)
            {
                var dataValidator = string.Join("; ", resultValidator.Errors.Select(x => x.ErrorMessage));
                return BadRequest(dataValidator);
            }

            var data= await _userService.ResetPassword(dto);
            return Ok(data);
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto login)
        {
            var validator = new UserLoginDtoValidator();
            var resultValidator = validator.Validate(login);
            if (!resultValidator.IsValid)
            {
                var dataValidator = string.Join("; ", resultValidator.Errors.Select(x => x.ErrorMessage));
                return BadRequest(dataValidator);
            }
            var data=await _userService.Login(login);
            return Ok(data);
        }
        [HttpPost("AddPhotoUserById")]
        public async Task<IActionResult> AddPhotoUser([FromForm] string id, IFormFile photo)
        {
            var result = await _userService.AddPhotoUser(id, photo);
            return Ok(result);
        }

    }
}
