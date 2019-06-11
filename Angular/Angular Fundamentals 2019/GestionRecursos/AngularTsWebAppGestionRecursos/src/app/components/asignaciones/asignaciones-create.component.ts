import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Asignacion } from 'src/app/interfaces/asignacion';
import { AsignacionesService } from 'src/app/services/asignaciones-service';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { ProyectosService } from 'src/app/services/proyectos-service';
import { Empleado } from 'src/app/interfaces/empleado';
import { Proyecto } from 'src/app/interfaces/proyecto';
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

  constructor(private projectsService: ProyectosService, private employeeService: EmpleadosService,
    private assignmentsService: AsignacionesService, private fechasService: FechasService,
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
    this.projectsService.GetProyectos().subscribe(data => {
      let status: number = 0, index: number = 0;
      for (let i = 0; i < Object.values(data).length; i++) {
        status = Number(Object.values(Object.values(data)[i])[5]);
        if (status == 1) {
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
    this.employeeService.GetEmpleados().subscribe(data => {
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
            sueldo: Number(Object.values(Object.values(data)[i])[5]),
            status: Number(Object.values(Object.values(data)[i])[6])
          };
          index++;
        }
      }
    });
  }

  CrearAsignacion() {
    if (this.asignacion.id_proyecto == 0 || this.asignacion.id_empleado == 0
      || this.fecha_asignado == "" || this.fecha_desasignado == ""
      || (new Date(this.fecha_asignado)) >= (new Date(this.fecha_desasignado))) {
      this.toastrService.error("Datos vacíos o inválidos."); return;
    }
    this.asignacion.fecha_asignado = new Date(this.fecha_asignado);
    this.asignacion.fecha_desasignado = new Date(this.fecha_desasignado);
    this.assignmentsService.PostAsignacion(this.asignacion).subscribe(data => {
      if (Object.values(data)) {
        this.toastrService.success("Asignación creada con éxito.");
        this.router.navigate(['/asignaciones/index']);
      }
      else
        this.toastrService.error("No se pudo crear la asignación.");
    });
  }

  RegresarAsignaciones() {
    this.router.navigate(['/asignaciones/index']);
  }
}