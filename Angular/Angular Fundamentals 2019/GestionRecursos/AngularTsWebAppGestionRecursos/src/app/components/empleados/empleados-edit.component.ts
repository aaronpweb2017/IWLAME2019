import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { Asignacion } from 'src/app/interfaces/asignacion';
import { Empleado } from 'src/app/interfaces/empleado';
import { AsignacionesService } from 'src/app/services/asignaciones-service';
import { ProyectosService } from 'src/app/services/proyectos-service';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { Proyecto } from 'src/app/interfaces/proyecto';

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
      this.empleado = data as Empleado; this.trabajando = false;
      this.proyectosService.GetProyectos().subscribe(data => {
        let proyectos: Proyecto[] = Object.values(data);
        this.asignacionesService.GetAsignaciones().subscribe(data => {
          let asignaciones: Asignacion[] = Object.values(data);
          for (let i: number = 0; i < asignaciones.length; i++) {
            if (this.trabajando) break;
            if (this.id_empleado == asignaciones[i].id_empleado) {
              let proyecto: Proyecto = proyectos.find(project =>
                project.id_proyecto === asignaciones[i].id_proyecto);
              if (proyecto.status != 2) this.trabajando = true;
            }
          }
        });
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