import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SshKeysComponent } from './ssh-keys.component';

describe('SshKeysComponent', () => {
  let component: SshKeysComponent;
  let fixture: ComponentFixture<SshKeysComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SshKeysComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SshKeysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
