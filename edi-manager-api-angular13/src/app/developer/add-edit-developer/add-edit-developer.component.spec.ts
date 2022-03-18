import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditDeveloperComponent } from './add-edit-developer.component';

describe('AddEditDeveloperComponent', () => {
  let component: AddEditDeveloperComponent;
  let fixture: ComponentFixture<AddEditDeveloperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditDeveloperComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditDeveloperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
