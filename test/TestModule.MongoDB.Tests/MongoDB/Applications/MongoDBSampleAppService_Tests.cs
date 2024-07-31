using TestModule.MongoDB;
using TestModule.Samples;
using Xunit;

namespace TestModule.MongoDb.Applications;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleAppService_Tests : SampleAppService_Tests<TestModuleMongoDbTestModule>
{

}
