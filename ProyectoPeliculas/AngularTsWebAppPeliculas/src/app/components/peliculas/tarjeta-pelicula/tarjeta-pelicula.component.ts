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
  nuevapelicula: Pelicula;
  detallesTecnicos: VDetalleTecnico[];
  create: boolean;

  constructor(private peliculasService: PeliculasService, private vistasService:
    VistasService, private router: Router, private toastrService: ToastrService) { }

  ngOnInit() {
    this.create = false;
    this.nuevapelicula = { 
      id_pelicula: 0, nombre_pelicula: "", fecha_estreno: null,
      presupuesto: 0.00, recaudacion: 0.00, sinopsis: "",
      calificacion: 0.0, directores: "", generos: "",
      id_detalle: 0, rutaImagen: "",
    };
    this.vistasService.getVistaDetallesTecnicos().subscribe(detallesTecnicos => {
      this.detallesTecnicos = detallesTecnicos;
    });
  }

  setCreateFlag(flag: boolean) {
    this.create = flag;
  }

  crearPelicula() {
    this.peliculasService.crearPelicula(this.pelicula).subscribe(response => {
      if (response) {
        this.toastrService.success("Creación realizada con éxito.");
        this.router.navigate(['/adminDetalles']); return;
      }
      this.toastrService.error("Creación fallida...");
    },
     error => {
      //this.toastrService.error("Error "+error.error.status+" ("+error.error.title+")");
      this.toastrService.error(error.message);
     });
  }

  actualizarPelicula(pelicula: Pelicula) {
    this.peliculasService.actualizarPelicula(pelicula).subscribe(response => {
      if (response) {
        this.toastrService.success("Actualización realizada con éxito.");
        this.router.navigate(['/home']); return;
      }
      this.toastrService.error("Actualización fallida...");
    });
  }

  eliminarPelicula(id_pelicula: number) {
    this.peliculasService.eliminarPelicula(id_pelicula).subscribe(response => {
      if (response) {
        this.toastrService.success("Eliminación realizada con éxito.");
        this.router.navigate(['/adminDetalles']); return;
      }
      this.toastrService.error("Eliminación fallida...");
    });
  }
}