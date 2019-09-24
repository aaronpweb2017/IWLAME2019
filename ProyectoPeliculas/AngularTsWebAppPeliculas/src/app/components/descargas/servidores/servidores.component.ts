import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Servidor } from 'src/app/interfaces/descargas/servidor';
import { DescargasService } from 'src/app/services/descargas.service';

@Component({
  selector: 'app-servidores',
  templateUrl: './servidores.component.html',
  styleUrls: []
})
export class ServidoresComponent implements OnInit {
  totalPages: number;
  currentPage: number;
  currentItemsPerPage: number;
  paginationConfig: any;
  servidores: Servidor[];
  nuevoServidor: Servidor;
  create: boolean;

  constructor(private descargasService: DescargasService, private router: Router,
    private route: ActivatedRoute, private toastrService: ToastrService) {
    this.totalPages = 0; this.currentPage = 1; this.currentItemsPerPage = 0;
    this.paginationConfig = { itemsPerPage: 0, currentPage: 0, totalItems: 0 };
  }

  ngOnInit() {
    this.servidores = []; this.create = false;
    this.nuevoServidor = { id_servidor: 0, nombre_servidor: "", sitio_servidor: "" };
    this.descargasService.getServidores().subscribe(servidores => {
      this.servidores = servidores; this.servidores.push(null);
      this.paginationConfig = {
        itemsPerPage: 5,
        currentPage: this.currentPage,
        totalItems: this.servidores.length
      };
      this.totalPages = Math.trunc(this.servidores.length / this.paginationConfig.itemsPerPage);
      if (this.servidores.length % this.paginationConfig.itemsPerPage != 0) this.totalPages += 1;
      this.currentItemsPerPage = this.servidores.slice(5 * (this.currentPage - 1), 5 * (this.currentPage)).length;
    });
  }

  setCreateFlag() {
    if (this.create) {
      this.create = false; return;
    }
    this.create = true;
  }

  crearServidor() {
    this.descargasService.crearServidor(this.nuevoServidor).subscribe(response => {
      if (response) {
        this.toastrService.success("Creación realizada con éxito.");
        this.router.navigate(['/servidores']);
        //this.router.navigate(['/adminDescargas']);
        return;
      }
      this.toastrService.error("Creación fallida...");
    });
  }

  actualizarServidor(servidor: Servidor) {
    this.descargasService.actualizarServidor(servidor).subscribe(response => {
      if (response) {
        this.toastrService.success("Actualización realizada con éxito.");
        this.router.navigate(['/servidores']);
        //this.router.navigate(['/adminDescargas']);
        return;
      }
      this.toastrService.error("Actualización fallida...");
    });
  }

  eliminarServidor(id_servidor: number) {
    this.descargasService.eliminarServidor(id_servidor).subscribe(response => {
      if (response) {
        this.toastrService.success("Eliminación realizada con éxito.");
        this.router.navigate(['/servidores']);
        //this.router.navigate(['/adminDescargas']);
        return;
      }
      this.toastrService.error("Eliminación fallida...");
    });
  }

  pageChanged(currentPage: number) {
    this.currentPage = currentPage;
    this.paginationConfig.currentPage = this.currentPage;
    this.currentItemsPerPage = this.servidores.slice(5 * (this.currentPage - 1), 5 * (this.currentPage)).length;
  }
}