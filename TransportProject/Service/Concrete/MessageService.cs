using AutoMapper;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.Dtos;
using TransportProject.Data.Entities;

namespace TransportProject.Service.Concrete
{
    public class MessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public ResponseMessageDto Add(ResponseMessageDto message) {
            var data= _unitOfWork.MessageRepository.Add(_mapper.Map<Message>(message));
            var result = _mapper.Map<ResponseMessageDto>(data);
            return result;

        }
        public bool Delete(int id) 
        {
            var message=_unitOfWork.MessageRepository.Get(x=>x.Id == id);
            return _unitOfWork.MessageRepository.Delete(message);
        }
        public Message GetMessage(Message message) {
            return null;
        
        }
        public List<ResponseMessageDto> GetAllMessage()
        {
            var data= _unitOfWork.MessageRepository.GetAll();
            var result= _mapper.Map<List<ResponseMessageDto>>(data);
            return result;

        }
        public List<MessageBoxDto> GetByIdSenderUser(int id) {
            var data=_unitOfWork.UserRepository.Get(x => x.Id == id);
            if (data != null) {
                
                var result=_unitOfWork.MessageRepository.GetByRecipientIdSendMessageUser(id);
                return result;
            }
            return null;
        
        }
        public List<ResponseMessageDto> GetByRecipientIdEndSenderIdMessage(GetByRepeitIdEndSenderIdMessageDto dto)
        {
            if (_unitOfWork.UserRepository.Get(x => x.Id == dto.SenderId) == null || _unitOfWork.UserRepository.Get(x => x.Id == dto.RecipientId) == null)
            { return null; }
            var data=_unitOfWork.MessageRepository.GetByRepeitIdEndSenderIdMessage(dto);
            return data;
            






        }


        





































    }
}
