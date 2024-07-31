import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetTestModuleTablesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  code?: string;
  name?: string;
  notes?: string;
}

export interface TestModuleTableCreateDto {
  code: string;
  name: string;
  notes: string;
}

export interface TestModuleTableDto extends FullAuditedEntityDto<string> {
  code: string;
  name: string;
  notes: string;
  concurrencyStamp?: string;
}

export interface TestModuleTableExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  code?: string;
  name?: string;
  notes?: string;
}

export interface TestModuleTableUpdateDto {
  code: string;
  name: string;
  notes: string;
  concurrencyStamp?: string;
}
