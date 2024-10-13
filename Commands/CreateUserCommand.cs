using MediatR;
using Backend.Models;

namespace Backend.Commands;
public class CreateUserCommand : IRequest<User>
{
    public string? Name { get; set; }
    public string? Email { get; set; }
}

