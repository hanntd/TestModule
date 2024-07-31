import { NgModule } from '@angular/core';
import { TestModuleTableComponent } from './components/test-module-table.component';
import { TestModuleTableRoutingModule } from './test-module-table-routing.module';

@NgModule({
  declarations: [],
  imports: [TestModuleTableComponent, TestModuleTableRoutingModule],
})
export class TestModuleTableModule {}

export function loadTestModuleTableModuleAsChild() {
  return Promise.resolve(TestModuleTableModule);
}
