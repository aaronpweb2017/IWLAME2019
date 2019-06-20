import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { ProyectosService } from 'src/app/services/proyectos-service';
import { AsignacionesService } from 'src/app/services/asignaciones-service';
import { Empleado } from 'src/app/interfaces/empleado';

@Component({
  selector: 'empleados-edit',
  templateUrl: './empleados-edit.component.html',
  styleUrls: ['./empleados-component.css']
})

export class EmpleadosEditComponent implements OnInit {
  id_empleado: number;
  empleado: Empleado;
  trabajando: Boolean;

  constructor(private empleadosService: EmpleadosService, private proyectosService:
    ProyectosService, private asignacionesService: AsignacionesService, private toastrService:
    ToastrService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
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
      this.trabajando = false;
      this.asignacionesService.GetAsignaciones().subscribe(data => {
        let id_proyecto: number = 0; let id_empleado: number = 0; 
        for (let i: number = 0; i < Object.values(data).length; i++) {
          if(this.trabajando) break;
          id_empleado = Number(Object.values(Object.values(data)[i])[2]);
          if (this.id_empleado == id_empleado) {
            id_proyecto = Number(Object.values(Object.values(data)[i])[1]);
            this.proyectosService.GetProyecto(id_proyecto).subscribe(data => {
              let status: Number = Number(Object.values(data)[5]);
              if(status!=2) { this.trabajando = true; }
            });
          }
        }
      });
    });
  }

  ActualizarEmpleado(eventMessage: string) {
    console.log("Mensaje del Evento: " + eventMessage);
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