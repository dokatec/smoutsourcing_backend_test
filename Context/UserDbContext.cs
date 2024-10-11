using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Context;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
    public DbSet<User> Users => Set<User>();

}