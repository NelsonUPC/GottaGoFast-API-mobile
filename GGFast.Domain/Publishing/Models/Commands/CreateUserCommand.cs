using System.ComponentModel.DataAnnotations;

namespace GottaGoFast.Domain.Publishing.Models.Commands;

public class CreateUserCommand
{
    [Required] public string Name { get; set; }
    
    [Required] public string LastName { get; set; }
    
    [Required] public int Cellphone { get; set; }
    
    [Required] public string Gmail { get; set; }
    
    [Required] public string Password { get; set; }
    
   
}