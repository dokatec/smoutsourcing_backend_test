using Backend.Context;
using Backend.Models;
public class GetUserQuery
{
    public int Id { get; set; }
}

public class GetUserQueryHandler
{
    private readonly UserDbContext _context;

    public GetUserQueryHandler(UserDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(GetUserQuery query)
    {
        return await _context.Users.FindAsync(query.Id);
    }
}
