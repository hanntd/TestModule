using System;
using TestModule.Shared;
using Volo.Abp.AutoMapper;
using TestModule.TestModuleTables;
using AutoMapper;

namespace TestModule;

public class TestModuleApplicationAutoMapperProfile : Profile
{
    public TestModuleApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<TestModuleTable, TestModuleTableDto>();
        CreateMap<TestModuleTable, TestModuleTableExcelDto>();
    }
}