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
      this.asignacion.id_asignacion = Number(Object.values(data)[0]);
      this.asignacion.id_proyecto = Number(Object.values(data)[1]);
      this.asignacion.id_empleado = Number(Object.values(data)[2]);
      this.fecha_asignado = this.fechasService.GetDateYMD(Object.values(data)[3].toString());
      this.fecha_desasignado = this.fechasService.GetDateYMD(Object.values(data)[4].toString());
      this.currtent_date = this.fecha_asignado;
    });
    this.proyectos = []; this.empleados = [];
    this.proyectosService.GetProyectos().subscribe(data => {
      let status: number = 0, index: number = 0; let fecha_fin: string = "";
      for (let i = 0; i < Object.values(data).length; i++) {
        status = Number(Object.values(Object.values(data)[i])[5]);
        fecha_fin = this.fechasService.GetDateYMD(Object.values(Object.values(data)[i])[4].toString());
        if (status == 1 && (new Date(fecha_fin)) > (new Date(this.currtent_date))) {
          this.proyectos[index] = {
            id_proyecto: Number(Object.values(Object.values(data)[i])[0]),
            nombre: Object.values(Object.values(data)[i])[1].toString(),
            descripcion: Object.values(Object.values(data)[i])[2].toString(),
            fecha_inicio: new Date(), fecha_fin: new Date(),
            status: Number(Object.values(Object.values(data)[i])[5])
          };
          index++;
        }
      }
    });
    this.empleadosService.GetEmpleados().subscribe(data => {
      let status: number = 0, index: number = 0;
      for (let i = 0; i < Object.values(data).length; i++) {
        status = Number(Object.values(Object.values(data)[i])[6]);
        if (status == 1) {
          this.empleados[index] = {
            id_empleado: Number(Object.values(Object.values(data)[i])[0]),
            nombre: Object.values(Object.values(data)[i])[1].toString(),
            apellido: Object.values(Object.values(data)[i])[2].toString(),
            direccion: Object.values(Object.values(data)[i])[3].toString(),
            telefono: Object.values(Object.values(data)[i])[4].toString(),
            sueldo: Number(Object.values(Object.values(data)[0])[5]),
            status: Number(Object.values(Object.values(data)[0])[6])
          };
          index++;
        }
      }
    });
  }

  ActualizarAsignacion(eventMessage: string) {
    console.log("Mensaje del Evento: " + eventMessage);
    this.proyectosService.GetProyecto(this.asignacion.id_proyecto).subscribe(data => {
      let fecha_inicio: string = this.fechasService.GetDateYMD(Object.values(data)[3].toString());
      let fecha_fin: string = this.fechasService.GetDateYMD(Object.values(data)[4].toString());
      if (this.asignacion.id_proyecto == 0 || this.asignacion.id_empleado == 0
        || this.fecha_asignado == "" || this.fecha_desasignado == "") {
        this.toastrService.error("Datos vacíos o inválidos."); return;
      }
      if ((new Date(this.fecha_asignado) < new Date(fecha_inicio)) ||
        (new Date(this.fecha_asignado) < new Date(this.currtent_date))) {
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
      });
    });
  }

  RegresarAsignaciones() {
    this.router.navigate(['/asignaciones/index']);
  }
}