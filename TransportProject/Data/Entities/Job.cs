using TransportProject.Data.Entities.Location;
using TransportProject.Data.Entities;

public class Job
{
    public int Id { get; set; }
    public string JobName { get; set; }
    public string JobDescription { get; set; }
    public string JobPrice { get; set; }
    public DateTime JobDate { get; set; }
    public bool IsActive { get; set; }
    public string Photo { get; set; }

    public ICollection<Offer> Offers { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; }

    public int DepartureAddressId { get; set; }
    public virtual DepartureAddress DepartureAddress { get; set; }

    public int DestinationAddressId { get; set; }
    public virtual DestinationAddress DestinationAddress { get; set; }
}
