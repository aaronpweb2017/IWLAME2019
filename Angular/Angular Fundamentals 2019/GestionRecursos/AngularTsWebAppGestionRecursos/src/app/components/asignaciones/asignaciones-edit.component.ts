import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { Asignacion } from 'src/app/interfaces/asignacion';
import { AsignacionesService } from 'src/app/services/asignaciones-service';
import { Proyecto } from 'src/app/interfaces/proyecto';
import { Empleado } from 'src/app/interfaces/empleado';
import { ProyectosService } from 'src/app/services/proyectos-service';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { FechasService } from 'src/app/services/fechas-service';

@Component({
  selector: 'asignaciones-edit',
  templateUrl: './asignaciones-edit.component.html',
  styleUrls: ['./asignaciones-component.css']
})

export class AsignacionesEditComponent implements OnInit {
  id_asignacion: number;
  asignacion: Asignacion;
  currtent_date: string;
  fecha_asignado: string;
  fecha_desasignado: string;
  proyectos: Proyecto[];
  empleados: Empleado[];

  constructor(
    private asignacionesService: AsignacionesService, private proyectosService: ProyectosService,
    private empleadosService: EmpleadosService, private fechasService: FechasService,
    private toastrService: ToastrService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.asignacion = {
      id_asignacion: 0, id_proyecto: 0,
      id_empleado: 0, fecha_asignado: new Date(),
      fecha_desasignado: new Date()
    };
    this.id_asignacion = this.route.snapshot.params['id_asignacion'];
    this.asignacionesService.GetAsignacion(this.id_asignacion).subscribe(data => {
      this.asignacion = data as Asignacion; this.fecha_asignado = ""; this.fecha_desasignado = ""
      this.fecha_asignado = this.fechasService.GetDateYMD(this.asignacion.fecha_asignado);
      this.fecha_desasignado = this.fechasService.GetDateYMD(this.asignacion.fecha_desasignado);
      this.currtent_date = this.fecha_asignado;
    });
    this.proyectos = []; this.empleados = [];
    this.proyectosService.GetProyectos().subscribe(data => {
      let status: number = 0, index: number = 0; let fecha_fin: string = "";
      let proyectos: Proyecto[] = Object.values(data);
      for (let i: number = 0; i < proyectos.length; i++) {
        status = proyectos[i].status;
        fecha_fin = this.fechasService.GetDateYMD(proyectos[i].fecha_fin);
        if (status != 2 && (new Date(fecha_fin) > new Date(this.currtent_date))) {
          this.proyectos[index] = proyectos[i]; index++;
        }
      }
    });
    this.empleadosService.GetEmpleados().subscribe(data => {
      let status: number = 0, index: number = 0;
      let empleados: Empleado[] = Object.values(data);
      for (let i: number = 0; i < empleados.length; i++) {
        status = empleados[i].status;
        if (status == 1) {
          this.empleados[index] = empleados[i];
          index++;
        }
      }
    });
  }

  ActualizarAsignacion(eventMessage: string) {
    console.log("Mensaje del Evento: " + eventMessage);
    if (this.asignacion.id_proyecto == 0 || this.asignacion.id_empleado == 0
      || this.fecha_asignado == "" || this.fecha_desasignado == "") {
      this.toastrService.error("Datos vacíos o inválidos."); return;
    }
    let proyecto: Proyecto = this.proyectos.find(project =>
      project.id_proyecto === Number(this.asignacion.id_proyecto));
    let fecha_inicio: string = this.fechasService.GetDateYMD(proyecto.fecha_inicio);
    let fecha_fin: string = this.fechasService.GetDateYMD(proyecto.fecha_fin);
    if ((new Date(this.fecha_asignado) < new Date(fecha_inicio))
      || (new Date(this.fecha_asignado) < new Date(this.currtent_date))) {
      this.toastrService.error("Inconsistencia en fecha de asignación."); return;
    }
    if (new Date(fecha_fin) < new Date(this.fecha_desasignado)) {
      this.toastrService.error("Inconsistencia en fecha de desasignación."); return;
    }
    this.asignacion.fecha_asignado = new Date(this.fecha_asignado);
    this.asignacion.fecha_desasignado = new Date(this.fecha_desasignado);
    this.asignacionesService.UpdateAsignacion(this.id_asignacion, this.asignacion).subscribe(data => {
      if (Boolean(data)) {
        this.toastrService.success("Asignación actualizada con éxito.");
        this.router.navigate(['/asignaciones/index']); return;
      }
      this.toastrService.error("No se pudo actualizar la asignación.");
    });
  }

  RegresarAsignaciones() {
    this.router.navigate(['/asignaciones/index']);
  }
}