using Volo.Abp.EntityFrameworkCore.Modeling;
using TestModule.TestModuleTables;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace TestModule.EntityFrameworkCore;

public static class TestModuleDbContextModelCreatingExtensions
{
    public static void ConfigureTestModule(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(TestModuleDbProperties.DbTablePrefix + "Questions", TestModuleDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
        if (builder.IsHostDatabase())
        {
            builder.Entity<TestModuleTable>(b =>
            {
                b.ToTable(TestModuleDbProperties.DbTablePrefix + "TestModuleTables", TestModuleDbProperties.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Code).HasColumnName(nameof(TestModuleTable.Code));
                b.Property(x => x.Name).HasColumnName(nameof(TestModuleTable.Name));
                b.Property(x => x.Notes).HasColumnName(nameof(TestModuleTable.Notes));
            });

        }
    }
}