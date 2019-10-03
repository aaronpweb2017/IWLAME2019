import { Component, OnInit } from '@angular/core';
import { Pelicula } from 'src/app/interfaces/pelicula';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PeliculasService } from 'src/app/services/peliculas.service';
import { VistasService } from 'src/app/services/vistas.service';
import { VDetalleTecnico } from 'src/app/interfaces/views/v-detalle-tecnico';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  ordenamiento;
  peliculas: Pelicula[];
  detallesTecnicos: VDetalleTecnico[];
  constructor(private peliculasService: PeliculasService, private vistasService: VistasService,
    private router: Router, private route: ActivatedRoute, private toastrService: ToastrService) {
    this.router.routeReuseStrategy.shouldReuseRoute = function () { return false; };
  }

  ngOnInit() {
    this.ordenamiento = this.route.snapshot.paramMap.get('ordenamiento');
    this.peliculasService.getPeliculas().subscribe(
      response => {
        if (response[0]) {
          this.peliculas = response[0];
          if (this.ordenamiento != null && this.ordenamiento.includes("nombre")) {
            this.peliculas.sort((currentMovie, nextMovie): number => {
              if (currentMovie.nombre_pelicula < nextMovie.nombre_pelicula) return -1;
              if (currentMovie.nombre_pelicula > nextMovie.nombre_pelicula) return 1;
              return 0;
            });
          }
          this.peliculas.push(null);
          for (let i: number = 0; i < this.peliculas.length - 1; i++)
            this.peliculas[i].rutaImagen = "assets/img" + this.peliculas[i].nombre_pelicula + ".jpg";
          this.vistasService.getVistaDetallesTecnicos().subscribe(
            response => {
              if (response[0])
                this.detallesTecnicos = response[0];
            }, error => {
              this.toastrService.error(error.message);
            });
          return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }
}