import { ChangeDetectionStrategy, Component } from '@angular/core';
import {
  NgbDateAdapter,
  NgbTimeAdapter,
  NgbCollapseModule,
  NgbDatepickerModule,
  NgbTimepickerModule,
  NgbDropdownModule,
} from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { ListService, CoreModule } from '@abp/ng.core';
import { ThemeSharedModule, DateAdapter, TimeAdapter } from '@abp/ng.theme.shared';
import { PageModule } from '@abp/ng.components/page';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';

import { TestModuleTableViewService } from '../services/test-module-table.service';
import { TestModuleTableDetailViewService } from '../services/test-module-table-detail.service';
import { TestModuleTableDetailModalComponent } from './test-module-table-detail.component';
import {
  AbstractTestModuleTableComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './test-module-table.abstract.component';

@Component({
  selector: 'lib-test-module-table',
  changeDetection: ChangeDetectionStrategy.Default,
  standalone: true,
  imports: [
    ...ChildTabDependencies,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbTimepickerModule,
    NgbDropdownModule,

    NgxValidateCoreModule,

    PageModule,
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    TestModuleTableDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    TestModuleTableViewService,
    TestModuleTableDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './test-module-table.component.html',
  styles: `::ng-deep.datatable-row-detail { background: transparent !important; }`,
})
export class TestModuleTableComponent extends AbstractTestModuleTableComponent {}
