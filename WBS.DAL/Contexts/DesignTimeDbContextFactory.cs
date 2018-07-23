using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using WBS.DAL;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WBSContext>
{
    public WBSContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var builder = new DbContextOptionsBuilder<WBSContext>();
        builder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        return new WBSContext(builder.Options);
    }
}