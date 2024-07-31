import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestModuleTableComponent } from './components/test-module-table.component';

export const routes: Routes = [
  {
    path: '',
    component: TestModuleTableComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TestModuleTableRoutingModule {}
