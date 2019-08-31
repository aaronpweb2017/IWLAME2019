import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  logged: boolean;
  noPeliculas: number[];

  constructor() { }

  ngOnInit() {
    this.noPeliculas = [];
    for(let i:number=0; i<5; i++)
    this.noPeliculas[i] = i+1;
    console.log(this.noPeliculas)
  }
}