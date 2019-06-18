import { Component, Input, Output, EventEmitter} from '@angular/core';

@Component({
    selector: 'modal-entity',
    templateUrl: './modal-entity.component.html'
})

export class ModalEntity {
    @Input() modalEntity: number;
    @Output() modalEntityEvent = new EventEmitter();
    @Input() modalRequest: string;
    @Output() modalRequestEvent = new EventEmitter();

    emitirEventoModalEntity(id_entity: number) {
        this.modalEntityEvent.emit(id_entity);
    }

    emitirEventoModalRequest(eventMessage: string) {
        this.modalRequestEvent.emit(eventMessage);
    }
}