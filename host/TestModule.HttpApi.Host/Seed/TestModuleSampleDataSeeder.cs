﻿using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace TestModule.Seed;

/* You can use this file to seed some sample data
 * to test your module easier.
 *
 * This class is shared among these projects:
 * - TestModule.AuthServer
 * - TestModule.Web.Unified (used as linked file)
 */
public class TestModuleSampleDataSeeder : ITransientDependency
{
    public async Task SeedAsync(DataSeedContext context)
    {

    }
}
