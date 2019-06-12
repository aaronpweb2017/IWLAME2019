import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { Empleado } from 'src/app/interfaces/empleado';

@Component({
    selector: 'empleados-create',
    templateUrl: './empleados-create.component.html',
    styleUrls: ['./empleados-component.css']
})

export class EmpleadosCreateComponent implements OnInit
{
  empleado: Empleado;

  constructor(private employeeService: EmpleadosService, private toastrService: ToastrService, private router: Router) { }

  ngOnInit() {
    this.empleado = {id_empleado: 0, 
        nombre: "", apellido: "", direccion: "", 
        telefono: "", sueldo: 0, status: 0
    };
  }
  
  //CrearEmpleado() {
  //  if(this.empleado.nombre =="" || this.empleado.apellido =="" || this.empleado.direccion =="" 
  //  || this.empleado.telefono =="" || this.empleado.sueldo < 3000 || this.empleado.status < 0) {
  //    this.toastrService.error("Datos vacíos o inválidos."); return;
  //  }
  //  this.employeeService.PostEmpleado(this.empleado).subscribe(data => {
  //    if(Object.values(data)) {
  //      this.toastrService.success("Empleado creado con éxito.");
  //      this.router.navigate(['/empleados/index']);
  //    }
  //    else
  //      this.toastrService.error("No se pudo crear el empleado.");
  //  });
  //}

  RegresarEmpleados() {
    this.router.navigate(['/empleados/index']);
  }
}