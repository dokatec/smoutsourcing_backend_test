using Backend.Context;
using Backend.Models;

public class UpdateUserCommand
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}

public class UpdateUserCommandHandler
{
    private readonly UserDbContext _context;

    public UpdateUserCommandHandler(UserDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateUserCommand command)
    {
        var user = await _context.Users.FindAsync(command.Id);
        if (user == null) throw new Exception("User not found");

        user.Name = command.Name;
        user.Email = command.Email;
        await _context.SaveChangesAsync();
    }
}
