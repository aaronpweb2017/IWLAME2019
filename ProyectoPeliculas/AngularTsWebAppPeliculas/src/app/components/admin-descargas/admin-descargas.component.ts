import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-admin-descargas',
  templateUrl: './admin-descargas.component.html',
  styles: []
})

export class AdminDescargasComponent implements OnInit {
  title: string;
  currentPageTiposArchivo: number;
  currentPageServidores: number;
  currentPageDescargas: number;
  currenDownloadIndex: number;
  
  constructor(private router: Router, private route: ActivatedRoute) {
    this.router.routeReuseStrategy.shouldReuseRoute = function () { return false; };
  }
  
  ngOnInit() {
    this.title = "Administración de descargas de películas";
    this.currentPageTiposArchivo = Number(this.route.snapshot.paramMap.get('currentPageTiposArchivo'));
    this.currentPageServidores = Number(this.route.snapshot.paramMap.get('currentPageServidores'));
    this.currentPageDescargas = Number(this.route.snapshot.paramMap.get('currentPageDescargas'));
    this.currenDownloadIndex = Number(this.route.snapshot.paramMap.get('currenDownloadIndex'));
  }
}