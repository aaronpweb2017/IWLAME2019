import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Asignacion } from 'src/app/interfaces/asignacion';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { ProyectosService } from 'src/app/services/proyectos-service';
import { AsignacionesService } from 'src/app/services/asignaciones-service';

@Component({
  selector: 'asignaciones-index',
  templateUrl: './asignaciones-index.component.html',
  styleUrls: ['./asignaciones-component.css']
})

export class AsignacionesIndexComponent implements OnInit {
  no_asignaciones: number;
  asignaciones: Asignacion[];
  empleadosnames: string[];
  proyectosnames: string[];
  noPaginas: number;
  pageIndexes: number[];

  constructor(private employeeService: EmpleadosService, private projectsService: ProyectosService, private assignmentsService: AsignacionesService, private router: Router) { }

  ngOnInit() {
    this.proyectosnames = []; this.empleadosnames = [];
    this.noPaginas = 0; this.pageIndexes = [];
    this.assignmentsService.GetNoAsignaciones().subscribe(data => {
      this.no_asignaciones = Number(Object.values(data));
      this.noPaginas = Math.trunc((this.no_asignaciones) / 10);
      if ((this.no_asignaciones) % 10 != 0) {
        this.noPaginas = this.noPaginas + 1;
      }
      for (let i = 0; i < this.noPaginas; i++) {
        this.pageIndexes[i] = (i + 1);
      }
      this.MuestraPagina(1);
    });
  }

  CrearAsignacion() {
    this.router.navigate(['/asignaciones/create']);
  }

  EditarAsignacion(id_asignacion: number) {
    this.router.navigate(['/asignaciones/edit', id_asignacion]);
  }

  BorrarAsignacion(id_asignacion: number) {
    this.router.navigate(['/asignaciones/delete', id_asignacion]);
  }

  GetDateDMY(stringDate: String): string {
    return this.assignmentsService.GetDateDMY(stringDate);
  }

  MuestraPagina(no_pagina: number) {
    this.assignmentsService.GetAsignacionesPaginacion(no_pagina).subscribe(data => {
      this.asignaciones = Object.values(data);
      for (let i = 0; i < this.asignaciones.length; i++) {
        this.employeeService.GetEmpleado(this.asignaciones[i].id_empleado).subscribe(data => {
          this.empleadosnames[i] = Object.values(data)[1].toString()
          + " " + Object.values(data)[2].toString();
        });
        this.projectsService.GetProyecto(this.asignaciones[i].id_proyecto).subscribe(data => {
          this.proyectosnames[i] = Object.values(data)[1].toString();
        });
      }
    });
  }
}