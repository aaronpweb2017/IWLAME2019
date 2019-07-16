import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HeoresService } from 'src/app/services/heroes.service';
import { Heroe } from 'src/app/interfaces/heroe';

@Component({
  selector: 'app-heroe',
  templateUrl: './heroe.component.html',
  styles: []
})
export class HeroeComponent implements OnInit {
  id: number;
  heroe: Heroe;

  constructor(private heoresService: HeoresService,
    private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    this.heroe = this.heoresService.getHeroe(this.id);
  }
}