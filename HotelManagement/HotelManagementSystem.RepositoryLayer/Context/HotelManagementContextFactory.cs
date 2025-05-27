using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class HotelManagementContextFactory : IDesignTimeDbContextFactory<HotelManagementContext>
{
    public HotelManagementContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            
        var optionsBuilder = new DbContextOptionsBuilder<HotelManagementContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);

        return new HotelManagementContext(optionsBuilder.Options);
    }
}
