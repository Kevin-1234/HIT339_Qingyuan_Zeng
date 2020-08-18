import { TestBed } from '@angular/core/testing';

import { EshoppingService } from './eshopping.service';

describe('EshoppingService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EshoppingService = TestBed.get(EshoppingService);
    expect(service).toBeTruthy();
  });
});
