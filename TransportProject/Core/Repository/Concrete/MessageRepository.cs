using Amazon.Runtime.Internal.Util;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.DbContexts;
using TransportProject.Data.Dtos.MessageDtos;
using TransportProject.Data.Entities;

namespace TransportProject.Core.Repository.Concrete
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        private readonly TransportDbContext _context;
        public MessageRepository(TransportDbContext context) : base(context)
        {
            _context = context;
        }


        //bir kullanıcıya mesage atan kullanıcılar
        public List<MessageBoxDto> GetByRecipientIdSendMessageUser(int id)
        {
            var query = (from message in _context.Messages
                         where message.UserRecipientId == id
                         join user in _context.Users on message.UserSenderId equals user.Id
                         group new { message, user } by user.Id into grouped // Group by UserId
                         select new MessageBoxDto
                         {

                             UserId = grouped.Key,
                             UserName = grouped.FirstOrDefault().user.Name,
                             UserPhoto=grouped.FirstOrDefault().user.UserProfilePhoto,
                             UserSurname = grouped.FirstOrDefault().user.Surname,
                             Message = grouped.OrderByDescending(g => g.message.CreateTime).FirstOrDefault().message.Description,
                             LastMesageTime = grouped.Max(g => g.message.CreateTime), // Select the latest message time
                             IsRead = grouped.OrderByDescending(g => g.message.CreateTime).FirstOrDefault().message.IsRead
                         })
                         .OrderByDescending(m => m.LastMesageTime) // Sort the result by the latest message time
                         .ToList();

            return query;
        }
        //iki kişi arasında geçen konuşmalar
        public List<ResponseMessageDto> GetByRepeitIdEndSenderIdMessage(GetByRepeitIdEndSenderIdMessageDto dto )
        {

            var query=from message in _context.Messages
                      where message.UserSenderId==dto.SenderId && message.UserRecipientId==dto.RecipientId || message.UserRecipientId==dto.SenderId && message.UserSenderId==dto.RecipientId
                      select new ResponseMessageDto{
                            Id = message.Id,
                            Description = message.Description,
                            UserSenderId = message.UserSenderId,
                            UserRecipientId = message.UserRecipientId,
                            IsRead = message.IsRead,
                            CreateTime = message.CreateTime
                      };


                    return query.ToList();
        }



        // sender mesage gönderiyorsa o mesaj sender a ait eğer recipient görürse görüldü true yap yani iki kişi arasında geçen konuşma da recipient olan kişi sender ın mesagelarını görür
       }
    }














