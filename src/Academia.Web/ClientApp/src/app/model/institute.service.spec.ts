import { TestBed, inject } from '@angular/core/testing';

import { InstituteService } from './institute.service';
import { HttpClientModule } from '@angular/common/http';

describe('InstituteService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        InstituteService
      ],
      imports: [
        HttpClientModule
      ]
    });
  });

  it('should be created', inject([InstituteService], (service: InstituteService) => {
    expect(service).toBeTruthy();
  }));
});
