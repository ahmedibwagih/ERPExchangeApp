import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrivilagesComponent } from './Privilage.component';

describe('PrivilagesComponent', () => {
  let component: PrivilagesComponent;
  let fixture: ComponentFixture<PrivilagesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PrivilagesComponent]
    });
    fixture = TestBed.createComponent(PrivilagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
