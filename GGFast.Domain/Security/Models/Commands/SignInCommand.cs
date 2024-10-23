namespace GottaGoFast.Domain.Security.Models.Commands;

public record SignInCommand()
{
    public string Gmail { get; set; } 
    public string Password { get; set; }
}