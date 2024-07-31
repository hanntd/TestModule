using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Web;
using Blazorise;
using Blazorise.DataGrid;
using Volo.Abp.BlazoriseUI.Components;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using TestModule.TestModuleTables;
using TestModule.Permissions;
using TestModule.Shared;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Volo.Abp;
using Volo.Abp.Content;



namespace TestModule.Blazor.Pages.TestModule
{
    public partial class TestModuleTables
    {
        
        
            
        
            
        protected List<Volo.Abp.BlazoriseUI.BreadcrumbItem> BreadcrumbItems = new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>();
        protected PageToolbar Toolbar {get;} = new PageToolbar();
        protected bool ShowAdvancedFilters { get; set; }
        private IReadOnlyList<TestModuleTableDto> TestModuleTableList { get; set; }
        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentPage { get; set; } = 1;
        private string CurrentSorting { get; set; } = string.Empty;
        private int TotalCount { get; set; }
        private bool CanCreateTestModuleTable { get; set; }
        private bool CanEditTestModuleTable { get; set; }
        private bool CanDeleteTestModuleTable { get; set; }
        private TestModuleTableCreateDto NewTestModuleTable { get; set; }
        private Validations NewTestModuleTableValidations { get; set; } = new();
        private TestModuleTableUpdateDto EditingTestModuleTable { get; set; }
        private Validations EditingTestModuleTableValidations { get; set; } = new();
        private Guid EditingTestModuleTableId { get; set; }
        private Modal CreateTestModuleTableModal { get; set; } = new();
        private Modal EditTestModuleTableModal { get; set; } = new();
        private GetTestModuleTablesInput Filter { get; set; }
        private DataGridEntityActionsColumn<TestModuleTableDto> EntityActionsColumn { get; set; } = new();
        protected string SelectedCreateTab = "testModuleTable-create-tab";
        protected string SelectedEditTab = "testModuleTable-edit-tab";
        private TestModuleTableDto? SelectedTestModuleTable;
        
        
        
        
        
        private List<TestModuleTableDto> SelectedTestModuleTables { get; set; } = new();
        private bool AllTestModuleTablesSelected { get; set; }
        
        public TestModuleTables()
        {
            NewTestModuleTable = new TestModuleTableCreateDto();
            EditingTestModuleTable = new TestModuleTableUpdateDto();
            Filter = new GetTestModuleTablesInput
            {
                MaxResultCount = PageSize,
                SkipCount = (CurrentPage - 1) * PageSize,
                Sorting = CurrentSorting
            };
            TestModuleTableList = new List<TestModuleTableDto>();
            
            
        }

        protected override async Task OnInitializedAsync()
        {
            await SetPermissionsAsync();
            
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                
                await SetBreadcrumbItemsAsync();
                await SetToolbarItemsAsync();
                await InvokeAsync(StateHasChanged);
            }
        }  

