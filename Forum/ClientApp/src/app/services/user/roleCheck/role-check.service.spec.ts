import { TestBed } from '@angular/core/testing';

import { RoleCheckService } from './role-check.service';

describe('RoleCheckService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RoleCheckService = TestBed.get(RoleCheckService);
    expect(service).toBeTruthy();
  });
});
