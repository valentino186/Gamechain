using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Gamechain.Infrastructure.EntityFrameworkCore.Context
{
    public class GamechainDbContextFactory : IDesignTimeDbContextFactory<GamechainDbContext>
    {
        public GamechainDbContext CreateDbContext(string[] args)
        {
            var configuration = CreateConfiguration();

            var optionsBuilder = new DbContextOptionsBuilder<GamechainDbContext>();
            var connectionString = configuration.GetConnectionString(nameof(GamechainDbContext));

            optionsBuilder.UseSqlServer(connectionString);

            return new GamechainDbContext(optionsBuilder.Options);
        }

        private IConfigurationRoot CreateConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
