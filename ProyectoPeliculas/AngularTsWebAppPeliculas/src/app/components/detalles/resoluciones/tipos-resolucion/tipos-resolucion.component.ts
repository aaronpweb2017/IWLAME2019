import { Component, OnInit } from '@angular/core';
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
  currentPage: number;
  currentItemsPerPage: number;
  paginationConfig: any;
  tiposResolucion: TipoResolucion[];
  nuevoTipoResolucion: TipoResolucion;
  create: boolean;

  constructor(private detallesTecnicosService: DetallesTecnicosService, private router: Router,
    private route: ActivatedRoute, private toastrService: ToastrService) {
    this.totalPages = 0; this.currentPage = 1; this.currentItemsPerPage = 0;
    this.paginationConfig = { itemsPerPage: 0, currentPage: 0, totalItems: 0 };
  }

  ngOnInit() {
    this.tiposResolucion = []; this.create = false;
    this.nuevoTipoResolucion = {
      id_tipo_resolucion: 0, nombre_tipo_resolucion: "",
      porcentaje_visualizacion: 0, porcentaje_perdida: 0
    };
    this.detallesTecnicosService.getTiposResolucion().subscribe(tiposResolucion => {
      this.tiposResolucion = tiposResolucion; this.tiposResolucion.push(null);
      this.paginationConfig = {
        itemsPerPage: 5,
        currentPage: this.currentPage,
        totalItems: this.tiposResolucion.length
      };
      this.totalPages = Math.trunc(this.tiposResolucion.length / this.paginationConfig.itemsPerPage);
      if (this.tiposResolucion.length % this.paginationConfig.itemsPerPage != 0) this.totalPages += 1;
      this.currentItemsPerPage = this.tiposResolucion.slice(5 * (this.currentPage - 1), 5 * (this.currentPage)).length;
    });
  }

  setCreateFlag() {
    if (this.create) {
      this.create = false; return;
    }
    this.create = true;
  }

  crearTipoResolucion() {
    this.detallesTecnicosService.crearTipoResolucion(this.nuevoTipoResolucion).subscribe(response => {
      if (response) {
        this.toastrService.success("Creación realizada con éxito.");
        this.router.navigate(['/adminDetalles']); return;
      }
      this.toastrService.error("Creación fallida...");
    });
  }

  actualizarTipoResolucion(tipoResolucion: TipoResolucion) {
    this.detallesTecnicosService.actualizarTipoResolucion(tipoResolucion).subscribe(response => {
      if (response) {
        this.toastrService.success("Actualización realizada con éxito.");
        this.router.navigate(['/adminDetalles']); return;
      }
      this.toastrService.error("Actualización fallida...");
    });
  }

  eliminarTipoResolucion(id_tipo_resolucion: number) {
    this.detallesTecnicosService.eliminarTipoResolucion(id_tipo_resolucion).subscribe(response => {
      if (response) {
        this.toastrService.success("Eliminación realizada con éxito.");
        this.router.navigate(['/adminDetalles']); return;
      }
      this.toastrService.error("Eliminación fallida...");
    });
  }

  pageChanged(currentPage: number) {
    this.currentPage = currentPage;
    this.paginationConfig.currentPage = this.currentPage;
    this.currentItemsPerPage = this.tiposResolucion.slice(5 * (this.currentPage - 1), 5 * (this.currentPage)).length;
  }
}