namespace TransportProject.Data.Dtos
{
    public class AddJobRequest
    {
        public CreateJobDto CreateJob { get; set; }
        public CreateAddress Departure {  get; set; }
        public CreateAddress Destination { get; set; }
    }
}
