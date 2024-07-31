using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using TestModule.EntityFrameworkCore;

namespace TestModule.TestModuleTables
{
    public class EfCoreTestModuleTableRepository : EfCoreTestModuleTableRepositoryBase, ITestModuleTableRepository
    {
        public EfCoreTestModuleTableRepository(IDbContextProvider<TestModuleDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}