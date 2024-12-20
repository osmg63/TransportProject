using TransportProject.Data.Dtos.AddressDtos;

namespace TransportProject.Data.Dtos.JobDtos
{
    public class AddJobRequest
    {
        public CreateJobDto CreateJob { get; set; }
        public CreateAddress Departure { get; set; }
        public CreateAddress Destination { get; set; }
    }
}
