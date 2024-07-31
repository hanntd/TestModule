using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using TestModule.TestModuleTables;

namespace TestModule.TestModuleTables
{
    public class TestModuleTablesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITestModuleTableRepository _testModuleTableRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TestModuleTablesDataSeedContributor(ITestModuleTableRepository testModuleTableRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _testModuleTableRepository = testModuleTableRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _testModuleTableRepository.InsertAsync(new TestModuleTable
            (
                id: Guid.Parse("be42e074-297d-4f6a-9ac8-9722a3786dc2"),
                code: "7b5acb4b1ea541fb8cee6e90bc6359b8d6",
                name: "4b4718c094844a30975720b7",
                notes: "01cc06cb888d4f17a89f3ff5a59dc6e698ea28b6b1dc4b6981d3992b8c2f92e6b397f139129d4ed7"
            ));

            await _testModuleTableRepository.InsertAsync(new TestModuleTable
            (
                id: Guid.Parse("fc24ab04-7307-44e9-a99d-be7c10dd9742"),
                code: "1b85f3fdf2534777ae35e2249cf4beefffabff8ad9814e039",
                name: "8a3b626426014d738e422e6af01f4",
                notes: "edefeac0e68e4a4d855ea5c580"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}