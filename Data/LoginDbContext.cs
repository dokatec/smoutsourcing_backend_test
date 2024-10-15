using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data;

public class LoginDbContext : DbContext
{
    public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options) { }
    public DbSet<LoginUser> UserLogin { get; set; }

    protected LoginDbContext() { }

}