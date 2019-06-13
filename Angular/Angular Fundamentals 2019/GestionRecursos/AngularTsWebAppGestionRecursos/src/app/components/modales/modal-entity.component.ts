import { Component, Input, Output, EventEmitter} from '@angular/core';

@Component({
    selector: 'modal-entity',
    templateUrl: './modal-entity.component.html'
})

export class ModalEntity {
    @Input() modalRequest: string;
    @Output() modalRequestEvent = new EventEmitter();
    @Input() modalEntity: number;
    @Output() modalEntityEvent = new EventEmitter();

    emitirEventoIdEntity(id_entity: number) {
        this.modalEntityEvent.emit(id_entity);
    }

    emitirEventoModalAction(eventMessage: string) {
        this.modalRequestEvent.emit(eventMessage);
    }
}