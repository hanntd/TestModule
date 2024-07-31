using TestModule.Samples;
using Xunit;

namespace TestModule.MongoDB.Domains;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleDomain_Tests : SampleManager_Tests<TestModuleMongoDbTestModule>
{

}
