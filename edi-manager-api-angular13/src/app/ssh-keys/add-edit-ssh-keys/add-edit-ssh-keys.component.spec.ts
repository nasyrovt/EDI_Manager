import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditSshKeysComponent } from './add-edit-ssh-keys.component';

describe('AddEditSshKeysComponent', () => {
  let component: AddEditSshKeysComponent;
  let fixture: ComponentFixture<AddEditSshKeysComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditSshKeysComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditSshKeysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
