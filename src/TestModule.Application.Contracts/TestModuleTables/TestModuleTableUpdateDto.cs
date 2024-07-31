using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace TestModule.TestModuleTables
{
    public abstract class TestModuleTableUpdateDtoBase : IHasConcurrencyStamp
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}