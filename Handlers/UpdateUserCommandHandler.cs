using MediatR;
using Backend.Commands;
using Backend.Data;


namespace Backend.Handlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly UserDbContext _context;

    public UpdateUserCommandHandler(UserDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.UserId);

        if (user == null) return false;

        user.Name = request.Name;
        user.Email = request.Email;

        await _context.SaveChangesAsync(cancellationToken);
        return true;

    }

}