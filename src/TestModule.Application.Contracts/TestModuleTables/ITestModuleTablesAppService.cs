using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TestModule.Shared;

namespace TestModule.TestModuleTables
{
    public partial interface ITestModuleTablesAppService : IApplicationService
    {

        Task<PagedResultDto<TestModuleTableDto>> GetListAsync(GetTestModuleTablesInput input);

        Task<TestModuleTableDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<TestModuleTableDto> CreateAsync(TestModuleTableCreateDto input);

        Task<TestModuleTableDto> UpdateAsync(Guid id, TestModuleTableUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TestModuleTableExcelDownloadDto input);
        Task DeleteByIdsAsync(List<Guid> testmoduletableIds);

        Task DeleteAllAsync(GetTestModuleTablesInput input);
        Task<TestModule.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}