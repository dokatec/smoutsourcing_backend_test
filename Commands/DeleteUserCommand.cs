using Backend.Context;
using Backend.Models;
public class DeleteUserCommand
{
    public int Id { get; set; }
}

public class DeleteUserCommandHandler
{
    private readonly UserDbContext _context;

    public DeleteUserCommandHandler(UserDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteUserCommand command)
    {
        var user = await _context.Users.FindAsync(command.Id);
        if (user == null) throw new Exception("User not found");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}
