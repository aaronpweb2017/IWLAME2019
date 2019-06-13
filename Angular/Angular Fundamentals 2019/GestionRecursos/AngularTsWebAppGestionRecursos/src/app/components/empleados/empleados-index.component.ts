import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { Empleado } from 'src/app/interfaces/empleado';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'empleados-index',
  templateUrl: './empleados-index.component.html',
  styleUrls: ['./empleados-component.css']
})

export class EmpleadosIndexComponent implements OnInit {
  no_empleados: number;
  empleados: Empleado[];
  id_empleado: number;
  noPaginas: number;
  pageIndexes: number[];

  constructor(private employeeService: EmpleadosService,
    private toastrService: ToastrService, private router: Router) { }

  ngOnInit() {
    this.id_empleado = 0; this.noPaginas = 0; this.pageIndexes = [];
    this.employeeService.GetNoEmpleados().subscribe(data => {
      this.no_empleados = Number(data);
      this.noPaginas = Math.trunc((this.no_empleados) / 10);
      if ((this.no_empleados) % 10 != 0) {
        this.noPaginas = this.noPaginas + 1;
      }
      for (let i = 0; i < this.noPaginas; i++) {
        this.pageIndexes[i] = (i + 1);
      }
      this.MuestraPagina(1);
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
    this.employeeService.DeleteEmpleado(this.id_empleado).subscribe(data => {
      if (data) {
        this.toastrService.success("Empleado eliminado con éxito.");
        this.router.navigate(['/empleados/index']);
      }
      else {
        this.toastrService.error("No se pudo eliminar el empleado seleccionado.");
      }
    });
  }

  //BorrarEmpleado(id_empleado: number) {
  //  this.router.navigate(['/empleados/delete', id_empleado]);
  //}

  MuestraPagina(no_pagina: number) {
    this.employeeService.GetEmpleadosPaginacion(no_pagina).subscribe(data => {
      this.empleados = Object.values(data);
    });
  }
}