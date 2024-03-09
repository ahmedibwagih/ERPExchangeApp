import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IdentitySourcesComponent } from './identitySources.component';

describe('IdentitySourcesComponent', () => {
  let component: IdentitySourcesComponent;
  let fixture: ComponentFixture<IdentitySourcesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [IdentitySourcesComponent]
    });
    fixture = TestBed.createComponent(IdentitySourcesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
