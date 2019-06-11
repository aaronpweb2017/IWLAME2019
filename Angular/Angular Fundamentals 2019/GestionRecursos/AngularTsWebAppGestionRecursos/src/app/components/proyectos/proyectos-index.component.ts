import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProyectosService } from 'src/app/services/proyectos-service';
import { Proyecto } from 'src/app/interfaces/proyecto';

@Component({
  selector: 'proyectos-index',
  templateUrl: './proyectos-index.component.html',
  styleUrls: ['./proyectos-component.css']
})

export class ProyectosIndexComponent implements OnInit {
  no_proyectos: number;
  proyectos: Proyecto[];
  noPaginas: number;
  pageIndexes: number[];

  constructor(private proyectosService: ProyectosService, private router: Router) { }

  ngOnInit() {
    this.noPaginas = 0; this.pageIndexes = [];
    this.proyectosService.GetNoProyectos().subscribe(data => {
      this.no_proyectos = Number(Object.values(data));
      this.noPaginas = Math.trunc((this.no_proyectos) / 10);
      if ((this.no_proyectos) % 10 != 0) {
        this.noPaginas = this.noPaginas + 1;
      }
      for (let i: number = 0; i < this.noPaginas; i++) {
        this.pageIndexes[i] = (i + 1);
      }
      this.MuestraPagina(1);
    });
  }

  CrearProyecto() {
    this.router.navigate(['/proyectos/create']);
  }

  EditarProyecto(id_proyecto: number) {
    this.router.navigate(['/proyectos/edit', id_proyecto]);
  }

  BorrarProyecto(id_proyecto: number) {
    this.router.navigate(['/proyectos/delete', id_proyecto]);
  }

  GetDateDMY(stringDate: String): string {
    return this.proyectosService.GetDateDMY(stringDate);
  }

  MuestraPagina(no_pagina: number) {
    this.proyectosService.GetProyectosPaginacion(no_pagina).subscribe(data => {
      this.proyectos = Object.values(data);
    });
  }
}