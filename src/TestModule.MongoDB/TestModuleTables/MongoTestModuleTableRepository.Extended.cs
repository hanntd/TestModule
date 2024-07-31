using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using TestModule.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace TestModule.TestModuleTables
{
    public class MongoTestModuleTableRepository : MongoTestModuleTableRepositoryBase, ITestModuleTableRepository
    {
        public MongoTestModuleTableRepository(IMongoDbContextProvider<TestModuleMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        //Write your custom code...
    }
}