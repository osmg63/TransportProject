using AutoMapper;
using System;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.Dtos.OfferDtos;
using TransportProject.Data.Entities;
using TransportProject.Service.Abstract;

namespace TransportProject.Service.Concrete
{
    public class OfferService:IOfferService
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OfferService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<ResponseOfferDto> AddOffer(RequestOfferDto offer) { 
        
            
            var data= await _unitOfWork.OfferRepository.Add(_mapper.Map<Offer>(offer));
             await _unitOfWork.SaveChangeAsync();
            return _mapper.Map<ResponseOfferDto>(data);
        
        }

        public async Task<ResponseOfferDto> ChangeOfferActive(int id)
        {
            var data=await _unitOfWork.OfferRepository.Get(x=>x.Id==id);
            if (data==null) return null;
            data.IsActive = true;
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<ResponseOfferDto>(data);

        }
        public async Task<ResponseOfferDto> ChangeOfferInActive(int id)
        {
            var data =await _unitOfWork.OfferRepository.Get(x => x.Id == id);
            if (data == null) return null;
            data.IsActive = false;
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<ResponseOfferDto>(data);
        }

        public async Task<List<ResponseOfferDto>> GetAllOffer()
        {
            var data= await _unitOfWork.OfferRepository.GetAll();
            return _mapper.Map<List<ResponseOfferDto>>(data);

        }
        public List<ResponseOfferDto> GetOfferByUserId(int id) {
            
            var data=_unitOfWork.OfferRepository.GetOffersByUserId( id);

            return _mapper.Map<List<ResponseOfferDto>>(data);

        }
        public async Task<bool> OfferDelete(int id)
        {
            try
            {
                var data=await _unitOfWork.OfferRepository.Get(x=>x.Id==id);
                
                if (data==null) return false;   
                await _unitOfWork.OfferRepository.Delete(data);
                return true;
            }
            catch (Exception ex) { 
                return false;
            
            }
        }
        public async Task<bool> OfferAccept(int id)
        {
            try
            {
                var data=await _unitOfWork.OfferRepository.Get(x=>x.Id==id);
                if (data==null) return false;
                data.IsAccepted = true;
                await _unitOfWork.SaveChangeAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<ResponseOfferDto> GetOfferAcceptByUserId(int id) {

            var data=_unitOfWork.OfferRepository.GetAcceptOffersByUserId(id);
            return _mapper.Map<List<ResponseOfferDto>>(data);


        }









    }
}
