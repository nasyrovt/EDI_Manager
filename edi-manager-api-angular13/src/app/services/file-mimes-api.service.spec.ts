import { TestBed } from '@angular/core/testing';

import { FileMimesApiService } from './file-mimes-api.service';

describe('FileTypesApiServiceService', () => {
  let service: FileMimesApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FileMimesApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
