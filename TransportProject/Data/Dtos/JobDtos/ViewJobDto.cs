namespace TransportProject.Data.Dtos.JobDtos
{
    public class ViewJobDto
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public string JobPrice { get; set; }
        public DateTime JobDate { get; set; }
        public string Photo { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
        public int DepartureAddressId { get; set; }

        public int DestinationAddressId { get; set; }

        public double DepartuerLatitude { get; set; }
        public double DepartureLongitude { get; set; }
        public int DepartureCityId { get; set; }
        public int DepartureDistrictId { get; set; }
        public int DepartureNeighborhoodId { get; set; }
        public string DepartureCityName { get; set; }
        public string DepartureDistrictName { get; set; }

        public string DepartureNeighborhoodName { get; set; }

        public double DestinationLatitude { get; set; }
        public double DestinationLongitude { get; set; }
        public int DestinationCityId { get; set; }
        public int DestinationDistrictId { get; set; }
        public int DestinationNeighborhoodId { get; set; }
        public string DestinationCityName { get; set; }
        public string DestinationDistrictName { get; set; }

        public string DestinationNeighborhoodName { get; set; }




    }
}
