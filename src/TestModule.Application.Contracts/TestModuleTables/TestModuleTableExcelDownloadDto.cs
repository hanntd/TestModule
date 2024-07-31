using Volo.Abp.Application.Dtos;
using System;

namespace TestModule.TestModuleTables
{
    public abstract class TestModuleTableExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }

        public TestModuleTableExcelDownloadDtoBase()
        {

        }
    }
}