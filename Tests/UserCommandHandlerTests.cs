using Microsoft.EntityFrameworkCore;
using Backend.Commands;
using Backend.Data;
using Backend.Handlers;


public class UserCommandHandlerTests
{
    private readonly UserCommandHandler _createHandler;
    private readonly UpdateUserCommandHandler _updateHandler;
    private readonly UserDbContext _context;

    public UserCommandHandlerTests()
    {
        var options = new DbContextOptionsBuilder<UserDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _context = new UserDbContext(options);
        _createHandler = new UserCommandHandler(_context);
        _updateHandler = new UpdateUserCommandHandler(_context);

        // Clear the database before each test
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }

    [Fact]
    public async Task Handle_CreateUserCommand_ShouldAddUser()
    {
        // Arrange
        var command = new CreateUserCommand { Name = "Jhonatan", Email = "jhonatan.tec@gmail.com", CPF = "111.222.333.44", Senha = "Jhonatan@1020" };

        // Act
        var result = await _createHandler.Handle(command, CancellationToken.None);

        // Assert
        var user = await _context.Users.FindAsync(result.Id);
        Assert.NotNull(user);
        Assert.Equal("Jhonatan", user.Name);
        Assert.Equal("jhonatan.tec@gmail.com", user.Email);
    }

    [Fact]
    public async Task Handle_UpdateUserCommand_ShouldUpdateUser()
    {
        var createCommand = new CreateUserCommand { Name = "Jhonatan", Email = "jhonatan.tec@gmail.com", CPF = "111.222.333.44", Senha = "Jhonatan@1020" };
        var createdUser = await _createHandler.Handle(createCommand, CancellationToken.None);

        var updateCommand = new UpdateUserCommand { UserId = createdUser.Id, Name = "Brayan", Email = "brayan@gmail.com", CPF = "222.222.333.44", Senha = "Brayan@1020" };
        var updateResult = await _updateHandler.Handle(updateCommand, CancellationToken.None);

        Assert.True(updateResult);
        var updatedUser = await _context.Users.FindAsync(createdUser.Id);
        Assert.NotNull(updatedUser);
        Assert.Equal("Brayan", updatedUser.Name);
        Assert.Equal("brayan@gmail.com", updatedUser.Email);
        Assert.Equal("222.222.333.44", updatedUser.CPF);
        Assert.Equal("Brayan@1020", updatedUser.Senha);
    }
}
