using TransportProject.Data.Dtos.OfferDtos;
using TransportProject.Data.Dtos.UserDtos;
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
        Boolean GetUserOfferJob(int UserId, int JobId);

        List<ResponseGetOfferByJobIdUserDto> GetOfferByJobIdUser(int jobId);
        Task<bool> OfferAcceptByOfferId(int id);

    }
}
