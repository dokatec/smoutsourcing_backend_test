using Backend.Context;
using Backend.Controllers;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class UsersControllerTests
{
    private readonly UserController _controller;
    private readonly UserDbContext _context;

    public UsersControllerTests()
    {
        var options = new DbContextOptionsBuilder<UserDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _context = new UserDbContext(options);
        _controller = new UserController(_context);
    }

    [Fact]
    public async Task GetUsers_ReturnsAllUsers()
    {
        // Arrange
        _context.Users.Add(new User { Name = "Test User", Email = "test@example.com" });
        _context.SaveChanges();

        // Act
        var result = await _controller.GetUsers(new GetUsersQueryHandler(_context));

        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<User>>>(result);
        var users = Assert.IsType<List<User>>(actionResult.Value);
        Assert.Single(users);
    }

}
