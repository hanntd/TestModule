using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TestModule.TestModuleTables;
using Volo.Abp.Content;
using TestModule.Shared;

namespace TestModule.TestModuleTables
{
    [RemoteService(Name = "TestModule")]
    [Area("testModule")]
    [ControllerName("TestModuleTable")]
    [Route("api/test-module/test-module-tables")]
    public abstract class TestModuleTableControllerBase : AbpController
    {
        protected ITestModuleTablesAppService _testModuleTablesAppService;

        public TestModuleTableControllerBase(ITestModuleTablesAppService testModuleTablesAppService)
        {
            _testModuleTablesAppService = testModuleTablesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<TestModuleTableDto>> GetListAsync(GetTestModuleTablesInput input)
        {
            return _testModuleTablesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<TestModuleTableDto> GetAsync(Guid id)
        {
            return _testModuleTablesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<TestModuleTableDto> CreateAsync(TestModuleTableCreateDto input)
        {
            return _testModuleTablesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<TestModuleTableDto> UpdateAsync(Guid id, TestModuleTableUpdateDto input)
        {
            return _testModuleTablesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _testModuleTablesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(TestModuleTableExcelDownloadDto input)
        {
            return _testModuleTablesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TestModule.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _testModuleTablesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<Guid> testmoduletableIds)
        {
            return _testModuleTablesAppService.DeleteByIdsAsync(testmoduletableIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetTestModuleTablesInput input)
        {
            return _testModuleTablesAppService.DeleteAllAsync(input);
        }
    }
}