using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestModule.TestModuleTables;
using TestModule.EntityFrameworkCore;
using Xunit;

namespace TestModule.EntityFrameworkCore.Domains.TestModuleTables
{
    public class TestModuleTableRepositoryTests : TestModuleEntityFrameworkCoreTestBase
    {
        private readonly ITestModuleTableRepository _testModuleTableRepository;

        public TestModuleTableRepositoryTests()
        {
            _testModuleTableRepository = GetRequiredService<ITestModuleTableRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _testModuleTableRepository.GetListAsync(
                    code: "7b5acb4b1ea541fb8cee6e90bc6359b8d6",
                    name: "4b4718c094844a30975720b7",
                    notes: "01cc06cb888d4f17a89f3ff5a59dc6e698ea28b6b1dc4b6981d3992b8c2f92e6b397f139129d4ed7"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("be42e074-297d-4f6a-9ac8-9722a3786dc2"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _testModuleTableRepository.GetCountAsync(
                    code: "1b85f3fdf2534777ae35e2249cf4beefffabff8ad9814e039",
                    name: "8a3b626426014d738e422e6af01f4",
                    notes: "edefeac0e68e4a4d855ea5c580"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}