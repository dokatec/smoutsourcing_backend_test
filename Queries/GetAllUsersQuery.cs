using MediatR;
using Backend.Models;

namespace Backend.Queries
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}


