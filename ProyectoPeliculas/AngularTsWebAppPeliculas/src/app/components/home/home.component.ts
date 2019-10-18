import { Component, OnInit } from '@angular/core';
import { Pelicula } from 'src/app/interfaces/pelicula';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PeliculasService } from 'src/app/services/peliculas.service';
import { VistasService } from 'src/app/services/vistas.service';
import { VDetalleTecnico } from 'src/app/interfaces/views/v-detalle-tecnico';
import { VDescarga } from 'src/app/interfaces/views/v-descarga';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  busqueda: string;
  ordenamiento: string;
  peliculas: Pelicula[];
  categorias: string[];
  detallesTecnicos: VDetalleTecnico[];
  constructor(private peliculasService: PeliculasService, private vistasService: VistasService,
    private router: Router, private route: ActivatedRoute, private toastrService: ToastrService) {
    this.router.routeReuseStrategy.shouldReuseRoute = function () { return false; };
  }

  ngOnInit() {
    this.peliculas = []; this.categorias = []; this.categorias.push("");
    this.ordenamiento = this.route.snapshot.paramMap.get('ordenamiento');
    this.busqueda = this.route.snapshot.paramMap.get('busqueda');

    this.vistasService.getVistaDetallesTecnicos().subscribe(
      response0 => {
        if (response0[0]) {
          this.detallesTecnicos = response0[0];
          this.peliculasService.getPeliculas().subscribe(
            response1 => {
              if (response1[0]) {
                if (this.busqueda != null && this.busqueda != "") {
                  for (let i: number = 0; i < response1[0].length; i++) {
                    let detalleTecnico: VDetalleTecnico = this.detallesTecnicos.filter(
                      dt => dt.id_detalle == response1[0][i].id_detalle)[0];
                    let nombre_formato: string = detalleTecnico.nombre_formato;
                    let nombre_tipo_resolucion: string = detalleTecnico.nombre_tipo_resolucion;
                    let valor_resolucion: string = detalleTecnico.valor_resolucion;
                    let valor_relacion_aspecto: string = detalleTecnico.valor_relacion_aspecto;
                    this.vistasService.getVistaDescargasPelicula(response1[0][i].id_pelicula).subscribe(
                      response2 => {
                        if (response2[0] != null) {
                          let descargas: VDescarga[] = response2[0];
                          for (let j: number = 0; j < descargas.length; j++) {
                            let password_descarga: string = descargas[j].password_descarga;
                            let nombre_tipo_archivo: string = descargas[j].nombre_tipo_archivo;
                            let nombre_servidor: string = descargas[j].nombre_servidor;
                            if (response1[0][i].nombre_pelicula.toLowerCase().includes(this.busqueda.toLowerCase())
                              || response1[0][i].sinopsis.toLowerCase().includes(this.busqueda.toLowerCase())
                              || response1[0][i].directores.toLowerCase().includes(this.busqueda.toLowerCase())
                              || response1[0][i].generos.toLowerCase().includes(this.busqueda.toLowerCase())
                              || nombre_formato.toLowerCase().includes(this.busqueda.toLowerCase())
                              || nombre_tipo_resolucion.toLowerCase().includes(this.busqueda.toLowerCase())
                              || valor_resolucion.toLowerCase().includes(this.busqueda.toLowerCase())
                              || valor_relacion_aspecto.toLowerCase().includes(this.busqueda.toLowerCase())
                              || password_descarga.toLowerCase().includes(this.busqueda.toLowerCase())
                              || nombre_tipo_archivo.toLowerCase().includes(this.busqueda.toLowerCase())
                              || nombre_servidor.toLowerCase().includes(this.busqueda.toLowerCase())) {
                              if (!this.peliculas.includes(response1[0][i]))
                                this.peliculas.push(response1[0][i])
                            }
                          }
                        }
                        else {
                          this.toastrService.error(response2[1]);
                        }
                      }, error => {
                        this.toastrService.error(error.message);
                      });
                  }
                }
                else
                  this.peliculas = response1[0];
                for (let i: number = 0; i < this.peliculas.length; i++) {
                  if (!this.categorias.includes(this.peliculas[i].generos))
                    this.categorias.push(this.peliculas[i].generos);
                }
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
                return;
              }
              this.toastrService.error(response1[1]);
            }, error => {
              this.toastrService.error(error.message);
            });
          return;
        }
        this.toastrService.error(response0[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }
}