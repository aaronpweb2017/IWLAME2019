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
  @Input() categorias: string[];
  directores: string[];
  generos: string[];
  genero: string;
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
      id_detalle: 0,
      urlImagen: "",
    };
    this.genero = "";
  }

  isAdmin() {
    return JSON.parse(localStorage.getItem('admin'));
  }

  setCreateFlag(flag: boolean) {
    this.create = flag;
  }

  crearPelicula() {
    this.nuevapelicula.presupuesto = this.nuevapelicula.presupuesto * 1000000;
    this.nuevapelicula.recaudacion = this.nuevapelicula.recaudacion * 1000000;
    if (this.genero != "") { this.nuevapelicula.generos = this.genero; }
    this.peliculasService.crearPelicula(this.nuevapelicula).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Creación realizada con éxito.");
          this.router.navigate(['/home']); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  actualizarPelicula(pelicula: Pelicula) {
    this.peliculasService.actualizarPelicula(pelicula).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Actualización realizada con éxito.");
          this.router.navigate(['/home']); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  eliminarPelicula(pelicula: Pelicula) {
    this.peliculasService.eliminarPelicula(pelicula.id_pelicula).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Eliminación realizada con éxito.");
          this.router.navigate(['/home']); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  verDetallesPelicula() {
    this.router.navigate(['/detallesPelicula', { id_pelicula: this.pelicula.id_pelicula }]);
  }
}