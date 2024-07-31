using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TestModule.TestModuleTables
{
    public partial interface ITestModuleTableRepository : IRepository<TestModuleTable, Guid>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? notes = null,
            CancellationToken cancellationToken = default);
        Task<List<TestModuleTable>> GetListAsync(
                    string? filterText = null,
                    string? code = null,
                    string? name = null,
                    string? notes = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? notes = null,
            CancellationToken cancellationToken = default);
    }
}