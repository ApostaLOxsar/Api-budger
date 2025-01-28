using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api_budger
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // for job
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            //for update
            connectionString = configuration.GetConnectionString("UpdateConnection");

            // Настраиваем DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
