import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-generic-alert',
  templateUrl: './generic-alert.component.html',
  styleUrls: ['./generic-alert.component.scss']
})
export class GenericAlertComponent {

  @Input() message: any  ;
  @Input() type: any ;
  @Output() close = new EventEmitter<void>();

  closeAlert() {
    this.close.emit();
  }
}
