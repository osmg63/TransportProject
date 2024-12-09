using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TransportProject.Data.Dtos;
using TransportProject.Data.Entities;
using TransportProject.Service.Abstract;
using TransportProject.Service.Concrete;

namespace TransportProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly MailService _mailService;


        public UserController(IUserService userService, MailService mailService)
        {
            _userService = userService;
            _mailService = mailService;
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {

            var data = _userService.GetById(id);
            return Ok(data);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _userService.GetAll();
            return Ok(data);
        }
       
        [HttpGet("Mail-reset")]
        public async Task<IActionResult> MailForPasswordReset(int id)
        {

            await _mailService.SendPasswordMailAsync(Convert.ToString(id));
            return Ok();
        }
        [HttpGet("UserActiveFalse")]
        public IActionResult UserActiveFalse(int id)
        {
            _userService.UserActiveFalse(id);
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost("Create")]
        public IActionResult Add(RequestUserDto user)
        {
            _userService.Add(user);
            return Ok();
        }
        [HttpPost("Update")]
        public  async Task<IActionResult> Update(RequestUserDto user)
        {
             var data=await _userService.Update(user);
            return  Ok(data);
        }
      
      

        [HttpPost("Reset-Password")]
        public  async Task<IActionResult> ResetPassword(int id, string token, string password)
        {
            
           var data= await _userService.ResetPassword(id, password,token);
            return Ok(data);
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(UserLoginDto login)
        {
            var data=_userService.Login(login);
            return Ok(data);
        }

       
    }
}
