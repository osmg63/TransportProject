using TransportProject.Data.Dtos.OfferDtos;
using TransportProject.Data.Entities;

namespace TransportProject.Service.Abstract
{
    public interface IOfferService
    {
        Task<ResponseOfferDto> AddOffer(RequestOfferDto offer);
        Task<ResponseOfferDto> ChangeOfferActive(int id);
        Task<ResponseOfferDto> ChangeOfferInActive(int id);
        Task<List<ResponseOfferDto>> GetAllOffer();
        Task<bool> OfferDelete(int id);
        List<ResponseOfferDto> GetOfferAcceptByUserId(int id);
        List<ResponseOfferDto> GetOfferByUserId(int id);
        Task<bool> OfferAccept(int id);




    }
}
