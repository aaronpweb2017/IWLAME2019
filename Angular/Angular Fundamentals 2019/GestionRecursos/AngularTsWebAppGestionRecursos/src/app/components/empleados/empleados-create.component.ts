import { Component, OnInit } from '@angular/core';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { Empleado } from 'src/app/interfaces/empleado';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'empleados-create',
  templateUrl: './empleados-create.component.html',
  styleUrls: ['./empleados-component.css']
})

export class EmpleadosCreateComponent implements OnInit {
  empleado: Empleado;

  constructor(private empleadosService: EmpleadosService,
    private toastrService: ToastrService, private router: Router) { }

  ngOnInit() {
    this.empleado = {
      id_empleado: 0, nombre: "", apellido: "",
      direccion: "", telefono: "",
      sueldo: 0, status: 0
    };
  }

  CrearEmpleado(eventMessage: string) {
    //console.log("Mensaje del Evento: " + eventMessage);
    if (this.empleado.nombre == "" || this.empleado.apellido == ""
      || this.empleado.direccion == "" || this.empleado.telefono == ""
      || this.empleado.sueldo < 3000 || this.empleado.sueldo > 15000) {
      this.toastrService.error("Datos vacíos o inválidos."); return;
    }
    this.empleadosService.PostEmpleado(this.empleado).subscribe(data => {
      if (Boolean(data)) {
        this.toastrService.success("Empleado creado con éxito.");
        this.router.navigate(['/empleados/index']); return;
      }
      this.toastrService.error("No se pudo crear el empleado.");
    });
  }

  RegresarEmpleados() {
    this.router.navigate(['/empleados/index']);
  }
}