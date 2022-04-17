import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowSshKeysComponent } from './show-ssh-keys.component';

describe('ShowSshKeysComponent', () => {
  let component: ShowSshKeysComponent;
  let fixture: ComponentFixture<ShowSshKeysComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowSshKeysComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowSshKeysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
