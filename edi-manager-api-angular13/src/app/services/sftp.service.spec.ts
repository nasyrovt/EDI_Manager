import { TestBed } from '@angular/core/testing';

import { SftpService } from './sftp.service';

describe('SftpService', () => {
  let service: SftpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SftpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
