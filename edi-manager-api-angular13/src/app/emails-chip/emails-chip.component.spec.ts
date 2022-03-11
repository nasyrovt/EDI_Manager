import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmailsChipComponent } from './emails-chip.component';

describe('EmailsChipComponent', () => {
  let component: EmailsChipComponent;
  let fixture: ComponentFixture<EmailsChipComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmailsChipComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmailsChipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
