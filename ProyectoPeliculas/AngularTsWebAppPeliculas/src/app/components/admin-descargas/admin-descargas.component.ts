import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-descargas',
  templateUrl: './admin-descargas.component.html',
  styles: []
})

export class AdminDescargasComponent implements OnInit {
  title: string;
  
  constructor(private router: Router) {
    this.router.routeReuseStrategy.shouldReuseRoute = function () { return false; };
  }
  
  ngOnInit() {
    this.title = "Administración de descargas de películas"
  }
}