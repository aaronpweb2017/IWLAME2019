import { Component, OnInit, Input } from '@angular/core';
import { Empleado } from 'src/app/interfaces/empleado';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
    selector: 'modal-create',
    templateUrl: './modal-create.component.html'
})

export class ModalCreate implements OnInit {
    @Input() empleado: Empleado;

    constructor(private employeeService: EmpleadosService, private toastrService: ToastrService, private router: Router) { }

    ngOnInit() {
       //Code here...
    }

    CrearEmpleado() {
        if (this.empleado.nombre == "" || this.empleado.apellido == "" || this.empleado.direccion == ""
            || this.empleado.telefono == "" || this.empleado.sueldo < 3000 || this.empleado.status < 0) {
            this.toastrService.error("Datos vacíos o inválidos."); return;
        }
        this.employeeService.PostEmpleado(this.empleado).subscribe(data => {
            if (Object.values(data)) {
                this.toastrService.success("Empleado creado con éxito.");
                this.router.navigate(['/empleados/index']);
            }
            else
                this.toastrService.error("No se pudo crear el empleado.");
        });
    }
}