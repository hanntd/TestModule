import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { TestModuleComponent } from './components/test-module.component';
import { TestModuleRoutingModule } from './test-module-routing.module';

@NgModule({
  declarations: [TestModuleComponent],
  imports: [CoreModule, ThemeSharedModule, TestModuleRoutingModule],
  exports: [TestModuleComponent],
})
export class TestModuleModule {
  static forChild(): ModuleWithProviders<TestModuleModule> {
    return {
      ngModule: TestModuleModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<TestModuleModule> {
    return new LazyModuleFactory(TestModuleModule.forChild());
  }
}
