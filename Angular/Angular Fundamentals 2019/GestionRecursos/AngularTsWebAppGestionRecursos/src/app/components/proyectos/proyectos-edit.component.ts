import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { Proyecto } from 'src/app/interfaces/proyecto';
import { ProyectosService } from 'src/app/services/proyectos-service';
import { FechasService } from 'src/app/services/fechas-service';

@Component({
  selector: 'proyectos-edit',
  templateUrl: './proyectos-edit.component.html',
  styleUrls: ['./proyectos-component.css']
})

export class ProyectosEditComponent implements OnInit {
  id_proyecto: number;
  proyecto: Proyecto;
  currtent_date: string;
  fecha_inicio: string;
  fecha_fin: string;

  constructor(private proyectosService: ProyectosService, private fechasService: FechasService,
    private toastrService: ToastrService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.proyecto = {
      id_proyecto: 0, nombre: "",
      descripcion: "", fecha_inicio: new Date(),
      fecha_fin: new Date(), status: 0
    };
    this.id_proyecto = this.route.snapshot.params['id_proyecto'];
    this.proyectosService.GetProyecto(this.id_proyecto).subscribe(data => {
      this.proyecto.id_proyecto = Number(Object.values(data)[0]);
      this.proyecto.nombre = (Object.values(data)[1]).toString();
      this.proyecto.descripcion = (Object.values(data)[2]).toString();
      this.fecha_inicio = this.fechasService.GetDateYMD(Object.values(data)[3].toString());
      this.fecha_fin = this.fechasService.GetDateYMD(Object.values(data)[4].toString());
      this.proyecto.status = Number(Object.values(data)[5]);
      this.currtent_date = this.fecha_inicio;
    });
  }

  ActualizarProyecto(eventMessage: string) {
    console.log("Mensaje del Evento: " + eventMessage);
    if (this.proyecto.nombre == "" || this.proyecto.descripcion == ""
      || this.proyecto.fecha_inicio == null || this.proyecto.fecha_fin == null
      || (new Date(this.fecha_inicio)) >= (new Date(this.fecha_fin))) {
      this.toastrService.error("Datos vacíos o inválidos."); return;
    }
    this.proyecto.fecha_inicio = new Date(this.fecha_inicio);
    this.proyecto.fecha_fin = new Date(this.fecha_fin);
    this.proyectosService.UpdateProyecto(this.id_proyecto, this.proyecto).subscribe(data => {
      if (Object.values(data)) {
        this.toastrService.success("Proyecto actualizado con éxito.");
        this.router.navigate(['/proyectos/index']);
      }
      else
        this.toastrService.error("No se pudo actualizar el proyecto.");
    });
  }

  RegresarProyectos() {
    this.router.navigate(['/proyectos/index']);
  }
}