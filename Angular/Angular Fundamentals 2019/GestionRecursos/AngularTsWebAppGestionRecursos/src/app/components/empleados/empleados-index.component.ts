import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { Empleado } from 'src/app/interfaces/empleado';

@Component({
  selector: 'empleados-index',
  templateUrl: './empleados-index.component.html',
  styleUrls: ['./empleados-component.css']
})

export class EmpleadosIndexComponent implements OnInit {
  no_empleados: number;
  empleados: Empleado[];
  noPaginas: number;
  pageIndexes: number[];

  constructor(private employeeService: EmpleadosService, private router: Router) { }

  ngOnInit() {
    this.noPaginas = 0; this.pageIndexes = [];
    this.employeeService.GetNoEmpleados().subscribe(data => {
      this.no_empleados = Number(Object.values(data));
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

  BorrarEmpleado(id_empleado: number) {
    this.router.navigate(['/empleados/delete', id_empleado]);
  }

  MuestraPagina(no_pagina: number) {
    this.employeeService.GetEmpleadosPaginacion(no_pagina).subscribe(data => {
      this.empleados = Object.values(data);
    });
  }
}