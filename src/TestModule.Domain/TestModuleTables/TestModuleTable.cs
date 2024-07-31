using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace TestModule.TestModuleTables
{
    public abstract class TestModuleTableBase : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string? Code { get; set; }

        [CanBeNull]
        public virtual string? Name { get; set; }

        [CanBeNull]
        public virtual string? Notes { get; set; }

        protected TestModuleTableBase()
        {

        }

        public TestModuleTableBase(Guid id, string? code = null, string? name = null, string? notes = null)
        {

            Id = id;
            Code = code;
            Name = name;
            Notes = notes;
        }

    }
}