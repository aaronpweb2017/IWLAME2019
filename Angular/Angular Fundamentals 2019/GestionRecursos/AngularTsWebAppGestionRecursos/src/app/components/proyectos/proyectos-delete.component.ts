import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { Proyecto } from 'src/app/interfaces/proyecto';
import { ProyectosService } from 'src/app/services/proyectos-service';
import { FechasService } from 'src/app/services/fechas-service';

@Component({
  selector: 'proyectos-delete',
  templateUrl: './proyectos-delete.component.html',
  styleUrls: ['./proyectos-component.css']
})

export class ProyectosDeleteComponent implements OnInit {
  id_proyecto: number;
  proyecto: Proyecto;
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
    });
  }

  BorrarProyecto() {
    this.proyectosService.DeleteProyecto(this.id_proyecto).subscribe(data => {
      if (data) {
        this.toastrService.success("Proyecto eliminado con éxito.");
        this.router.navigate(['/proyectos/index']);
      }
      else
        this.toastrService.error("No se pudo eliminar el proyecto.");
    });
  }

  RegresarProyectos() {
    this.router.navigate(['/proyectos/index']);
  }
}