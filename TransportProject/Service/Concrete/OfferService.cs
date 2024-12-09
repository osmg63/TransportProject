using AutoMapper;
using System;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.Dtos;
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


        public RequestOfferDto AddOffer(RequestOfferDto offer) { 
        
            
            var data=_unitOfWork.OfferRepository.Add(_mapper.Map<Offer>(offer));
            return _mapper.Map<RequestOfferDto>(data);
        
        }

        public Offer ChangeOfferActive(int id)
        {
            var data=_unitOfWork.OfferRepository.Get(x=>x.Id==id);
            if (data==null) return null;
            data.IsActive = true;
            return data;

        }
        public Offer ChangeOfferInActive(int id)
        {
            var data = _unitOfWork.OfferRepository.Get(x => x.Id == id);
            if (data == null) return null;
            data.IsActive = false;
            return data;
        }

        public List<Offer> GetAllOffer()
        {
            return _unitOfWork.OfferRepository.GetAll();
        }
        public List<Offer> GetOfferByUserId(int id) {
            
            var data=_unitOfWork.OfferRepository.GetOffersByUserId( id);

            return data;
        
        }
        public bool OfferDelete(int id)
        {
            try
            {
                var data=_unitOfWork.OfferRepository.Get(x=>x.Id==id);

                if (data==null) return false;   
                _unitOfWork.OfferRepository.Delete(data);
                return true;
            }
            catch (Exception ex) { 
                return false;
            
            }
        }
        public bool OfferAccept(int id)
        {
            try
            {
                var data= _unitOfWork.OfferRepository.Get(x=>x.Id==id);
                if (data==null) return false;
                data.IsAccepted = true;
                _unitOfWork.OfferRepository.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Offer> GetOfferAcceptByUserId(int id) {

            var data=_unitOfWork.OfferRepository.GetAcceptOffersByUserId(id);
            return data;
        
        
        }









    }
}
