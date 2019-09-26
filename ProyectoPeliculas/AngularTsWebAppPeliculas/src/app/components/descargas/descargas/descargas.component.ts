import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { VistasService } from 'src/app/services/vistas.service';
import { DescargasService } from 'src/app/services/descargas.service';
import { PeliculasService } from 'src/app/services/peliculas.service';
import { Descarga } from 'src/app/interfaces/descargas/descarga';
import { VDescarga } from 'src/app/interfaces/views/v-descarga';
import { TipoArchivo } from 'src/app/interfaces/descargas/tipo-archivo';
import { Servidor } from 'src/app/interfaces/descargas/servidor';
import { Pelicula } from 'src/app/interfaces/pelicula';
import { Enlace } from 'src/app/interfaces/descargas/enlace';

@Component({
  selector: 'app-descargas',
  templateUrl: './descargas.component.html',
  styleUrls: []
})
export class DescargasComponent implements OnInit {
  totalPages: number;
  currentPage: number;
  currentItemsPerPage: number;
  paginationConfig: any;
  descargas: VDescarga[];

  tiposArchivo: TipoArchivo[];
  servidores: Servidor[];
  peliculas: Pelicula[];
  nuevaDescarga: Descarga;
  nuevoEnlace: Enlace;
  mostrarEnlaces: boolean[];
  crearEnlaces: boolean[];
  create: boolean;

  constructor(private vistasService: VistasService, private descargasService: DescargasService,
    private peliculasService: PeliculasService, private router: Router, private route:
      ActivatedRoute, private toastrService: ToastrService) {
    this.totalPages = 0; this.currentPage = 1; this.currentItemsPerPage = 0;
    this.paginationConfig = { itemsPerPage: 0, currentPage: 0, totalItems: 0 };
  }

  ngOnInit() {
    this.descargas = []; this.tiposArchivo = []; this.servidores = [];
    this.peliculas = [];
    this.mostrarEnlaces = []; this.crearEnlaces = [];
    this.create = false;
    this.nuevaDescarga = {
      id_descarga: 0, password_descarga: "",
      id_tipo_archivo: 0, id_servidor: 0, id_pelicula: 0,
    };
    this.nuevoEnlace = {
      id_enlace: 0, valor_enlace: "",
      status_enlace: 0, id_descarga: 0
    };
    this.vistasService.getVistaDescargas().subscribe(descargas => {
      this.descargas = descargas;
      for (let i: number = 0; i < this.descargas.length; i++) {
        let id_descarga: number = this.descargas[i].id_descarga;
        this.descargasService.getEnlacesDescarga(id_descarga).subscribe(enlaces => {
          this.descargas[i].enlaces = [];
          this.descargas[i].enlaces = enlaces;
          this.descargas[i].enlaces.push(null);
        });
      }
      this.descargas.push(null);
      this.mostrarEnlaces = new Array(this.descargas.length).fill(false);
      this.crearEnlaces = new Array(this.descargas.length).fill(false);
      this.paginationConfig = {
        itemsPerPage: 5,
        currentPage: this.currentPage,
        totalItems: this.descargas.length
      };
      this.totalPages = Math.trunc(this.descargas.length / this.paginationConfig.itemsPerPage);
      if (this.descargas.length % this.paginationConfig.itemsPerPage != 0) this.totalPages += 1;
      this.currentItemsPerPage = this.descargas.slice(5 * (this.currentPage - 1), 5 * (this.currentPage)).length;
      this.descargasService.getTiposArchivo().subscribe(tiposArchivo => { this.tiposArchivo = tiposArchivo; });
      this.descargasService.getServidores().subscribe(servidores => { this.servidores = servidores; });
      this.peliculasService.getPeliculas().subscribe(peliculas => { this.peliculas = peliculas; });
    });
  }

  setCreateFlag() {
    if (this.create) {
      this.create = false; return;
    }
    this.create = true;
  }

  setCreateLinkFlag(index: number, flag: boolean) {
    this.crearEnlaces[index] = flag;;
  }

  crearDescarga() {
    this.descargasService.crearDescarga(this.nuevaDescarga).subscribe(response => {
      if (response) {
        this.toastrService.success("Creación realizada con éxito.");
        this.router.navigate(['/adminDescargas']); return;
      }
      this.toastrService.error("Creación fallida...");
    });
  }

  actualizarDescarga(descarga: Descarga) {
    this.descargasService.actualizarDescarga(descarga).subscribe(response => {
      if (response) {
        this.toastrService.success("Actualización realizada con éxito.");
        this.router.navigate(['/adminDescargas']); return;
      }
      this.toastrService.error("Actualización fallida...");
    });
  }

  eliminarDescarga(id_descarga: number) {
    this.descargasService.eliminarDescarga(id_descarga).subscribe(response => {
      if (response) {
        this.toastrService.success("Eliminación realizada con éxito.");
        this.router.navigate(['/adminDescargas']); return;
      }
      this.toastrService.error("Eliminación fallida...");
    });
  }

  crearEnlace(id_descarga: number) {
    this.nuevoEnlace.id_descarga = id_descarga;
    this.descargasService.crearEnlace(this.nuevoEnlace).subscribe(response => {
      if (response) {
        this.toastrService.success("Creación realizada con éxito.");
        this.router.navigate(['/adminDescargas']); return;
      }
      this.toastrService.error("Creación fallida...");
    });
  }

  actualizarEnlace(enlace: Enlace) {
    this.descargasService.actualizarEnlace(enlace).subscribe(response => {
      if (response) {
        this.toastrService.success("Actualización realizada con éxito.");
        this.router.navigate(['/adminDescargas']); return;
      }
      this.toastrService.error("Actualización fallida...");
    });
  }

  eliminarEnlace(id_enlace: number) {
    this.descargasService.eliminarEnlace(id_enlace).subscribe(response => {
      if (response) {
        this.toastrService.success("Eliminación realizada con éxito.");
        this.router.navigate(['/adminDescargas']); return;
      }
      this.toastrService.error("Eliminación fallida...");
    });
  }

  pageChanged(currentPage: number) {
    this.currentPage = currentPage;
    this.paginationConfig.currentPage = this.currentPage;
    this.currentItemsPerPage = this.descargas.slice(5 * (this.currentPage - 1), 5 * (this.currentPage)).length;
  }
}