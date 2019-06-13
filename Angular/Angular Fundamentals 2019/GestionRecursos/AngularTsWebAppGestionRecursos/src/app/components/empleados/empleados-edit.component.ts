import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { Empleado } from 'src/app/interfaces/empleado';

@Component({
  selector: 'empleados-edit',
  templateUrl: './empleados-edit.component.html',
  styleUrls: ['./empleados-component.css']
})

export class EmpleadosEditComponent implements OnInit {
  empleadosService: EmpleadosService;
  toastr: ToastrService;
  id_empleado: number;
  empleado: Empleado;

  constructor(private employeeService: EmpleadosService, private toastrService:
    ToastrService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.empleadosService = this.employeeService;
    this.toastr = this.toastrService;
    this.empleado = {
      id_empleado: 0,
      nombre: "", apellido: "", direccion: "",
      telefono: "", sueldo: 0, status: 0
    };
    this.id_empleado = this.route.snapshot.params['id_empleado'];
    this.empleadosService.GetEmpleado(this.id_empleado).subscribe(data => {
      this.empleado.id_empleado = Number(Object.values(data)[0]);
      this.empleado.nombre = Object.values(data)[1].toString();
      this.empleado.apellido = Object.values(data)[2].toString();
      this.empleado.direccion = Object.values(data)[3].toString();
      this.empleado.telefono = Object.values(data)[4].toString();
      this.empleado.sueldo = Number(Object.values(data)[5]);
      this.empleado.status = Number(Object.values(data)[6]);
    });
  }

  ActualizarEmpleado(eventMessage: string) {
    console.log("Mensaje del Evento: " + eventMessage);
    if (this.empleado.nombre == "" || this.empleado.apellido == "" || this.empleado.direccion == ""
      || this.empleado.telefono == "" || this.empleado.sueldo < 3000 || this.empleado.sueldo > 10000) {
      this.toastrService.error("Datos vacíos o inválidos."); return;
    }
    this.employeeService.UpdateEmpleado(this.id_empleado, this.empleado).subscribe(data => {
      if (Object.values(data)) {
        this.toastr.success("Empleado actualizado con éxito.");
        this.router.navigate(['/empleados/index']);
      }
      else {
        this.toastr.error("No se pudo actualizar el empleado.");
      }
    });
  }

  RegresarEmpleados() {
    this.router.navigate(['/empleados/index']);
  }
}