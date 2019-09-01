import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  menuFlags: boolean[];
  noPeliculas: number[];
  constructor() { }

  ngOnInit() {
    this.menuFlags = []; this.menuFlags[0] = true;
    for (let i: number = 1; i < this.menuFlags.length; i++) {
      this.menuFlags[i] = false;
    }
    this.noPeliculas = [];
    for (let i: number = 0; i < 4; i++)
      this.noPeliculas[i] = i + 1;
  }

  setFlagSubMenu(index: number) {
    if (!this.menuFlags[index]) {
      this.menuFlags[index] = true;
      for (let i: number = 0; i < this.menuFlags.length; i++) {
        if (i != index) {
          this.menuFlags[i] = false;
        }
      }
    }
  }
}