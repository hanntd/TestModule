using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace TestModule.TestModuleTables
{
    public abstract class TestModuleTableManagerBase : DomainService
    {
        protected ITestModuleTableRepository _testModuleTableRepository;

        public TestModuleTableManagerBase(ITestModuleTableRepository testModuleTableRepository)
        {
            _testModuleTableRepository = testModuleTableRepository;
        }

        public virtual async Task<TestModuleTable> CreateAsync(
        string? code = null, string? name = null, string? notes = null)
        {

            var testModuleTable = new TestModuleTable(
             GuidGenerator.Create(),
             code, name, notes
             );

            return await _testModuleTableRepository.InsertAsync(testModuleTable);
        }

        public virtual async Task<TestModuleTable> UpdateAsync(
            Guid id,
            string? code = null, string? name = null, string? notes = null, [CanBeNull] string? concurrencyStamp = null
        )
        {

            var testModuleTable = await _testModuleTableRepository.GetAsync(id);

            testModuleTable.Code = code;
            testModuleTable.Name = name;
            testModuleTable.Notes = notes;

            testModuleTable.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _testModuleTableRepository.UpdateAsync(testModuleTable);
        }

    }
}