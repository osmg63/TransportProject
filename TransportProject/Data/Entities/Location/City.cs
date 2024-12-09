using Org.BouncyCastle.Bcpg.OpenPgp;

namespace TransportProject.Data.Entities.Location
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public ICollection<District> Districts { get; set; }
 
      

    }
}
