import { TestBed } from '@angular/core/testing';

import { PlatformsApiService } from './platforms-api.service';

describe('PlatformsApiService', () => {
  let service: PlatformsApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlatformsApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
