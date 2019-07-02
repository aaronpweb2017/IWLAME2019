import { Component, OnInit } from '@angular/core';
import { Asignacion } from 'src/app/interfaces/asignacion';
import { Proyecto } from 'src/app/interfaces/proyecto';
import { Empleado } from 'src/app/interfaces/empleado';
import { AsignacionesService } from 'src/app/services/asignaciones-service';
import { ProyectosService } from 'src/app/services/proyectos-service';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { FechasService } from 'src/app/services/fechas-service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'asignaciones-index',
  templateUrl: './asignaciones-index.component.html',
  styleUrls: ['./asignaciones-component.css']
})

export class AsignacionesIndexComponent implements OnInit {
  NoAsignaciones: number; asignaciones: Asignacion[];
  id_asignacion: number; proyectos: Proyecto[];
  empleados: Empleado[]; NoPaginas: number;
  pageIndexes: number[]; curerntPage: number = 1;

  constructor(private asignacionesService: AsignacionesService, private proyectosService:
    ProyectosService, private empleadosService: EmpleadosService, private fechasService:
      FechasService, private toastrService: ToastrService, private router: Router) { }

  ngOnInit() {
    this.proyectos = []; this.empleados = [];
    this.id_asignacion = 0; this.NoPaginas = 0; this.pageIndexes = [];
    this.asignacionesService.GetNoAsignaciones().subscribe(data => {
      this.NoAsignaciones = Number(data);
      this.NoPaginas = Math.trunc(this.NoAsignaciones / 5);
      if (this.NoAsignaciones % 5 != 0)
        this.NoPaginas = this.NoPaginas + 1;
      for (let i: number = 0; i < this.NoPaginas; i++)
        this.pageIndexes[i] = i + 1;
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
    //console.log("Mensaje del Evento: " + eventMessage);
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
  }

  MuestraPagina(NoPagina: number) {
    this.curerntPage = NoPagina;
    this.asignacionesService.GetAsignacionesPaginacion(NoPagina).subscribe(data => {
      this.asignaciones = data as Asignacion[];
      this.asignacionesService.GetProyectosPaginacion(NoPagina).subscribe(data => {
        this.proyectos = data as Proyecto[];
        this.asignacionesService.GetEmpleadosPaginacion(NoPagina).subscribe(data => {
          this.empleados = data as Empleado[];
        });
      });
    });
  }
}