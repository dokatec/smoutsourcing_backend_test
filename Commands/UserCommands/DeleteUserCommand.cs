using MediatR;

public class DeleteUserCommand : IRequest<bool>
{
    public int UserId { get; set; }
}