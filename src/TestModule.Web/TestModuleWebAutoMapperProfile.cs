using TestModule.Web.Pages.TestModule.TestModuleTables;
using Volo.Abp.AutoMapper;
using TestModule.TestModuleTables;
using AutoMapper;

namespace TestModule.Web;

public class TestModuleWebAutoMapperProfile : Profile
{
    public TestModuleWebAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<TestModuleTableDto, TestModuleTableUpdateViewModel>();
        CreateMap<TestModuleTableUpdateViewModel, TestModuleTableUpdateDto>();
        CreateMap<TestModuleTableCreateViewModel, TestModuleTableCreateDto>();
    }
}