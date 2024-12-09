using TransportProject.Data.Dtos;
using TransportProject.Data.Entities;

namespace TransportProject.Core.Repository.Abstract
{
    public interface IMessageRepository:IBaseRepository<Message>
    {
        List<MessageBoxDto> GetByRecipientIdSendMessageUser(int id);
        List<ResponseMessageDto> GetByRepeitIdEndSenderIdMessage(GetByRepeitIdEndSenderIdMessageDto dto);
    }
}
