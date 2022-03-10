import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowFeedComponent } from './show-feed.component';

describe('ShowFeedComponent', () => {
  let component: ShowFeedComponent;
  let fixture: ComponentFixture<ShowFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowFeedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
