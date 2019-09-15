import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-modal-actualizacion',
  templateUrl: './modal-actualizacion.component.html',
  styleUrls: []
})
export class ModalActualizacionComponent {
  @Input() request: string;
  @Input() model: any;
  @Output() modelObjectEvent = new EventEmitter();

  emitModelObjectEvent(model: any) {
    this.modelObjectEvent.emit(model);
  }
}