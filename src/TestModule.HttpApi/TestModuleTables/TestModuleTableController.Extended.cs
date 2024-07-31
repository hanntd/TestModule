using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TestModule.TestModuleTables;

namespace TestModule.TestModuleTables
{
    [RemoteService(Name = "TestModule")]
    [Area("testModule")]
    [ControllerName("TestModuleTable")]
    [Route("api/test-module/test-module-tables")]
    public class TestModuleTableController : TestModuleTableControllerBase, ITestModuleTablesAppService
    {
        public TestModuleTableController(ITestModuleTablesAppService testModuleTablesAppService) : base(testModuleTablesAppService)
        {
        }
    }
}