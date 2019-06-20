import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Asignacion } from 'src/app/interfaces/asignacion';
import { Proyecto } from 'src/app/interfaces/proyecto';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { ProyectosService } from 'src/app/services/proyectos-service';
import { AsignacionesService } from 'src/app/services/asignaciones-service';
import { FechasService } from 'src/app/services/fechas-service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'asignaciones-index',
  templateUrl: './asignaciones-index.component.html',
  styleUrls: ['./asignaciones-component.css']
})

export class AsignacionesIndexComponent implements OnInit {
  no_asignaciones: number;
  asignaciones: Asignacion[];
  id_asignacion: number;
  empleadosnames: string[];
  proyectosnames: string[];
  proyectosestados: Number[];
  noPaginas: number;
  pageIndexes: number[];
  curerntPage: number = 1;

  constructor(private empleadosService: EmpleadosService, private proyectosService: ProyectosService,
    private asignacionesService: AsignacionesService, private fechasService: FechasService,
    private toastrService: ToastrService, private router: Router) { }

  ngOnInit() {
    this.proyectosnames = []; this.empleadosnames = []; this.proyectosestados = [];
    this.id_asignacion = 0; this.noPaginas = 0; this.pageIndexes = [];
    this.asignacionesService.GetNoAsignaciones().subscribe(data => {
      this.no_asignaciones = Number(data);
      this.noPaginas = Math.trunc((this.no_asignaciones) / 5);
      if ((this.no_asignaciones) % 5 != 0)
        this.noPaginas = this.noPaginas + 1;
      for (let i: number = 0; i < this.noPaginas; i++)
        this.pageIndexes[i] = (i + 1);
      this.MuestraPagina(this.curerntPage);
    });
  }

  CrearAsignacion() {
    this.router.navigate(['/asignaciones/create']);
  }

  EditarAsignacion(id_asignacion: number) {
    this.router.navigate(['/asignaciones/edit', id_asignacion]);
  }

  ActualizaIdAsignacion(id_asignacion: number) {
    this.id_asignacion = id_asignacion;
  }

  BorrarAsignacion(eventMessage: string) {
    console.log("Mensaje del Evento: " + eventMessage);
    this.asignacionesService.GetAsignacion(this.id_asignacion).subscribe(data => {
      let id_proyecto_asignacion: number = Number(Object.values(data)[1]);
      this.asignacionesService.GetAsignaciones().subscribe(data => {
        let id_asignacion: number = 0;
        let id_proyecto: number = 0;
        let proyecto_asignado: Boolean = false;
        for (let i: number = 0; i < Object.values(data).length; i++) {
          id_asignacion = Number(Object.values(Object.values(data)[i])[0]);
          id_proyecto = Number(Object.values(Object.values(data)[i])[1]);
          if (id_asignacion != this.id_asignacion
            && id_proyecto == id_proyecto_asignacion) {
            proyecto_asignado = true; break;
          }
        }
        if (!proyecto_asignado) {
          this.proyectosService.GetProyecto(id_proyecto_asignacion).subscribe(data => {
            let proyecto: Proyecto = {
              id_proyecto: Number(Object.values(data)[0]),
              nombre: Object.values(data)[1].toString(),
              descripcion: Object.values(data)[2].toString(),
              fecha_inicio: new Date(Object.values(data)[3].toString()),
              fecha_fin: new Date(Object.values(data)[4].toString()), status: 0
            };
            this.proyectosService.UpdateProyecto(id_proyecto_asignacion, proyecto).subscribe(data => {
              if (Boolean(data))
                this.toastrService.success("Proyecto en estado inactivo");
              else {
                this.toastrService.error("No se pudo desactivar el proyecto."); return;
              }
            });
          });
        }
      });
      this.asignacionesService.DeleteAsignacion(this.id_asignacion).subscribe(data => {
        if (Boolean(data)) {
          this.toastrService.success("Asignación eliminada con éxito.");
          if (this.asignaciones.length == 1 && this.pageIndexes.length > 1) {
            this.curerntPage = this.curerntPage - 1; this.ngOnInit();
          }
          else if (this.asignaciones.length > 1)
            this.MuestraPagina(this.curerntPage);
          else
            this.ngOnInit();
          return;
        }
        this.toastrService.error("No se pudo eliminar la asignación.");
      });
    });
  }

  MuestraPagina(noPagina: number) {
    this.curerntPage = noPagina;
    this.asignacionesService.GetAsignacionesPaginacion(noPagina).subscribe(data => {
      this.asignaciones = Object.values(data);
      for (let i: number = 0; i < this.asignaciones.length; i++) {
        this.empleadosService.GetEmpleado(this.asignaciones[i].id_empleado).subscribe(data => {
          this.empleadosnames[i] = Number(Object.values(data)[0])
            + ".- " + Object.values(data)[1].toString() + " " + Object.values(data)[2].toString();
        });
        this.proyectosService.GetProyecto(this.asignaciones[i].id_proyecto).subscribe(data => {
          this.proyectosnames[i] = Number(Object.values(data)[0]) + ".- " + Object.values(data)[1].toString();
          this.proyectosestados[i] = Number(Object.values(data)[5]);
        });
      }
    });
  }
}