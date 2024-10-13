using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Queries;
using Backend.Models;

namespace Backend.Handlers
{
    public class UserQueryHandler : IRequestHandler<GetUserByIdQuery, User>,
                                    IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly UserDbContext _context;

        public UserQueryHandler(UserDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.FindAsync(request.Id);
        }
        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.ToListAsync(cancellationToken);
        }
    }
}
