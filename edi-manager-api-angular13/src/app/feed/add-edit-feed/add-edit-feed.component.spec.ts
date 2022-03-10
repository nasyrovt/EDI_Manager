import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditFeedComponent } from './add-edit-feed.component';

describe('AddEditFeedComponent', () => {
  let component: AddEditFeedComponent;
  let fixture: ComponentFixture<AddEditFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditFeedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
