namespace TransportProject.Data.Entities.Location
{
    public class District
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public virtual City City { get; set; }  
        public int CityId { get; set; }

        public ICollection<Neighborhood> Neighborhoods { get; set; }
    }
}
