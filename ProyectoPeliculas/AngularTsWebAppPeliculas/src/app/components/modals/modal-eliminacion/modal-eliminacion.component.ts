import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-modal-eliminacion',
  templateUrl: './modal-eliminacion.component.html',
  styleUrls: []
})
export class ModalEliminacionComponent {
  @Input() request: string;
  @Input() model: any;
  @Output() modelObjectEvent = new EventEmitter();

  emitModelObjectEvent(model: any) {
    this.modelObjectEvent.emit(model);
  }
}