import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditAccountsComponent } from './add-edit-accounts.component';

describe('AddEditAccountsComponent', () => {
  let component: AddEditAccountsComponent;
  let fixture: ComponentFixture<AddEditAccountsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditAccountsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditAccountsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
