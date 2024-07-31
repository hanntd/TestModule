import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44398/',
  redirectUri: baseUrl,
  clientId: 'TestModule_App',
  responseType: 'code',
  scope: 'offline_access TestModule',
  requireHttps: true
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'TestModule',
    logoUrl: '',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44398',
      rootNamespace: 'TestModule',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
    TestModule: {
      url: 'https://localhost:44377',
      rootNamespace: 'TestModule',
    },
  },
} as Environment;
