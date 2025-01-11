using TransportProject.Data.Dtos.OfferDtos;
using TransportProject.Data.Dtos.UserDtos;
using TransportProject.Data.Entities;

namespace TransportProject.Core.Repository.Abstract
{
    public interface IOfferRepository:IBaseRepository<Offer>
    {
        List<Offer> GetOffersByUserId(int UserId);
        List<Offer> GetAcceptOffersByUserId(int UserId);
        Boolean GetUserOfferJob(int UserId, int JobId);
        List<ResponseGetOfferByJobIdUserDto> GetOfferByJobIdUser(int jobId);
            }
}
