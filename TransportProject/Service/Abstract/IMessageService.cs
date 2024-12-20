using TransportProject.Data.Dtos.MessageDtos;

namespace TransportProject.Service.Abstract
{
    public interface IMessageService
    {
        Task<ResponseMessageDto> Add(ResponseMessageDto message);
        Task<bool> Delete(int id);
        Task<List<ResponseMessageDto>> GetAllMessage();
        Task<List<MessageBoxDto>> GetByIdSenderUser(int id);
        Task<List<ResponseMessageDto>> GetByRecipientIdEndSenderIdMessage(GetByRepeitIdEndSenderIdMessageDto dto);
    }
}
