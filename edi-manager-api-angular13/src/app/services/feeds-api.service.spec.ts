import { TestBed } from '@angular/core/testing';

import { FeedsApiService } from './feeds-api.service';

describe('FeedsApiService', () => {
  let service: FeedsApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FeedsApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
