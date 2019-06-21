import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { Proyecto } from 'src/app/interfaces/proyecto';
import { ProyectosService } from 'src/app/services/proyectos-service';
import { AsignacionesService } from 'src/app/services/asignaciones-service';
import { FechasService } from 'src/app/services/fechas-service';
import { Asignacion } from 'src/app/interfaces/asignacion';


@Component({
  selector: 'proyectos-edit',
  templateUrl: './proyectos-edit.component.html',
  styleUrls: ['./proyectos-component.css']
})

export class ProyectosEditComponent implements OnInit {
  id_proyecto: number;
  proyecto: Proyecto;
  currtent_date: string;
  old_fecha_inicio: string;
  fecha_inicio: string;
  fecha_fin: string;
  asignado: boolean;
  terminado: boolean;

  constructor(private proyectosService: ProyectosService, private asignacionesService:
    AsignacionesService, private fechasService: FechasService, private toastrService:
      ToastrService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.proyecto = {
      id_proyecto: 0, nombre: "",
      descripcion: "", fecha_inicio: new Date(),
      fecha_fin: new Date(), status: 0
    };
    this.id_proyecto = this.route.snapshot.params['id_proyecto'];
    this.proyectosService.GetProyecto(this.id_proyecto).subscribe(data => {
      this.proyecto = data as Proyecto;
      this.fecha_inicio = this.fechasService.GetDateYMD(this.proyecto.fecha_inicio);
      this.fecha_fin = this.fechasService.GetDateYMD(this.proyecto.fecha_fin);
      this.currtent_date = this.fechasService.GetCurrentDate();
      this.old_fecha_inicio = this.fecha_inicio;
      this.asignado = false; this.terminado = false;
      this.asignacionesService.GetAsignaciones().subscribe(data => {
        let asignaciones: Asignacion[] = Object.values(data);
        let asignacion: Asignacion = asignaciones.find(assignment =>
          assignment.id_proyecto === this.proyecto.id_proyecto);
        if(asignacion!=null) this.asignado = true;
        if (new Date(this.currtent_date) >= new Date(this.fecha_fin)) {
          this.terminado = true;
        }
      });
    });
  }

  ActualizarProyecto(eventMessage: string) {
    console.log("Mensaje del Evento: " + eventMessage);
    if (this.proyecto.nombre == "" || this.proyecto.descripcion == ""
      || this.proyecto.status < 0 || this.fecha_inicio == "" || this.fecha_fin == "") {
      this.toastrService.error("Datos vacíos o inválidos."); return;
    }
    if (new Date(this.fecha_inicio) < new Date(this.old_fecha_inicio)) {
      this.toastrService.error("Inconsistencia en fecha de inicio."); return;
    }
    if ((new Date(this.fecha_fin) > new Date("2020-12-31"))
      || (new Date(this.fecha_fin) <= new Date(this.currtent_date) && this.proyecto.status != 2)) {
      this.toastrService.error("Inconsistencia en fecha del final."); return;
    }
    this.proyecto.fecha_inicio = new Date(this.fecha_inicio);
    this.proyecto.fecha_fin = new Date(this.fecha_fin);
    this.proyectosService.UpdateProyecto(this.id_proyecto, this.proyecto).subscribe(data => {
      if (Boolean(data)) {
        this.toastrService.success("Proyecto actualizado con éxito.");
        this.router.navigate(['/proyectos/index']); return;
      }
      this.toastrService.error("No se pudo actualizar el proyecto.");
    });
  }

  RegresarProyectos() {
    this.router.navigate(['/proyectos/index']);
  }
}