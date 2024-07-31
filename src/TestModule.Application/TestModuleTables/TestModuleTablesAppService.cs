using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using TestModule.Permissions;
using TestModule.TestModuleTables;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using TestModule.Shared;

namespace TestModule.TestModuleTables
{

    [Authorize(TestModulePermissions.TestModuleTables.Default)]
    public abstract class TestModuleTablesAppServiceBase : TestModuleAppService
    {
        protected IDistributedCache<TestModuleTableDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ITestModuleTableRepository _testModuleTableRepository;
        protected TestModuleTableManager _testModuleTableManager;

        public TestModuleTablesAppServiceBase(ITestModuleTableRepository testModuleTableRepository, TestModuleTableManager testModuleTableManager, IDistributedCache<TestModuleTableDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _testModuleTableRepository = testModuleTableRepository;
            _testModuleTableManager = testModuleTableManager;

        }

        public virtual async Task<PagedResultDto<TestModuleTableDto>> GetListAsync(GetTestModuleTablesInput input)
        {
            var totalCount = await _testModuleTableRepository.GetCountAsync(input.FilterText, input.Code, input.Name, input.Notes);
            var items = await _testModuleTableRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Notes, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TestModuleTableDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TestModuleTable>, List<TestModuleTableDto>>(items)
            };
        }

        public virtual async Task<TestModuleTableDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<TestModuleTable, TestModuleTableDto>(await _testModuleTableRepository.GetAsync(id));
        }

        [Authorize(TestModulePermissions.TestModuleTables.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _testModuleTableRepository.DeleteAsync(id);
        }

        [Authorize(TestModulePermissions.TestModuleTables.Create)]
        public virtual async Task<TestModuleTableDto> CreateAsync(TestModuleTableCreateDto input)
        {

            var testModuleTable = await _testModuleTableManager.CreateAsync(
            input.Code, input.Name, input.Notes
            );

            return ObjectMapper.Map<TestModuleTable, TestModuleTableDto>(testModuleTable);
        }

        [Authorize(TestModulePermissions.TestModuleTables.Edit)]
        public virtual async Task<TestModuleTableDto> UpdateAsync(Guid id, TestModuleTableUpdateDto input)
        {

            var testModuleTable = await _testModuleTableManager.UpdateAsync(
            id,
            input.Code, input.Name, input.Notes, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<TestModuleTable, TestModuleTableDto>(testModuleTable);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TestModuleTableExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _testModuleTableRepository.GetListAsync(input.FilterText, input.Code, input.Name, input.Notes);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TestModuleTable>, List<TestModuleTableExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "TestModuleTables.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(TestModulePermissions.TestModuleTables.Delete)]
        public virtual async Task DeleteByIdsAsync(List<Guid> testmoduletableIds)
        {
            await _testModuleTableRepository.DeleteManyAsync(testmoduletableIds);
        }

        [Authorize(TestModulePermissions.TestModuleTables.Delete)]
        public virtual async Task DeleteAllAsync(GetTestModuleTablesInput input)
        {
            await _testModuleTableRepository.DeleteAllAsync(input.FilterText, input.Code, input.Name, input.Notes);
        }
        public virtual async Task<TestModule.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new TestModuleTableDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new TestModule.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}