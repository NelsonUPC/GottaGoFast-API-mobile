using GottaGoFast.Domain.Publishing.Models.Commands;
using GottaGoFast.Domain.Publishing.Models.Entities;
using GottaGoFast.Domain.Security.Models.Commands;

namespace GottaGoFast.Domain.Publishing.Services;

public interface IUserCommandService
{
    Task<User> Handle(SignUpCommand command);
    Task<string> Handle(SignInCommand command);
    Task<int> Handle(CreateUserCommand command);
    Task<Boolean> Handle(int id, UpdateUserCommand command);
    Task<Boolean> Handle(DeleteUserCommand command);
}