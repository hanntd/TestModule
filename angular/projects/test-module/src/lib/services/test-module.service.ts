import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class TestModuleService {
  apiName = 'TestModule';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/TestModule/sample' },
      { apiName: this.apiName }
    );
  }
}
