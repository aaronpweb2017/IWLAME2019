import { Component, OnInit, Input } from '@angular/core';
import { PeliculasService } from 'src/app/services/peliculas.service';
import { Pelicula } from 'src/app/interfaces/pelicula';
import { VDetalleTecnico } from 'src/app/interfaces/views/v-detalle-tecnico';
import { VistasService } from 'src/app/services/vistas.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tarjeta-pelicula',
  templateUrl: './tarjeta-pelicula.component.html',
  styleUrls: ['./tarjeta-pelicula.component.css']
})
export class TarjetaPeliculaComponent implements OnInit {
  @Input() pelicula: Pelicula;
  @Input() detallesTecnicos: VDetalleTecnico[];
  directores: string[]; generos: string[];
  nuevapelicula: Pelicula;
  create: boolean;

  constructor(private peliculasService: PeliculasService, private vistasService:
    VistasService, private router: Router, private toastrService: ToastrService) {
    this.router.routeReuseStrategy.shouldReuseRoute = function () { return false; };
  }

  ngOnInit() {
    if (this.pelicula) {
      this.directores = this.pelicula.directores.split(", ");
      this.generos = this.pelicula.generos.split(", ");
    }
    this.create = false;
    this.nuevapelicula = {
      id_pelicula: 0,
      nombre_pelicula: "",
      fecha_estreno: null,
      presupuesto: 0.00,
      recaudacion: 0.00,
      sinopsis: "",
      calificacion: 0.0,
      directores: "",
      generos: "",
      idiomas: "",
      productoras: "",
      actores: "",
      pais: "",
      audios: "",
      subtitulos: "",
      peso: 0,
      id_detalle: 0,
      rutaImagen: "",
    };
  }

  setCreateFlag(flag: boolean) {
    this.create = flag;
  }

  crearPelicula() {
    this.peliculasService.crearPelicula(this.nuevapelicula).subscribe(
      response => {
        if (response) {
          this.toastrService.success("Creación realizada con éxito.");
          this.router.navigate(['/home']); return;
        }
        //this.toastrService.error("Creación fallida...");
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  actualizarPelicula(pelicula: Pelicula) {
    this.peliculasService.actualizarPelicula(pelicula).subscribe(
      response => {
        if (response) {
          this.toastrService.success("Actualización realizada con éxito.");
          this.router.navigate(['/home']); return;
        }
        //this.toastrService.error("Actualización fallida...");
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  eliminarPelicula(pelicula: Pelicula) {
    this.peliculasService.eliminarPelicula(pelicula.id_pelicula).subscribe(
      response => {
        if (response) {
          this.toastrService.success("Eliminación realizada con éxito.");
          this.router.navigate(['/home']); return;
        }
        //this.toastrService.error("Eliminación fallida...");
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  verDetallesPelicula() {
    this.router.navigate(['/detallesPelicula', {
      id_pelicula: this.pelicula.id_pelicula,
      nombre_pelicula: this.pelicula.nombre_pelicula,
      fecha_estreno: this.pelicula.fecha_estreno,
      presupuesto: this.pelicula.presupuesto,
      recaudacion: this.pelicula.recaudacion,
      sinopsis: this.pelicula.sinopsis,
      calificacion: this.pelicula.calificacion,
      directores: this.pelicula.directores,
      generos: this.pelicula.generos,
      idiomas: this.pelicula.idiomas,
      productoras: this.pelicula.productoras,
      actores: this.pelicula.actores,
      pais: this.pelicula.pais,
      audios: this.pelicula.audios,
      subtitulos: this.pelicula.subtitulos,
      peso: this.pelicula.peso,
      id_detalle: this.pelicula.id_detalle,
      rutaImagen: this.pelicula.rutaImagen
    }]);
  }
}