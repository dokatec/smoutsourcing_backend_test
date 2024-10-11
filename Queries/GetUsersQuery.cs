using Backend.Context;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
public class GetUsersQuery { }

public class GetUsersQueryHandler
{
    private readonly UserDbContext _context;

    public GetUsersQueryHandler(UserDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> Handle(GetUsersQuery query)
    {
        return await _context.Users.ToListAsync();
    }
}
