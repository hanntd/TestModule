import { ABP, eLayoutType } from '@abp/ng.core';

import { eTestModuleRouteNames } from '../enums/route-names';

export const TEST_MODULE_TABLE_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/test-module/test-module-tables',
    parentName: eTestModuleRouteNames.TestModule,
    name: 'TestModule::Menu:TestModuleTables',
    layout: eLayoutType.application,
    requiredPolicy: 'TestModule.TestModuleTables',
    breadcrumbText: 'TestModule::TestModuleTables',
  },
];
