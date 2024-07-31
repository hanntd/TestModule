import { TestBed } from '@angular/core/testing';

import { TestModuleService } from './test-module.service';

describe('TestModuleService', () => {
  let service: TestModuleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestModuleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
