using MediatR;
using Backend.Models;

namespace Backend.Queries;

public class GetUserByIdQuery : IRequest<User>
{
    public int Id { get; set; }

    public GetUserByIdQuery(int id)
    {
        Id = id;
    }
}


