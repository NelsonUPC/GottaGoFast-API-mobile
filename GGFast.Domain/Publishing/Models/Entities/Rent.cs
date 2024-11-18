namespace GottaGoFast.Domain.Publishing.Models.Entities;

public class Rent : BaseModel
{
    public string Status { get; set; }
    public DateOnly PickupDate { get; set; }
    public DateOnly DropoffDate { get; set; }
    
    public string PickUpLocation { get; set; }
    public string DroppOfLocation { get; set; }
    public double RentalRate { get; set; }
    public double Surcharge { get; set; }
    public double SalesTax { get; set; }
    public double TotalPrice { get; set; }
}