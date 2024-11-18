namespace GottaGoFast.Domain.Publishing.Models.Entities;

public class User : BaseModel
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Cellphone { get; set; }
    public string Gmail { get; set; }
    public string Password { get; set; }
}