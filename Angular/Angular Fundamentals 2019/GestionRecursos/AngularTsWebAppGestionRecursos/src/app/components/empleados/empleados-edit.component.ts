import { Component, OnInit } from '@angular/core';
import { Empleado } from 'src/app/interfaces/empleado';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'empleados-edit',
  templateUrl: './empleados-edit.component.html',
  styleUrls: ['./empleados-component.css']
})

export class EmpleadosEditComponent implements OnInit {
  id_empleado: number; empleado: Empleado; trabajando: boolean;

  constructor(private empleadosService: EmpleadosService, private toastrService:
    ToastrService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.empleado = {
      id_empleado: 0, nombre: "", apellido: "",
      direccion: "", telefono: "",
      sueldo: 0, status: 0
    };
    this.id_empleado = this.route.snapshot.params['id_empleado'];
    this.empleadosService.GetEmpleado(this.id_empleado).subscribe(data => {
      this.empleado = data as Empleado; this.trabajando = false;
      this.empleadosService.GetEmpleadoTrabajando(this.id_empleado).subscribe(data => {
        this.trabajando = Boolean(data);
      });
    });
  }

  ActualizarEmpleado(eventMessage: string) {
    //console.log("Mensaje del Evento: " + eventMessage);
    if (this.empleado.nombre == "" || this.empleado.apellido == ""
      || this.empleado.direccion == "" || this.empleado.telefono == ""
      || this.empleado.sueldo < 3000 || this.empleado.sueldo > 15000) {
      this.toastrService.error("Datos vacíos o inválidos."); return;
    }
    this.empleadosService.UpdateEmpleado(this.id_empleado, this.empleado).subscribe(data => {
      if (Boolean(data)) {
        this.toastrService.success("Empleado actualizado con éxito.");
        this.router.navigate(['/empleados/index']); return;
      }
      this.toastrService.error("No se pudo actualizar el empleado.");
    });
  }

  RegresarEmpleados() {
    this.router.navigate(['/empleados/index']);
  }
}