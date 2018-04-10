import { TestBed, inject } from '@angular/core/testing';

import { InstituteService } from './institute.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('InstituteService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        InstituteService
      ],
      imports: [
        HttpClientTestingModule
      ]
    });
  });

  it('should be created', inject([InstituteService], (service: InstituteService) => {
    expect(service).toBeTruthy();
  }));
});
