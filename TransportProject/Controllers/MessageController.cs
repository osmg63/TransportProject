using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportProject.Data.Dtos.MessageDtos;
using TransportProject.Data.Entities;
using TransportProject.Service.Abstract;
using TransportProject.Service.Concrete;

namespace TransportProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        [HttpGet("messagebox")]
        public async Task<IActionResult> GetByIdSenderUser(int id) { 
            var result= await _messageService.GetByIdSenderUser(id);
            return Ok(result);
            
        
        }
        [HttpPost("AddMessage")]
        public async Task<IActionResult> Add(ResponseMessageDto message)
        {
            var result =await _messageService.Add(message);
            return Ok(result);


        }
        [HttpGet("GetAllMessage")]
        public async Task<IActionResult> GetAllMessage()
        {
            var result =await _messageService.GetAllMessage();
            return Ok(result);


        }
        
       [HttpPost("GetByRepeitIdEndSenderIdMessage")]
       public async Task<IActionResult> GetByRepeitIdEndSenderIdMessage(GetByRepeitIdEndSenderIdMessageDto dto)
       {
            var result =await _messageService.GetByRecipientIdEndSenderIdMessage(dto);
            return Ok(result);


       }





    }
}
