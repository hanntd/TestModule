using TestModule.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using TestModule.TestModuleTables;

namespace TestModule.Web.Pages.TestModule.TestModuleTables
{
    public abstract class EditModalModelBase : TestModulePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public TestModuleTableUpdateViewModel TestModuleTable { get; set; }

        protected ITestModuleTablesAppService _testModuleTablesAppService;

        public EditModalModelBase(ITestModuleTablesAppService testModuleTablesAppService)
        {
            _testModuleTablesAppService = testModuleTablesAppService;

            TestModuleTable = new();
        }

        public virtual async Task OnGetAsync()
        {
            var testModuleTable = await _testModuleTablesAppService.GetAsync(Id);
            TestModuleTable = ObjectMapper.Map<TestModuleTableDto, TestModuleTableUpdateViewModel>(testModuleTable);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _testModuleTablesAppService.UpdateAsync(Id, ObjectMapper.Map<TestModuleTableUpdateViewModel, TestModuleTableUpdateDto>(TestModuleTable));
            return NoContent();
        }
    }

    public class TestModuleTableUpdateViewModel : TestModuleTableUpdateDto
    {
    }
}