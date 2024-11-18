using GottaGoFast.Domain.Publishing.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GottaGoFast.Presentation.Publishing.Filters;

public class AuthorizeCustomAttribute : Attribute
{
    private readonly string[] _roles;

    public AuthorizeCustomAttribute(params string[] roles)
    {
        _roles = roles;
    }
    
    
}