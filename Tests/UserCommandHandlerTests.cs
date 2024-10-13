using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Commands;
using Backend.Data;
using Backend.Handlers;
using Backend.Models;
using Xunit;

public class UserCommandHandlerTests
{
    private readonly UserCommandHandler _handler;
    private readonly UserDbContext _context;

    public UserCommandHandlerTests()
    {
        var options = new DbContextOptionsBuilder<UserDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _context = new UserDbContext(options);
        _handler = new UserCommandHandler(_context);
    }

    [Fact]
    public async Task Handle_CreateUserCommand_ShouldAddUser()
    {
        var command = new CreateUserCommand { Name = "John", Email = "john@example.com" };
        var result = await _handler.Handle(command, CancellationToken.None);

        var user = await _context.Users.FindAsync(result.Id);
        Assert.NotNull(user);
        Assert.Equal("John", user.Name);
    }
}
