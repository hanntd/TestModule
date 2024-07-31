using TestModule.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestModule.TestModuleTables;

namespace TestModule.Web.Pages.TestModule.TestModuleTables
{
    public abstract class CreateModalModelBase : TestModulePageModel
    {

        [BindProperty]
        public TestModuleTableCreateViewModel TestModuleTable { get; set; }

        protected ITestModuleTablesAppService _testModuleTablesAppService;

        public CreateModalModelBase(ITestModuleTablesAppService testModuleTablesAppService)
        {
            _testModuleTablesAppService = testModuleTablesAppService;

            TestModuleTable = new();
        }

        public virtual async Task OnGetAsync()
        {
            TestModuleTable = new TestModuleTableCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _testModuleTablesAppService.CreateAsync(ObjectMapper.Map<TestModuleTableCreateViewModel, TestModuleTableCreateDto>(TestModuleTable));
            return NoContent();
        }
    }

    public class TestModuleTableCreateViewModel : TestModuleTableCreateDto
    {
    }
}