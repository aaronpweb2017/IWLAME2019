import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Asignacion } from 'src/app/interfaces/asignacion';
import { Empleado } from 'src/app/interfaces/empleado';
import { AsignacionesService } from 'src/app/services/asignaciones-service';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'empleados-index',
  templateUrl: './empleados-index.component.html',
  styleUrls: ['./empleados-component.css']
})

export class EmpleadosIndexComponent implements OnInit {
  no_empleados: number;
  empleados: Empleado[];
  empleadosasignados: Number[];
  id_empleado: number;
  noPaginas: number;
  pageIndexes: number[];
  curerntPage: number = 1;
  
  constructor(private empleadosService: EmpleadosService, private asignacionesService:
    AsignacionesService, private toastrService: ToastrService, private router: Router) { }

  ngOnInit() {
    this.id_empleado = 0; this.noPaginas = 0;
    this.pageIndexes = []; this.empleadosasignados = [];
    this.empleadosService.GetNoEmpleados().subscribe(data => {
      this.no_empleados = Number(data);
      this.noPaginas = Math.trunc((this.no_empleados) / 5);
      if ((this.no_empleados) % 5 != 0)
        this.noPaginas = this.noPaginas + 1;
      for (let i: number = 0; i < this.noPaginas; i++)
        this.pageIndexes[i] = (i + 1);
      this.MuestraPagina(this.curerntPage);
    });
  }

  CrearEmpleado() {
    this.router.navigate(['/empleados/create']);
  }

  EditarEmpleado(id_empleado: number) {
    this.router.navigate(['/empleados/edit', id_empleado]);
  }

  ActualizaIdEmpleado(id_empleado: number) {
    this.id_empleado = id_empleado;
  }

  BorrarEmpleado(eventMessage: string) {
    console.log("Mensaje del Evento: " + eventMessage);
    this.empleadosService.DeleteEmpleado(this.id_empleado).subscribe(data => {
      if (Boolean(data)) {
        this.toastrService.success("Empleado eliminado con éxito.");
        if (this.empleados.length == 1 && this.pageIndexes.length > 1) {
          this.curerntPage = this.curerntPage - 1; this.ngOnInit();
        }
        else if (this.empleados.length > 1)
          this.MuestraPagina(this.curerntPage);
        else
          this.ngOnInit();
        return;
      }
      this.toastrService.error("No se pudo eliminar el empleado.");
    });
  }

  MuestraPagina(noPagina: number) {
    this.curerntPage = noPagina; this.empleadosasignados = [];
    this.empleadosService.GetEmpleadosPaginacion(noPagina).subscribe(data => {
      this.empleados = Object.values(data); let asignacion: Asignacion;
      this.asignacionesService.GetAsignaciones().subscribe(data => {
        let asignaciones: Asignacion[] = Object.values(data);
        for (let i: number = 0; i < asignaciones.length; i++) {
          asignacion = asignaciones.find(asignacion =>
            asignacion.id_empleado === this.empleados[i].id_empleado)
          if (asignacion != null) { this.empleadosasignados[i] = 1; continue; }
          this.empleadosasignados[i] = 0;
        }
      });
    });
  }
}