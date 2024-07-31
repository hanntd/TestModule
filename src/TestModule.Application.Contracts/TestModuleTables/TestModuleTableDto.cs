using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace TestModule.TestModuleTables
{
    public abstract class TestModuleTableDtoBase : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}