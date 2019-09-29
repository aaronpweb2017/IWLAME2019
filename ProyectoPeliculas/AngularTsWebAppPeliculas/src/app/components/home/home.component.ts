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
  currentPage: number;
  paginationConfig: any;
  peliculas: Pelicula[];
  detallesTecnicos: VDetalleTecnico[];

  constructor(private peliculasService: PeliculasService, private vistasService: VistasService,
    private router: Router, private route: ActivatedRoute, private toastrService: ToastrService) {
    this.currentPage = 1;
    this.paginationConfig = { itemsPerPage: 0, currentPage: 0, totalItems: 0 };
  }

  ngOnInit() {
    this.peliculasService.getPeliculas().subscribe(
      peliculas => {
        this.peliculas = peliculas;
        this.peliculas = peliculas; this.peliculas.push(null);
        this.paginationConfig = {
          itemsPerPage: 5,
          currentPage: this.currentPage,
          totalItems: this.peliculas.length - 1
        };
        for (let i: number = 0; i < this.peliculas.length - 1; i++) {
          this.peliculas[i].rutaImagen = "assets/img" + this.peliculas[i].nombre_pelicula + ".jpg";
        }
        this.vistasService.getVistaDetallesTecnicos().subscribe(
          detallesTecnicos => {
            this.detallesTecnicos = detallesTecnicos;
          }, error => {
            this.toastrService.error(error.message);
          });
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  pageChanged(currentPage: number) {
    this.currentPage = currentPage;
    this.paginationConfig.currentPage = this.currentPage;
  }
}