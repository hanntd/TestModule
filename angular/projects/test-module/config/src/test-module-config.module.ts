import { ModuleWithProviders, NgModule } from '@angular/core';
import { TEST_MODULE_ROUTE_PROVIDERS } from './providers/route.provider';
import { TEST_MODULE_TABLES_TEST_MODULE_TABLE_ROUTE_PROVIDER } from './providers/test-module-table-route.provider';

@NgModule()
export class TestModuleConfigModule {
  static forRoot(): ModuleWithProviders<TestModuleConfigModule> {
    return {
      ngModule: TestModuleConfigModule,
      providers: [TEST_MODULE_ROUTE_PROVIDERS, TEST_MODULE_TABLES_TEST_MODULE_TABLE_ROUTE_PROVIDER],
    };
  }
}
