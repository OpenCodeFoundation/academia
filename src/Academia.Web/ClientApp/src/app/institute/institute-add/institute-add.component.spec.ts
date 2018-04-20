import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InstituteAddComponent } from './institute-add.component';

describe('InstituteAddComponent', () => {
  let component: InstituteAddComponent;
  let fixture: ComponentFixture<InstituteAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InstituteAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InstituteAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
