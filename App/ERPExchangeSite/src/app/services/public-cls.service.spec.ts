import { TestBed } from '@angular/core/testing';

import { PublicClsService } from './public-cls.service';

describe('PublicClsService', () => {
  let service: PublicClsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PublicClsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