        protected virtual ValueTask SetBreadcrumbItemsAsync()
        {
            BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["TestModuleTables"]));
            return ValueTask.CompletedTask;
        }

        protected virtual ValueTask SetToolbarItemsAsync()
        {
            Toolbar.AddButton(L["ExportToExcel"], async () =>{ await DownloadAsExcelAsync(); }, IconName.Download);
            
            Toolbar.AddButton(L["NewTestModuleTable"], async () =>
            {
                await OpenCreateTestModuleTableModalAsync();
            }, IconName.Add, requiredPolicyName: TestModulePermissions.TestModuleTables.Create);

            return ValueTask.CompletedTask;
        }

        private async Task SetPermissionsAsync()
        {
            CanCreateTestModuleTable = await AuthorizationService
                .IsGrantedAsync(TestModulePermissions.TestModuleTables.Create);
            CanEditTestModuleTable = await AuthorizationService
                            .IsGrantedAsync(TestModulePermissions.TestModuleTables.Edit);
            CanDeleteTestModuleTable = await AuthorizationService
                            .IsGrantedAsync(TestModulePermissions.TestModuleTables.Delete);
                            
                            
        }

        private async Task GetTestModuleTablesAsync()
        {
            Filter.MaxResultCount = PageSize;
            Filter.SkipCount = (CurrentPage - 1) * PageSize;
            Filter.Sorting = CurrentSorting;

            var result = await TestModuleTablesAppService.GetListAsync(Filter);
            TestModuleTableList = result.Items;
            TotalCount = (int)result.TotalCount;
            
            await ClearSelection();
        }

        protected virtual async Task SearchAsync()
        {
            CurrentPage = 1;
            await GetTestModuleTablesAsync();
            await InvokeAsync(StateHasChanged);
        }

        private async Task DownloadAsExcelAsync()
        {
            var token = (await TestModuleTablesAppService.GetDownloadTokenAsync()).Token;
            var remoteService = await RemoteServiceConfigurationProvider.GetConfigurationOrDefaultOrNullAsync("TestModule") ?? await RemoteServiceConfigurationProvider.GetConfigurationOrDefaultOrNullAsync("Default");
            var culture = CultureInfo.CurrentUICulture.Name ?? CultureInfo.CurrentCulture.Name;
            if(!culture.IsNullOrEmpty())
            {
                culture = "&culture=" + culture;
            }
            await RemoteServiceConfigurationProvider.GetConfigurationOrDefaultOrNullAsync("Default");
            NavigationManager.NavigateTo($"{remoteService?.BaseUrl.EnsureEndsWith('/') ?? string.Empty}api/test-module/test-module-tables/as-excel-file?DownloadToken={token}&FilterText={HttpUtility.UrlEncode(Filter.FilterText)}{culture}&Code={HttpUtility.UrlEncode(Filter.Code)}&Name={HttpUtility.UrlEncode(Filter.Name)}&Notes={HttpUtility.UrlEncode(Filter.Notes)}", forceLoad: true);
        }

        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<TestModuleTableDto> e)
        {
            CurrentSorting = e.Columns
                .Where(c => c.SortDirection != SortDirection.Default)
                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentPage = e.Page;
            await GetTestModuleTablesAsync();
            await InvokeAsync(StateHasChanged);
        }

        private async Task OpenCreateTestModuleTableModalAsync()
        {
            NewTestModuleTable = new TestModuleTableCreateDto{
                
                
            };

            SelectedCreateTab = "testModuleTable-create-tab";
            
            
            await NewTestModuleTableValidations.ClearAll();
            await CreateTestModuleTableModal.Show();
        }

        private async Task CloseCreateTestModuleTableModalAsync()
        {
            NewTestModuleTable = new TestModuleTableCreateDto{
                
                
            };
            await CreateTestModuleTableModal.Hide();
        }

        private async Task OpenEditTestModuleTableModalAsync(TestModuleTableDto input)
        {
            SelectedEditTab = "testModuleTable-edit-tab";
            
            
            var testModuleTable = await TestModuleTablesAppService.GetAsync(input.Id);
            
            EditingTestModuleTableId = testModuleTable.Id;
            EditingTestModuleTable = ObjectMapper.Map<TestModuleTableDto, TestModuleTableUpdateDto>(testModuleTable);
            
            await EditingTestModuleTableValidations.ClearAll();
            await EditTestModuleTableModal.Show();
        }

        private async Task DeleteTestModuleTableAsync(TestModuleTableDto input)
        {
            await TestModuleTablesAppService.DeleteAsync(input.Id);
            await GetTestModuleTablesAsync();
        }

        private async Task CreateTestModuleTableAsync()
        {
            try
            {
                if (await NewTestModuleTableValidations.ValidateAll() == false)
                {
                    return;
                }

                await TestModuleTablesAppService.CreateAsync(NewTestModuleTable);
                await GetTestModuleTablesAsync();
                await CloseCreateTestModuleTableModalAsync();
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        private async Task CloseEditTestModuleTableModalAsync()
        {
            await EditTestModuleTableModal.Hide();
        }

        private async Task UpdateTestModuleTableAsync()
        {
            try
            {
                if (await EditingTestModuleTableValidations.ValidateAll() == false)
                {
                    return;
                }

                await TestModuleTablesAppService.UpdateAsync(EditingTestModuleTableId, EditingTestModuleTable);
                await GetTestModuleTablesAsync();
                await EditTestModuleTableModal.Hide();                
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        private void OnSelectedCreateTabChanged(string name)
        {
            SelectedCreateTab = name;
        }

        private void OnSelectedEditTabChanged(string name)
        {
            SelectedEditTab = name;
        }









        protected virtual async Task OnCodeChangedAsync(string? code)
        {
            Filter.Code = code;
            await SearchAsync();
        }
        protected virtual async Task OnNameChangedAsync(string? name)
        {
            Filter.Name = name;
            await SearchAsync();
        }
        protected virtual async Task OnNotesChangedAsync(string? notes)
        {
            Filter.Notes = notes;
            await SearchAsync();
        }
        





        private Task SelectAllItems()
        {
            AllTestModuleTablesSelected = true;
            
            return Task.CompletedTask;
        }

        private Task ClearSelection()
        {
            AllTestModuleTablesSelected = false;
            SelectedTestModuleTables.Clear();
            
            return Task.CompletedTask;
        }

        private Task SelectedTestModuleTableRowsChanged()
        {
            if (SelectedTestModuleTables.Count != PageSize)
            {
                AllTestModuleTablesSelected = false;
            }
            
            return Task.CompletedTask;
        }

        private async Task DeleteSelectedTestModuleTablesAsync()
        {
            var message = AllTestModuleTablesSelected ? L["DeleteAllRecords"].Value : L["DeleteSelectedRecords", SelectedTestModuleTables.Count].Value;
            
            if (!await UiMessageService.Confirm(message))
            {
                return;
            }

            if (AllTestModuleTablesSelected)
            {
                await TestModuleTablesAppService.DeleteAllAsync(Filter);
            }
            else
            {
                await TestModuleTablesAppService.DeleteByIdsAsync(SelectedTestModuleTables.Select(x => x.Id).ToList());
            }

            SelectedTestModuleTables.Clear();
            AllTestModuleTablesSelected = false;

            await GetTestModuleTablesAsync();
        }


    }
}
