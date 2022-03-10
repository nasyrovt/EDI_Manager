import { TestBed } from '@angular/core/testing';

import { FileTypesApiService } from './file-types-api.service';

describe('FileTypesApiServiceService', () => {
  let service: FileTypesApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FileTypesApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
