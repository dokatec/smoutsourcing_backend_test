using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Backend.Data
{
    // Fábrica para o UserDbContext
    public class UserDbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<UserDbContext>();
            var connectionString = configuration.GetConnectionString("UserDbConnection");
            builder.UseNpgsql(connectionString);

            return new UserDbContext(builder.Options);
        }
    }

    // Fábrica para o AuthDbContext
    public class AuthDbContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
    {
        public AuthDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AuthDbContext>();
            var connectionString = configuration.GetConnectionString("AuthDbConnection");
            builder.UseNpgsql(connectionString);

            return new AuthDbContext(builder.Options);
        }
    }
}
