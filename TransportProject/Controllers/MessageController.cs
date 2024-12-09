using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportProject.Data.Dtos;
using TransportProject.Data.Entities;
using TransportProject.Service.Concrete;

namespace TransportProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public readonly MessageService _messageService;

        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }


        [HttpGet("messagebox")]
        public IActionResult GetByIdSenderUser(int id) { 
            var result=_messageService.GetByIdSenderUser(id);
            return Ok(result);
            
        
        }
        [HttpPost("AddMessage")]
        public IActionResult Add(ResponseMessageDto message)
        {
            var result = _messageService.Add(message);
            return Ok(result);


        }
        [HttpGet("GetAllMessage")]
        public IActionResult GetAllMessage()
        {
            var result = _messageService.GetAllMessage();
            return Ok(result);


        }
        
       [HttpPost("GetByRepeitIdEndSenderIdMessage")]
       public IActionResult GetByRepeitIdEndSenderIdMessage(GetByRepeitIdEndSenderIdMessageDto dto)
       {
            var result = _messageService.GetByRecipientIdEndSenderIdMessage(dto);
            return Ok(result);


       }





    }
}
