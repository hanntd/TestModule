using Volo.Abp.AutoMapper;
using TestModule.TestModuleTables;
using AutoMapper;

namespace TestModule.Blazor;

public class TestModuleBlazorAutoMapperProfile : Profile
{
    public TestModuleBlazorAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<TestModuleTableDto, TestModuleTableUpdateDto>();
    }
}