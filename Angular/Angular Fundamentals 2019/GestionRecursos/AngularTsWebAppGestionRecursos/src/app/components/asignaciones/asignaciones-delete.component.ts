import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { Asignacion } from 'src/app/interfaces/asignacion';
import { AsignacionesService } from 'src/app/services/asignaciones-service';
import { ProyectosService } from 'src/app/services/proyectos-service';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { FechasService } from 'src/app/services/fechas-service';

@Component({
  selector: 'asignaciones-delete',
  templateUrl: './asignaciones-delete.component.html',
  styleUrls: ['./asignaciones-component.css']
})

export class AsignacionesDeleteComponent implements OnInit {
  id_asignacion: number;

  asignacion: Asignacion
  fecha_asignado: string;
  fecha_desasignado: string;
  proyecto_nombre: string;
  empleado_nombre: string;

  constructor(private projectsService: ProyectosService,
    private employeeService: EmpleadosService,
    private assignmentsService: AsignacionesService,
    private fechasService: FechasService,
    private toastrService: ToastrService,
    private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.asignacion = {
      id_asignacion: 0, id_proyecto: 0,
      id_empleado: 0, fecha_asignado: new Date(),
      fecha_desasignado: new Date()
    };
    this.fecha_asignado = ""; this.fecha_desasignado = "";
    this.proyecto_nombre = ""; this.empleado_nombre = "";
    this.id_asignacion = this.route.snapshot.params['id_asignacion'];
    this.assignmentsService.GetAsignacion(this.id_asignacion).subscribe(data => {
      this.asignacion.id_asignacion = Number(Object.values(data)[0]);
      this.asignacion.id_proyecto = Number(Object.values(data)[1]);
      this.asignacion.id_empleado = Number(Object.values(data)[2]);
      this.fecha_asignado = this.fechasService.GetDateYMD(Object.values(data)[3]).toString();
      this.fecha_desasignado = this.fechasService.GetDateYMD(Object.values(data)[4]).toString();
      this.projectsService.GetProyectos().subscribe(data => {
        let project_id: number = 0;
        for (let i = 0; i < Object.values(data).length; i++) {
          project_id = Number(Object.values(Object.values(data)[i])[0])
          if (this.asignacion.id_proyecto == project_id) {
            this.proyecto_nombre = Number(Object.values(Object.values(data)[i])[0])
              + ".- " + Object.values(Object.values(data)[i])[1].toString(); break;
          }
        }
      });
      this.employeeService.GetEmpleados().subscribe(data => {
        let employee_id: number = 0;
        for (let i = 0; i < Object.values(data).length; i++) {
          employee_id = Number(Object.values(Object.values(data)[i])[0]);
          if (this.asignacion.id_empleado == employee_id) {
            this.empleado_nombre = Number(Object.values(Object.values(data)[i])[0])
              + ".- " + Object.values(Object.values(data)[i])[1].toString()
              + " " + Object.values(Object.values(data)[i])[2].toString(); break;
          }
        }
      });
    });
  }

  BorrarAsignacion() {
    this.assignmentsService.DeleteAsignacion(this.id_asignacion).subscribe(data => {
      if (data) {
        this.toastrService.success("Asignación eliminada con éxito.");
        this.router.navigate(['/asignaciones/index']);
      }
      else
        this.toastrService.error("No se pudo eliminar la asignación.");
    });
  }

  RegresarAsignaciones() {
    this.router.navigate(['/asignaciones/index']);
  }
}