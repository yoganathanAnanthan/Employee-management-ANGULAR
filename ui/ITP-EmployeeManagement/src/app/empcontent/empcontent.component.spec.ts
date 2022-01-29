import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpcontentComponent } from './empcontent.component';

describe('EmpcontentComponent', () => {
  let component: EmpcontentComponent;
  let fixture: ComponentFixture<EmpcontentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmpcontentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmpcontentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
