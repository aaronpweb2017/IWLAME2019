import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';

@Component({
    selector: 'modal-entity',
    templateUrl: './modal-entity.component.html'
})

export class ModalEntity implements OnInit {
    id_empleado: number;
    @Input() modalRequest: string;
    @Input() modalEmpleadoId: number;
    @Output() modalEvent = new EventEmitter();

    ngOnInit(): void {
        //console.log("modalEmpleadoId: "+this.modalEmpleadoId);
        this.id_empleado = 0;
    }

    MuestraIdEmpleado(id_empleado_clickeado: number) {
        //this.id_empleado = id_empleado_clickeado;
        //console.log("id_empleado_clickeado 1: " + this.id_empleado);
        this.modalEvent.emit(id_empleado_clickeado);
    }

    emitirEventoModal(eventMessage: string) {
        console.log("id_empleado_clickeado 2: " + this.id_empleado);
        this.modalEvent.emit(eventMessage);
    }
}