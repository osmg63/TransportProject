using TransportProject.Data.Dtos.JobDtos;
using TransportProject.Data.Entities;

namespace TransportProject.Core.Repository.Abstract
{
    public interface IJobRepository:IBaseRepository<Job>
    {
        List<ViewJobDto> GetAllJob();
        ViewJobDto GetById(int id);
        List<ViewJobDto> GetJobByUserId(int id);
        List<ViewJobDto> GetActiveJobByUserId(int id);
    }
}
