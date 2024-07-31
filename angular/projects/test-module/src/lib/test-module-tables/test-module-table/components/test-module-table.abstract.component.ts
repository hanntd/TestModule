import { Directive, OnInit, inject } from '@angular/core';

import { ListService, TrackByService } from '@abp/ng.core';

import type { TestModuleTableDto } from '../../../proxy/test-module-tables/models';
import { TestModuleTableViewService } from '../services/test-module-table.service';
import { TestModuleTableDetailViewService } from '../services/test-module-table-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive({ standalone: true })
export abstract class AbstractTestModuleTableComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(TestModuleTableViewService);
  public readonly serviceDetail = inject(TestModuleTableDetailViewService);
  protected title = 'TestModule::TestModuleTables';

  ngOnInit() {
    this.service.hookToQuery();
  }

  clearFilters() {
    this.service.clearFilters();
  }

  showForm() {
    this.serviceDetail.showForm();
  }

  create() {
    this.serviceDetail.selected = undefined;
    this.serviceDetail.showForm();
  }

  update(record: TestModuleTableDto) {
    this.serviceDetail.update(record);
  }

  delete(record: TestModuleTableDto) {
    this.service.delete(record);
  }

  exportToExcel() {
    this.service.exportToExcel();
  }
}
