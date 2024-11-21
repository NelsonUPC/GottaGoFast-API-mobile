using System.ComponentModel.DataAnnotations;

namespace GottaGoFast.Domain.Publishing.Models.Commands;

public class UpdateRentCommand
{
    [Required] public string Status { get; set; }
    [Required] public DateOnly StartDate { get; set; }
    [Required] public DateOnly EndDate { get; set; }
    [Required] public string PickUpLocation { get; set; }
    [Required] public string DroppOfLocation { get; set; }
    [Required]public double RentalRate { get; set; }
    [Required] public double Surcharge { get; set; }
    [Required] public double SalesTax { get; set; }
    [Required] public double TotalPrice { get; set; }
}