import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeriesDatePickerComponent } from './series-date-picker.component';

describe('SeriesDatePickerComponent', () => {
  let component: SeriesDatePickerComponent;
  let fixture: ComponentFixture<SeriesDatePickerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SeriesDatePickerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SeriesDatePickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
