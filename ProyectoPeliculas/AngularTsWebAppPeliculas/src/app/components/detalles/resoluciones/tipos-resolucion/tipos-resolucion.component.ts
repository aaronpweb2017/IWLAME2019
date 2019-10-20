import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DetallesTecnicosService } from 'src/app/services/detalles-tecnicos.service';
import { TipoResolucion } from 'src/app/interfaces/detalles/resoluciones/tipo-resolucion';

@Component({
  selector: 'app-tipos-resolucion',
  templateUrl: './tipos-resolucion.component.html',
  styleUrls: []
})
export class TiposResolucionComponent implements OnInit {
  totalPages: number;
  @Input() currentPage: number;
  currentItemsPerPage: number;
  paginationConfig: any;
  tiposResolucion: TipoResolucion[];
  nuevoTipoResolucion: TipoResolucion;
  create: boolean;

  constructor(private detallesTecnicosService: DetallesTecnicosService, private router: Router,
    private route: ActivatedRoute, private toastrService: ToastrService) {
    this.totalPages = 0; this.currentItemsPerPage = 0;
    this.paginationConfig = { itemsPerPage: 0, currentPage: 0, totalItems: 0 };
  }

  ngOnInit() {
    this.tiposResolucion = []; this.create = false;
    this.nuevoTipoResolucion = {
      id_tipo_resolucion: 0, nombre_tipo_resolucion: "",
      porcentaje_visualizacion: 0, porcentaje_perdida: 0
    };
    this.detallesTecnicosService.getTiposResolucion().subscribe(
      response => {
        if (response[0]) {
          this.tiposResolucion = response[0];
          this.tiposResolucion.push(null);
          if (this.currentPage == 0) this.currentPage = 1;
          this.paginationConfig = {
            itemsPerPage: 5,
            currentPage: this.currentPage,
            totalItems: this.tiposResolucion.length
          };
          this.totalPages = Math.trunc(this.tiposResolucion.length / this.paginationConfig.itemsPerPage);
          if (this.tiposResolucion.length % this.paginationConfig.itemsPerPage != 0) this.totalPages += 1;
          this.currentItemsPerPage = this.tiposResolucion.slice(this.paginationConfig.itemsPerPage
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

  crearTipoResolucion() {
    this.detallesTecnicosService.crearTipoResolucion(this.nuevoTipoResolucion).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Creación realizada con éxito.");
          this.router.navigate(['/adminDetalles', { currentPageTiposResolucion: this.currentPage }]); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  actualizarTipoResolucion(tipoResolucion: TipoResolucion) {
    this.detallesTecnicosService.actualizarTipoResolucion(tipoResolucion).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Actualización realizada con éxito.");
          this.router.navigate(['/adminDetalles', { currentPageTiposResolucion: this.currentPage }]); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  eliminarTipoResolucion(id_tipo_resolucion: number) {
    this.detallesTecnicosService.eliminarTipoResolucion(id_tipo_resolucion).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Eliminación realizada con éxito.");
          this.router.navigate(['/adminDetalles', { currentPageTiposResolucion: this.currentPage }]); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  pageChanged(currentPage: number) {
    this.currentPage = currentPage;
    this.paginationConfig.currentPage = this.currentPage;
    this.currentItemsPerPage = this.tiposResolucion.slice(this.paginationConfig.itemsPerPage
      * (this.currentPage - 1), this.paginationConfig.itemsPerPage * (this.currentPage)).length;
  }
}