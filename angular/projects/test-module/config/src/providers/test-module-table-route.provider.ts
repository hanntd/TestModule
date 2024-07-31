import { APP_INITIALIZER, inject } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { TEST_MODULE_TABLE_BASE_ROUTES } from './test-module-table-base.routes';

export const TEST_MODULE_TABLES_TEST_MODULE_TABLE_ROUTE_PROVIDER = [
  {
    provide: APP_INITIALIZER,
    multi: true,
    useFactory: configureRoutes,
  },
];

function configureRoutes() {
  const routesService = inject(RoutesService);

  return () => {
    const routes: ABP.Route[] = [...TEST_MODULE_TABLE_BASE_ROUTES];
    routesService.add(routes);
  };
}
