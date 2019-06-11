import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { Asignacion } from 'src/app/interfaces/asignacion';
import { AsignacionesService } from 'src/app/services/asignaciones-service';
import { Proyecto } from 'src/app/interfaces/proyecto';
import { Empleado } from 'src/app/interfaces/empleado';
import { ProyectosService } from 'src/app/services/proyectos-service';
import { EmpleadosService } from 'src/app/services/empleados-service';
import { FechasService } from 'src/app/services/fechas-service';

@Component({
  selector: 'asignaciones-edit',
  templateUrl: './asignaciones-edit.component.html',
  styleUrls: ['./asignaciones-component.css']
})

export class AsignacionesEditComponent implements OnInit {
  id_asignacion: number;
  asignacion: Asignacion;
  currtent_date: string;
  fecha_asignado: string;
  fecha_desasignado: string;
  proyectos: Proyecto[];
  empleados: Empleado[];

  constructor(private projectsService: ProyectosService,
    private employeeService: EmpleadosService,
    private assignmentsService: AsignacionesService,
    private fechasService: FechasService,
    private toastrService: ToastrService,
    private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.asignacion = {
      id_asignacion: 0, id_proyecto: 0,
      id_empleado: 0, fecha_asignado: new Date(),
      fecha_desasignado: new Date()
    };
    this.id_asignacion = this.route.snapshot.params['id_asignacion'];
    this.assignmentsService.GetAsignacion(this.id_asignacion).subscribe(data => {
      this.asignacion.id_asignacion = Number(Object.values(data)[0]);
      this.asignacion.id_proyecto = Number(Object.values(data)[1]);
      this.asignacion.id_empleado = Number(Object.values(data)[2]);
      this.fecha_asignado = this.fechasService.GetDateYMD(Object.values(data)[3].toString());
      this.fecha_desasignado = this.fechasService.GetDateYMD(Object.values(data)[4].toString());
      this.currtent_date = this.fecha_asignado;
    });
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
            sueldo: Number(Object.values(Object.values(data)[0])[5]),
            status: Number(Object.values(Object.values(data)[0])[6])
          };
          index++;
        }
      }
    });
  }

  ActualizarAsignacion() {
    if (this.asignacion.id_proyecto == 0 || this.asignacion.id_empleado == 0
      || this.fecha_asignado == "" || this.fecha_desasignado == ""
      || (new Date(this.fecha_asignado)) >= (new Date(this.fecha_desasignado))) {
      this.toastrService.error("Datos vacíos o inválidos."); return;
    }
    this.asignacion.fecha_asignado = new Date(this.fecha_asignado);
    this.asignacion.fecha_desasignado = new Date(this.fecha_desasignado);
    this.assignmentsService.UpdateAsignacion(this.id_asignacion, this.asignacion).subscribe(data => {
      if (data) {
        this.toastrService.success("Asignación actualizada con éxito.");
        this.router.navigate(['/asignaciones/index']);
      }
      else
        this.toastrService.error("No se pudo actualizar la asignación.");
    });
  }

  RegresarAsignaciones() {
    this.router.navigate(['/asignaciones/index']);
  }
}