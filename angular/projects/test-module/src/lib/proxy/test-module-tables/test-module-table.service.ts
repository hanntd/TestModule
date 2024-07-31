import type {
  GetTestModuleTablesInput,
  TestModuleTableCreateDto,
  TestModuleTableDto,
  TestModuleTableExcelDownloadDto,
  TestModuleTableUpdateDto,
} from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { AppFileDescriptorDto, DownloadTokenResultDto, GetFileInput } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class TestModuleTableService {
  apiName = 'TestModule';

  create = (input: TestModuleTableCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TestModuleTableDto>(
      {
        method: 'POST',
        url: '/api/test-module/test-module-tables',
        body: input,
      },
      { apiName: this.apiName, ...config }
    );

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/test-module/test-module-tables/${id}`,
      },
      { apiName: this.apiName, ...config }
    );

  deleteAll = (input: GetTestModuleTablesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/test-module/test-module-tables/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          code: input.code,
          name: input.name,
          notes: input.notes,
        },
      },
      { apiName: this.apiName, ...config }
    );

  deleteByIds = (testModuleTableIds: string[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/test-module/test-module-tables',
        params: { testModuleTableIds },
      },
      { apiName: this.apiName, ...config }
    );

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TestModuleTableDto>(
      {
        method: 'GET',
        url: `/api/test-module/test-module-tables/${id}`,
      },
      { apiName: this.apiName, ...config }
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/test-module/test-module-tables/download-token',
      },
      { apiName: this.apiName, ...config }
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/test-module/test-module-tables/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config }
    );

  getList = (input: GetTestModuleTablesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<TestModuleTableDto>>(
      {
        method: 'GET',
        url: '/api/test-module/test-module-tables',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          code: input.code,
          name: input.name,
          notes: input.notes,
        },
      },
      { apiName: this.apiName, ...config }
    );

  getListAsExcelFile = (input: TestModuleTableExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/test-module/test-module-tables/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          code: input.code,
          name: input.name,
          notes: input.notes,
        },
      },
      { apiName: this.apiName, ...config }
    );

  update = (id: string, input: TestModuleTableUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TestModuleTableDto>(
      {
        method: 'PUT',
        url: `/api/test-module/test-module-tables/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config }
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/test-module/test-module-tables/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config }
    );

  constructor(private restService: RestService) {}
}
