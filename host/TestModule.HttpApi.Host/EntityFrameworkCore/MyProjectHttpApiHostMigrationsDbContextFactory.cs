using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TestModule.EntityFrameworkCore;

public class TestModuleHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<TestModuleHttpApiHostMigrationsDbContext>
{
    public TestModuleHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<TestModuleHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("TestModule"));

        return new TestModuleHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
