import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Asignacion } from 'src/app/interfaces/asignacion';
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
  noPaginas: number;
  pageIndexes: number[];
  curerntPage: number = 1;

  constructor(private empleadosService: EmpleadosService, private proyectosService: ProyectosService,
    private asignacionesService: AsignacionesService, private fechasService: FechasService,
    private toastrService: ToastrService, private router: Router) { }

  ngOnInit() {
    this.proyectosnames = []; this.empleadosnames = [];
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
        });
      }
    });
  }
}