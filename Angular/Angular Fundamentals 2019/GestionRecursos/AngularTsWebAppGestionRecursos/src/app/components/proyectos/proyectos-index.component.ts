import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProyectosService } from 'src/app/services/proyectos-service';
import { Proyecto } from 'src/app/interfaces/proyecto';
import { FechasService } from 'src/app/services/fechas-service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'proyectos-index',
  templateUrl: './proyectos-index.component.html',
  styleUrls: ['./proyectos-component.css']
})

export class ProyectosIndexComponent implements OnInit {
  no_proyectos: number;
  proyectos: Proyecto[];
  id_proyecto: number;
  noPaginas: number;
  pageIndexes: number[];
  curernt_page: number = 1;

  constructor(private proyectosService: ProyectosService, private fechasService:
    FechasService, private toastrService: ToastrService, private router: Router) { }

  ngOnInit() {
    this.id_proyecto = 0; this.noPaginas = 0; this.pageIndexes = [];
    this.proyectosService.GetNoProyectos().subscribe(data => {
      this.no_proyectos = Number(data);
      this.noPaginas = Math.trunc((this.no_proyectos) / 10);
      if ((this.no_proyectos) % 10 != 0) {
        this.noPaginas = this.noPaginas + 1;
      }
      for (let i: number = 0; i < this.noPaginas; i++) {
        this.pageIndexes[i] = (i + 1);
      }
      this.MuestraPagina(this.curernt_page);
    });
  }

  CrearProyecto() {
    this.router.navigate(['/proyectos/create']);
  }

  EditarProyecto(id_proyecto: number) {
    this.router.navigate(['/proyectos/edit', id_proyecto]);
  }

  ActualizaIdProyecto(id_proyecto: number) {
    this.id_proyecto = id_proyecto;
  }

  BorrarProyecto(eventMessage: string) {
    console.log("Mensaje del Evento: " + eventMessage);
    this.proyectosService.DeleteProyecto(this.id_proyecto).subscribe(data => {
      if (data) {
        this.toastrService.success("Proyecto eliminado con éxito.");
        if (this.proyectos.length == 1 && this.pageIndexes.length > 1) {
          this.curernt_page = this.curernt_page - 1; this.ngOnInit();
        }
        else if (this.proyectos.length > 1) {
          this.MuestraPagina(this.curernt_page);
        }
        else {
          this.ngOnInit();
        }
      }
      else {
        this.toastrService.error("No se pudo eliminar el proyecto.");
      }
    });
  }

  //BorrarProyecto(id_proyecto: number) {
  //  this.router.navigate(['/proyectos/delete', id_proyecto]);
  //}

  MuestraPagina(no_pagina: number) {
    this.curernt_page = no_pagina;
    this.proyectosService.GetProyectosPaginacion(no_pagina).subscribe(data => {
      this.proyectos = Object.values(data);
    });
  }
}