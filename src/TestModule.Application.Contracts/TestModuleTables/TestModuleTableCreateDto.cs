using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TestModule.TestModuleTables
{
    public abstract class TestModuleTableCreateDtoBase
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }
    }
}