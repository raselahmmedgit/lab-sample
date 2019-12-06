import { TestBed } from '@angular/core/testing';

import { PixabayService } from './pixabay.service';

describe('PixabayService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PixabayService = TestBed.get(PixabayService);
    expect(service).toBeTruthy();
  });
});
