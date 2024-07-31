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
    public class CreateModalModel : CreateModalModelBase
    {
        public CreateModalModel(ITestModuleTablesAppService testModuleTablesAppService)
            : base(testModuleTablesAppService)
        {
        }
    }
}