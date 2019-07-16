import { Component, OnInit } from '@angular/core';
import { HeoresService } from 'src/app/services/heroes.service';
import { Heroe } from 'src/app/interfaces/heroe';
import { Router } from '@angular/router';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css']
})
export class HeroesComponent implements OnInit {
  heroes: Heroe[];
  constructor(private heoresService: HeoresService, private router: Router) { }

  ngOnInit() {
    this.heroes = this.heoresService.getHeroes();
  }

  redirectHeroe(id: number) {
    this.router.navigate(['/heroe', id]);
  }
}