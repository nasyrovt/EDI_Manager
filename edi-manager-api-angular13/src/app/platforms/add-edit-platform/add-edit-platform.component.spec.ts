import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditPlatformComponent } from './add-edit-platform.component';

describe('AddEditPlatformComponent', () => {
  let component: AddEditPlatformComponent;
  let fixture: ComponentFixture<AddEditPlatformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditPlatformComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditPlatformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
