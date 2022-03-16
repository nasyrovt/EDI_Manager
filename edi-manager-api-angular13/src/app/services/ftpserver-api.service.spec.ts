import { TestBed } from '@angular/core/testing';

import { FtpserverApiService } from './ftpserver-api.service';

describe('FtpserverApiService', () => {
  let service: FtpserverApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FtpserverApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
