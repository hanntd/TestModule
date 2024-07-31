using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace TestModule.TestModuleTables
{
    public abstract class TestModuleTablesAppServiceTests<TStartupModule> : TestModuleApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITestModuleTablesAppService _testModuleTablesAppService;
        private readonly IRepository<TestModuleTable, Guid> _testModuleTableRepository;

        public TestModuleTablesAppServiceTests()
        {
            _testModuleTablesAppService = GetRequiredService<ITestModuleTablesAppService>();
            _testModuleTableRepository = GetRequiredService<IRepository<TestModuleTable, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _testModuleTablesAppService.GetListAsync(new GetTestModuleTablesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("be42e074-297d-4f6a-9ac8-9722a3786dc2")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("fc24ab04-7307-44e9-a99d-be7c10dd9742")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _testModuleTablesAppService.GetAsync(Guid.Parse("be42e074-297d-4f6a-9ac8-9722a3786dc2"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("be42e074-297d-4f6a-9ac8-9722a3786dc2"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TestModuleTableCreateDto
            {
                Code = "0d3b50f3bd7d4200a00ca661d62feac885a54ec4b0b14e588c02b17c758df2ddc23a",
                Name = "07503aefe76e48098badf2a8a361e87361a10317",
                Notes = "094286a1e66e45b1be762cc67c0c36c3b3880fd61f344152b474da9"
            };

            // Act
            var serviceResult = await _testModuleTablesAppService.CreateAsync(input);

            // Assert
            var result = await _testModuleTableRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("0d3b50f3bd7d4200a00ca661d62feac885a54ec4b0b14e588c02b17c758df2ddc23a");
            result.Name.ShouldBe("07503aefe76e48098badf2a8a361e87361a10317");
            result.Notes.ShouldBe("094286a1e66e45b1be762cc67c0c36c3b3880fd61f344152b474da9");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TestModuleTableUpdateDto()
            {
                Code = "46fe94d755b347f895bb70a51485883fc4044f1f62d44",
                Name = "dd8387d7838948b5a36bce0c4c39c3c82b6fe8ee0ca840e5907e8ddbda6e00e72f492e83d69044df91265424967070f26",
                Notes = "94a0508e03ee455a9279fcd357f82fb569274a8c9b884146adf07c950b889d0bf229f1561e7f481cb2"
            };

            // Act
            var serviceResult = await _testModuleTablesAppService.UpdateAsync(Guid.Parse("be42e074-297d-4f6a-9ac8-9722a3786dc2"), input);

            // Assert
            var result = await _testModuleTableRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("46fe94d755b347f895bb70a51485883fc4044f1f62d44");
            result.Name.ShouldBe("dd8387d7838948b5a36bce0c4c39c3c82b6fe8ee0ca840e5907e8ddbda6e00e72f492e83d69044df91265424967070f26");
            result.Notes.ShouldBe("94a0508e03ee455a9279fcd357f82fb569274a8c9b884146adf07c950b889d0bf229f1561e7f481cb2");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _testModuleTablesAppService.DeleteAsync(Guid.Parse("be42e074-297d-4f6a-9ac8-9722a3786dc2"));

            // Assert
            var result = await _testModuleTableRepository.FindAsync(c => c.Id == Guid.Parse("be42e074-297d-4f6a-9ac8-9722a3786dc2"));

            result.ShouldBeNull();
        }
    }
}