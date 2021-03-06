import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TipoArchivo } from 'src/app/interfaces/descargas/tipo-archivo';
import { DescargasService } from 'src/app/services/descargas.service';

@Component({
  selector: 'app-tipos-archivo',
  templateUrl: './tipos-archivo.component.html',
  styleUrls: []
})
export class TiposArchivoComponent implements OnInit {
  totalPages: number;
  @Input() currentPage: number = 1;
  currentItemsPerPage: number;
  paginationConfig: any;
  tiposArchivo: TipoArchivo[];
  nuevoTipoArchivo: TipoArchivo;
  create: boolean;

  constructor(private descargasService: DescargasService, private router: Router,
    private route: ActivatedRoute, private toastrService: ToastrService) {
    this.totalPages = 0; this.currentItemsPerPage = 0;
    this.paginationConfig = { itemsPerPage: 0, currentPage: 0, totalItems: 0 };
  }

  ngOnInit() {
    this.tiposArchivo = []; this.create = false;
    this.nuevoTipoArchivo = { id_tipo_archivo: 0, nombre_tipo_archivo: "" };
    this.descargasService.getTiposArchivo().subscribe(
      response => {
        if (response[0]) {
          this.tiposArchivo = response[0];
          this.tiposArchivo.push(null);
          if (this.currentPage == 0) this.currentPage = 1;
          this.paginationConfig = {
            itemsPerPage: 5,
            currentPage: this.currentPage,
            totalItems: this.tiposArchivo.length
          };
          this.totalPages = Math.trunc(this.tiposArchivo.length / this.paginationConfig.itemsPerPage);
          if (this.tiposArchivo.length % this.paginationConfig.itemsPerPage != 0) this.totalPages += 1;
          this.currentItemsPerPage = this.tiposArchivo.slice(this.paginationConfig.itemsPerPage
            * (this.currentPage - 1), this.paginationConfig.itemsPerPage * (this.currentPage)).length;
          return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  setCreateFlag(flag: boolean) {
    this.create = flag;
  }

  crearTipoArchivo() {
    this.descargasService.crearTipoArchivo(this.nuevoTipoArchivo).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Creación realizada con éxito.");
          this.router.navigate(['/adminDescargas', { currentPageTiposArchivo: this.currentPage }]);
          return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  actualizarTipoArchivo(tipoArchivo: TipoArchivo) {
    this.descargasService.actualizarTipoArchivo(tipoArchivo).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Actualización realizada con éxito.");
          this.router.navigate(['/adminDescargas', { currentPageTiposArchivo: this.currentPage }]);
          return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  eliminarTipoArchivo(id_tipo_archivo: number) {
    this.descargasService.eliminarTipoArchivo(id_tipo_archivo).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Eliminación realizada con éxito.");
          this.router.navigate(['/adminDescargas', { currentPageTiposArchivo: this.currentPage }]);
          return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  pageChanged(currentPage: number) {
    this.currentPage = currentPage;
    this.paginationConfig.currentPage = this.currentPage;
    this.currentItemsPerPage = this.tiposArchivo.slice(this.paginationConfig.itemsPerPage
      * (this.currentPage - 1), this.paginationConfig.itemsPerPage * (this.currentPage)).length;
  }
}