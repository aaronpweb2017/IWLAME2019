import { Component, Input, Output, EventEmitter, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal'

@Component({
  selector: 'app-modal-eliminacion',
  templateUrl: './modal-eliminacion.component.html',
  styleUrls: []
})
export class ModalEliminacionComponent {
  modalRef: BsModalRef;
  @Input() request: string;
  @Input() model: any;
  @Output() modelIdentifierEvent = new EventEmitter();

  constructor(private modalService: BsModalService) {  }

  emitModelIdentifierEvent() {
    this.modelIdentifierEvent.emit(this.model);
    this.modalRef.hide();
  }

  public openModal(modalTemplate: TemplateRef<any>) {
    this.modalRef = this.modalService.show(modalTemplate);
  }
}