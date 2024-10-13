using MediatR;
using Backend.Models;

namespace Backend.Commands;

public class UpdateUserCommand : IRequest<bool>
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }
}