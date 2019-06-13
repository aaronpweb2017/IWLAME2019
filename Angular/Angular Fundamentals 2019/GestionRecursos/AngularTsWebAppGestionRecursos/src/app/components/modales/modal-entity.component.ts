import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';

@Component({
    selector: 'modal-entity',
    templateUrl: './modal-entity.component.html'
})

export class ModalEntity implements OnInit {
    @Input() modalRequest: string;
    @Output() modalRequestEvent = new EventEmitter();
    @Input() modalEmpleado: number;
    @Output() modalEmpleadoEvent = new EventEmitter();

    ngOnInit() {
    }

    emitirEventoIdEmpleado(id_empleado: number) {
        this.modalEmpleadoEvent.emit(id_empleado);
    }

    emitirEventoModalAction(eventMessage: string) {
        this.modalRequestEvent.emit(eventMessage);
    }
}