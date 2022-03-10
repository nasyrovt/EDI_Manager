import { TestBed } from '@angular/core/testing';

import { DevelopersApiService } from './developers-api.service';

describe('DevelopersApiService', () => {
  let service: DevelopersApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DevelopersApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
