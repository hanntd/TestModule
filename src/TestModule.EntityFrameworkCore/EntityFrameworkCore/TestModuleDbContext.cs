using TestModule.TestModuleTables;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TestModule.EntityFrameworkCore;

[ConnectionStringName(TestModuleDbProperties.ConnectionStringName)]
public class TestModuleDbContext : AbpDbContext<TestModuleDbContext>, ITestModuleDbContext
{
    public DbSet<TestModuleTable> TestModuleTables { get; set; } = null!;
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public TestModuleDbContext(DbContextOptions<TestModuleDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureTestModule();
    }
}