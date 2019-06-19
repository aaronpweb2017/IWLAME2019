import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Asignacion } from 'src/app/interfaces/asignacion';
import { Proyecto } from 'src/app/interfaces/proyecto';
import { Empleado } from 'src/app/interfaces/empleado';
import { AsignacionesService } from 'src/app/services/asignaciones-service';
import { ProyectosService } from 'src/app/services/proyectos-service';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { FechasService } from 'src/app/services/fechas-service';

@Component({
  selector: 'asignaciones-create',
  templateUrl: './asignaciones-create.component.html',
  styleUrls: ['./asignaciones-component.css']
})

export class AsignacionesCreateComponent implements OnInit {
  asignacion: Asignacion;
  currtent_date: string;
  fecha_asignado: string;
  fecha_desasignado: string;
  proyectos: Proyecto[];
  empleados: Empleado[];

  constructor(
    private asignacionesService: AsignacionesService, private proyectosService: ProyectosService,
    private empleadosService: EmpleadosService, private fechasService: FechasService,
    private toastrService: ToastrService, private router: Router) { }

  ngOnInit() {
    this.asignacion = {
      id_asignacion: 0, id_proyecto: 0,
      id_empleado: 0, fecha_asignado: new Date(),
      fecha_desasignado: new Date()
    };
    this.currtent_date = this.fechasService.GetCurrentDate();
    this.fecha_asignado = this.currtent_date;
    this.fecha_desasignado = this.currtent_date;
    this.proyectos = []; this.empleados = [];
    this.proyectosService.GetProyectos().subscribe(data => {
      let status: number = 0, index: number = 0; let fecha_fin: string = "";
      for (let i: number = 0; i < Object.values(data).length; i++) {
        status = Number(Object.values(Object.values(data)[i])[5]);
        fecha_fin = this.fechasService.GetDateYMD(Object.values(Object.values(data)[i])[4].toString());
        if (status != 2 && (new Date(this.currtent_date) < new Date(fecha_fin))) {
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
      for (let i: number = 0; i < Object.values(data).length; i++) {
        status = Number(Object.values(Object.values(data)[i])[6]);
        if (status == 1) {
          this.empleados[index] = {
            id_empleado: Number(Object.values(Object.values(data)[i])[0]),
            nombre: Object.values(Object.values(data)[i])[1].toString(),
            apellido: Object.values(Object.values(data)[i])[2].toString(),
            direccion: Object.values(Object.values(data)[i])[3].toString(),
            telefono: Object.values(Object.values(data)[i])[4].toString(),
            sueldo: Number(Object.values(Object.values(data)[i])[5]),
            status: Number(Object.values(Object.values(data)[i])[6])
          };
          index++;
        }
      }
    });
  }

  CrearAsignacion(eventMessage: string) {
    console.log("Mensaje del Evento: " + eventMessage);
    this.proyectosService.GetProyecto(this.asignacion.id_proyecto).subscribe(data => {
      let fecha_inicio: string = this.fechasService.GetDateYMD(Object.values(data)[3].toString());
      let fecha_fin: string = this.fechasService.GetDateYMD(Object.values(data)[4].toString());
      let estado: Number = Number(Object.values(data)[5]);
      if (this.asignacion.id_proyecto == 0 || this.asignacion.id_empleado == 0
        || this.fecha_asignado == "" || this.fecha_desasignado == "") {
        this.toastrService.error("Datos vacíos o inválidos."); return;
      }
      if ((new Date(this.fecha_asignado) < new Date(fecha_inicio))
        || (new Date(this.fecha_asignado) < new Date(this.currtent_date))) {
        this.toastrService.error("Inconsistencia en fecha de asignación."); return;
      }
      if (new Date(fecha_fin) < new Date(this.fecha_desasignado)) {
        this.toastrService.error("Inconsistencia en fecha de desasignación."); return;
      }
      if (estado == 0) {
        let proyecto: Proyecto = {
          id_proyecto: Number(Object.values(data)[0]),
          nombre: Object.values(data)[1].toString(),
          descripcion: Object.values(data)[2].toString(),
          fecha_inicio: new Date(Object.values(data)[3].toString()),
          fecha_fin: new Date(Object.values(data)[4].toString()), status: 1
        };
        this.proyectosService.UpdateProyecto(this.asignacion.id_proyecto, proyecto).subscribe(data => {
          if (Boolean(data))
            this.toastrService.success("Proyecto en estado proceso");
          else {
            this.toastrService.error("No se pudo procesar el proyecto."); return;
          }
        });
      }
      this.asignacion.fecha_asignado = new Date(this.fecha_asignado);
      this.asignacion.fecha_desasignado = new Date(this.fecha_desasignado);
      this.asignacionesService.PostAsignacion(this.asignacion).subscribe(data => {
        if (Boolean(data)) {
          this.toastrService.success("Asignación creada con éxito.");
          this.router.navigate(['/asignaciones/index']); return;
        }
        this.toastrService.error("No se pudo crear la asignación.");
      });
    });
  }

  RegresarAsignaciones() {
    this.router.navigate(['/asignaciones/index']);
  }
}