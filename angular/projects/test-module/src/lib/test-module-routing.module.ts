import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestModuleComponent } from './components/test-module.component';
import { loadTestModuleTableModuleAsChild } from './test-module-tables/test-module-table/test-module-table.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: TestModuleComponent,
  },
  { path: 'test-module-tables', loadChildren: loadTestModuleTableModuleAsChild },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TestModuleRoutingModule {}
