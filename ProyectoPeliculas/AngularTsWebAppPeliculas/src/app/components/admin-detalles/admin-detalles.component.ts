import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-detalles',
  templateUrl: './admin-detalles.component.html',
  styles: []
})

export class AdminDetallesComponent implements OnInit {
  title: string;
  
  constructor(private router: Router) {
    this.router.routeReuseStrategy.shouldReuseRoute = function () { return false; };
  }
  
  ngOnInit() {
    this.title = "Administración de detalles técnicos de películas"
  }
}