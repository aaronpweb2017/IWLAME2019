import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Proyecto } from 'src/app/interfaces/proyecto';
import { ProyectosService } from 'src/app/services/proyectos-service';

@Component({
  selector: 'proyectos-create',
  templateUrl: './proyectos-create.component.html',
  styleUrls: ['./proyectos-component.css']
})

export class ProyectosCreateComponent implements OnInit {
  proyecto: Proyecto
  currtent_date: string;
  fecha_inicio: string;
  fecha_fin: string;

  constructor(private proyectosService: ProyectosService, private toastrService: ToastrService, private router: Router) { }

  ngOnInit() {
    this.proyecto = {
      id_proyecto: 0, nombre: "",
      descripcion: "", fecha_inicio: new Date(),
      fecha_fin: new Date(), status: 0
    };
    let day: string = new Date().getDate().toString();
    let month: string = (new Date().getMonth() + 1).toString();
    let year: string = new Date().getFullYear().toString();
    if (month.length < 10) month = "0" + month;
    this.currtent_date = year + "-" + month + "-" + day;
    this.fecha_inicio = this.currtent_date;
    this.fecha_fin = this.currtent_date;
  }

  CrearProyecto() {
    if (this.proyecto.nombre == "" || this.proyecto.descripcion == "" || this.proyecto.status < 0
      || this.fecha_inicio == "" || this.fecha_fin == ""
      || (new Date(this.fecha_inicio)) >= (new Date(this.fecha_fin))) {
      this.toastrService.error("Datos vacíos o inválidos."); return;
    }
    this.proyecto.fecha_inicio = new Date(this.fecha_inicio);
    this.proyecto.fecha_fin = new Date(this.fecha_fin);
    this.proyectosService.PostProyecto(this.proyecto).subscribe(data => {
      if (Object.values(data)) {
        this.toastrService.success("Proyecto creado con éxito.");
        this.router.navigate(['/proyectos/index']);
      }
      else
        this.toastrService.error("No se pudo crear el proyecto.");
    });
  }

  RegresarProyectos() {
    this.router.navigate(['/proyectos/index']);
  }
}