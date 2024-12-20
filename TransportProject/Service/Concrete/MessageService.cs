using AutoMapper;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.Dtos.MessageDtos;
using TransportProject.Data.Entities;
using TransportProject.Service.Abstract;

namespace TransportProject.Service.Concrete
{
    public class MessageService:IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<ResponseMessageDto> Add(ResponseMessageDto message) {
            var data= await _unitOfWork.MessageRepository.Add(_mapper.Map<Message>(message));
            await _unitOfWork.SaveChangeAsync();
            var result = _mapper.Map<ResponseMessageDto>(data);
            return result;

        }
        public async  Task<bool> Delete(int id) 
        {
            var message=await _unitOfWork.MessageRepository.Get(x=>x.Id == id);
            return await _unitOfWork.MessageRepository.Delete(message);
        }
     
        public async Task<List<ResponseMessageDto>> GetAllMessage()
        {
            var data= await _unitOfWork.MessageRepository.GetAll();
            var result= _mapper.Map<List<ResponseMessageDto>>(data);
            return result;

        }
        public async Task<List<MessageBoxDto>> GetByIdSenderUser(int id) {
            var data=await _unitOfWork.UserRepository.Get(x => x.Id == id);
            if (data != null) {
                
                var result=_unitOfWork.MessageRepository.GetByRecipientIdSendMessageUser(id);
                return result;
            }
            return null;
        
        }
        public async Task<List<ResponseMessageDto>> GetByRecipientIdEndSenderIdMessage(GetByRepeitIdEndSenderIdMessageDto dto)
        {
            if (await _unitOfWork.UserRepository.Get(x => x.Id == dto.SenderId) == null
                ||  await _unitOfWork.UserRepository.Get(x => x.Id == dto.RecipientId) == null)
            { return null; }
            var data=_unitOfWork.MessageRepository.GetByRepeitIdEndSenderIdMessage(dto);
            return data;
        }


        





































    }
}
