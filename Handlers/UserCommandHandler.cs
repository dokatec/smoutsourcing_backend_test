using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Backend.Commands;
using Backend.Data;
using Backend.Models;

namespace Backend.Handlers;

public class UserCommandHandler : IRequestHandler<CreateUserCommand, User>
{
    private readonly UserDbContext _context;

    public UserCommandHandler(UserDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(CreateUserCommand request, CancellationToken CancellationToken)
    {
        var user = new User { Name = request.Name, CPF = request.CPF, Email = request.Email, Senha = request.Senha };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
