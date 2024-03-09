import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransferPurposesComponent } from './transferPurposes.component';

describe('TransferPurposesComponent', () => {
  let component: TransferPurposesComponent;
  let fixture: ComponentFixture<TransferPurposesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TransferPurposesComponent]
    });
    fixture = TestBed.createComponent(TransferPurposesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
