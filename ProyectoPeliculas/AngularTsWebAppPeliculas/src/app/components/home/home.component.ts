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
  busqueda: string;
  ordenamiento: string;
  peliculas: Pelicula[];
  detallesTecnicos: VDetalleTecnico[];
  constructor(private peliculasService: PeliculasService, private vistasService: VistasService,
    private router: Router, private route: ActivatedRoute, private toastrService: ToastrService) {
    this.router.routeReuseStrategy.shouldReuseRoute = function () { return false; };
  }

  ngOnInit() {
    this.peliculas = [];
    this.ordenamiento = this.route.snapshot.paramMap.get('ordenamiento');
    this.busqueda = this.route.snapshot.paramMap.get('busqueda');
    this.peliculasService.getPeliculas().subscribe(
      response => {
        if (response[0]) {
          if (this.busqueda != null && this.busqueda != "") {
            for (let i: number = 0; i < response[0].length; i++) {
              if (response[0][i].nombre_pelicula.includes(this.busqueda)
                || response[0][i].sinopsis.includes(this.busqueda)
                || response[0][i].directores.includes(this.busqueda)
                || response[0][i].generos.includes(this.busqueda))
                this.peliculas.push(response[0][i])
            }
          }
          else
            this.peliculas = response[0];
          if (this.ordenamiento != null) {
            if (this.ordenamiento.includes("nombre")) {
              this.peliculas.sort((currentMovie, nextMovie): number => {
                if (currentMovie.nombre_pelicula > nextMovie.nombre_pelicula) return -1;
                if (currentMovie.nombre_pelicula < nextMovie.nombre_pelicula) return 1;
              });
            }
            else if (this.ordenamiento.includes("fecha")) {
              this.peliculas.sort((currentMovie, nextMovie): number => {
                if (currentMovie.fecha_estreno > nextMovie.fecha_estreno) return -1;
                if (currentMovie.fecha_estreno < nextMovie.fecha_estreno) return 1;
              });
            }
            else if (this.ordenamiento.includes("presupuesto")) {
              this.peliculas.sort((currentMovie, nextMovie): number => {
                if (currentMovie.presupuesto > nextMovie.presupuesto) return -1;
                if (currentMovie.presupuesto < nextMovie.presupuesto) return 1;
              });
            }
            else if (this.ordenamiento.includes("recaudacion")) {
              this.peliculas.sort((currentMovie, nextMovie): number => {
                if (currentMovie.recaudacion > nextMovie.recaudacion) return -1;
                if (currentMovie.recaudacion < nextMovie.recaudacion) return 1;
              });
            }
            else if (this.ordenamiento.includes("calificacion")) {
              this.peliculas.sort((currentMovie, nextMovie): number => {
                if (currentMovie.calificacion > nextMovie.calificacion) return -1;
                if (currentMovie.calificacion < nextMovie.calificacion) return 1;
              });
            }
            else if (this.ordenamiento.includes("directores")) {
              this.peliculas.sort((currentMovie, nextMovie): number => {
                if (currentMovie.directores > nextMovie.directores) return -1;
                if (currentMovie.directores < nextMovie.directores) return 1;
              });
            }
            else if (this.ordenamiento.includes("generos")) {
              this.peliculas.sort((currentMovie, nextMovie): number => {
                if (currentMovie.generos > nextMovie.generos) return -1;
                if (currentMovie.generos < nextMovie.generos) return 1;
              });
            }
          }
          this.peliculas.push(null);
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