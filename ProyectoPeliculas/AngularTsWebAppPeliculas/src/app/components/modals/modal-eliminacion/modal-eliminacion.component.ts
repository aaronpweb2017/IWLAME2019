import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-modal-eliminacion',
  templateUrl: './modal-eliminacion.component.html',
  styleUrls: []
})
export class ModalEliminacionComponent {
  @Input() request: string;
  @Input() id_model: number;
  @Output() modelIdEvent = new EventEmitter();

  emitModelIdEvent(id_model: number) {
    this.modelIdEvent.emit(id_model);
  }
}