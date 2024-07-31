using TestModule.TestModuleTables;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TestModule.EntityFrameworkCore;

[ConnectionStringName(TestModuleDbProperties.ConnectionStringName)]
public interface ITestModuleDbContext : IEfCoreDbContext
{
    DbSet<TestModuleTable> TestModuleTables { get; set; }
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}