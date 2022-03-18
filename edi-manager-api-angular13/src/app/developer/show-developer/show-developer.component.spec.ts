import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowDeveloperComponent } from './show-developer.component';

describe('ShowDeveloperComponent', () => {
  let component: ShowDeveloperComponent;
  let fixture: ComponentFixture<ShowDeveloperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowDeveloperComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowDeveloperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
