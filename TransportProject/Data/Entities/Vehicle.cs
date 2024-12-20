namespace TransportProject.Data.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}
