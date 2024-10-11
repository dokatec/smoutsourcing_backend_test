using Backend.Context;
using Backend.Models;
public class CreateUserCommand
{
    public string? Name { get; set; }
    public string? Email { get; set; }
}

public class CreateUserCommandHandler
{
    private readonly UserDbContext _context;

    public CreateUserCommandHandler(UserDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(CreateUserCommand command)
    {
        var user = new User { Name = command.Name, Email = command.Email };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
