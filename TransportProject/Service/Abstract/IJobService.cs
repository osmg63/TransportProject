using TransportProject.Data.Dtos.AddressDtos;
using TransportProject.Data.Dtos.JobDtos;

namespace TransportProject.Service.Abstract
{
    public interface IJobService
    {
        Task<bool> Update(CreateJobDto jobTo, CreateAddress departure, CreateAddress destination);
        List<ViewJobDto> GetAllJob();
        object GetByIdJob(int id);
        object GetJobByUserId(int id);
        object GetActiveJobByUserId(int id);
        Task<Job> AddPhotoJob(string id, IFormFile file);
        Task<Stream> GetPhotoAsync(string fileName);
        Task<ResponseJobDto> AddJob(CreateJobDto Jobto, CreateAddress departure, CreateAddress destination);
        Task<bool> ChangeJobActive(int id);
        Task<bool> ChangeJobInActive(int id);
    }
}
