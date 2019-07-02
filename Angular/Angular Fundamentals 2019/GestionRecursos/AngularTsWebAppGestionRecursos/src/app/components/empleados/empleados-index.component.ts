import { Component, OnInit } from '@angular/core';
import { Empleado } from 'src/app/interfaces/empleado';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'empleados-index',
  templateUrl: './empleados-index.component.html',
  styleUrls: ['./empleados-component.css']
})

export class EmpleadosIndexComponent implements OnInit {
  NoEmpleados: number; empleados: Empleado[];
  id_empleado: number; asignados: number[];
  NoPaginas: number; pageIndexes: number[];
  curerntPage: number = 1;

  constructor(private empleadosService: EmpleadosService,
    private toastrService: ToastrService, private router: Router) { }

  ngOnInit() {
    this.id_empleado = 0; this.NoPaginas = 0;
    this.pageIndexes = []; this.asignados = [];
    this.empleadosService.GetNoEmpleados().subscribe(data => {
      this.NoEmpleados = Number(data);
      this.NoPaginas = Math.trunc(this.NoEmpleados / 5);
      if (this.NoEmpleados % 5 != 0)
        this.NoPaginas = this.NoPaginas + 1;
      for (let i: number = 0; i < this.NoPaginas; i++)
        this.pageIndexes[i] = i + 1;
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
    //console.log("Mensaje del Evento: " + eventMessage);
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

  MuestraPagina(NoPagina: number) {
    this.curerntPage = NoPagina; this.asignados = []; this.asignados = [];
    this.empleadosService.GetEmpleadosPaginacion(NoPagina).subscribe(data => {
      this.empleados = data as Empleado[];
      this.empleadosService.GetAsignadosPaginacion(NoPagina).subscribe(data => {
        this.asignados = data as number[];
      });
    });
  }
}
