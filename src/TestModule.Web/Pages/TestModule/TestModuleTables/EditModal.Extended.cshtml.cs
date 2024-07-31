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
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(ITestModuleTablesAppService testModuleTablesAppService)
            : base(testModuleTablesAppService)
        {
        }
    }
}