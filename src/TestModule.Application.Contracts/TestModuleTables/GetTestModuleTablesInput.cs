using Volo.Abp.Application.Dtos;
using System;

namespace TestModule.TestModuleTables
{
    public abstract class GetTestModuleTablesInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }

        public GetTestModuleTablesInputBase()
        {

        }
    }
}