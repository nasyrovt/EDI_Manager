import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowPlatformComponent } from './show-platform.component';

describe('ShowPlatformComponent', () => {
  let component: ShowPlatformComponent;
  let fixture: ComponentFixture<ShowPlatformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowPlatformComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowPlatformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
