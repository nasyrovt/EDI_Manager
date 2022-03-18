import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowCarrierComponent } from './show-carrier.component';

describe('ShowCarrierComponent', () => {
  let component: ShowCarrierComponent;
  let fixture: ComponentFixture<ShowCarrierComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowCarrierComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowCarrierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
