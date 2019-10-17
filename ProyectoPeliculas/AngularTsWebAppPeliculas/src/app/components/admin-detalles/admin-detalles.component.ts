import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-admin-detalles',
  templateUrl: './admin-detalles.component.html',
  styles: []
})

export class AdminDetallesComponent implements OnInit {
  title: string;
  currentPageFormato: number;
  currentPageTiposResolucion: number;
  currentPageValoresResolucion: number;
  currentPageRelacionesAspecto: number;
  currentPageResoluciones: number;
  currentPageDetallesTecnicos: number;

  constructor(private router: Router, private route: ActivatedRoute) {
    this.router.routeReuseStrategy.shouldReuseRoute = function () { return false; };
  }
  
  ngOnInit() {
    this.title = "Administración de detalles técnicos de películas";
    this.currentPageFormato = Number(this.route.snapshot.paramMap.get('currentPageFormato'));
    this.currentPageTiposResolucion = Number(this.route.snapshot.paramMap.get('currentPageTiposResolucion'));
    this.currentPageValoresResolucion = Number(this.route.snapshot.paramMap.get('currentPageValoresResolucion'));
    this.currentPageRelacionesAspecto = Number(this.route.snapshot.paramMap.get('currentPageRelacionesAspecto'));
    this.currentPageResoluciones = Number(this.route.snapshot.paramMap.get('currentPageResoluciones'));
    this.currentPageDetallesTecnicos = Number(this.route.snapshot.paramMap.get('currentPageDetallesTecnicos'));
  }
}