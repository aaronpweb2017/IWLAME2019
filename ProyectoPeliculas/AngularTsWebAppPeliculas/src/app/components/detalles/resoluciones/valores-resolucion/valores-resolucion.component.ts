import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DetallesTecnicosService } from 'src/app/services/detalles-tecnicos.service';
import { ValorResolucion } from 'src/app/interfaces/detalles/resoluciones/valor-resolucion';

@Component({
  selector: 'app-valores-resolucion',
  templateUrl: './valores-resolucion.component.html',
  styleUrls: []
})
export class ValoresResolucionComponent implements OnInit {
  totalPages: number;
  currentPage: number;
  currentItemsPerPage: number;
  paginationConfig: any;
  valoresResolucion: ValorResolucion[];
  nuevoValorResolucion: ValorResolucion;
  create: boolean;

  constructor(private detallesTecnicosService: DetallesTecnicosService, private router: Router,
    private route: ActivatedRoute, private toastrService: ToastrService) {
    this.totalPages = 0; this.currentPage = 1; this.currentItemsPerPage = 0;
    this.paginationConfig = { itemsPerPage: 0, currentPage: 0, totalItems: 0 };
  }

  ngOnInit() {
    this.valoresResolucion = []; this.create = false;
    this.nuevoValorResolucion = { id_valor_resolucion: 0, valor_resolucion: "" };
    this.detallesTecnicosService.getValoresResolucion().subscribe(
      response => {
        if (response[0]) {
          this.valoresResolucion = response[0];
          this.valoresResolucion.push(null);
          this.paginationConfig = {
            itemsPerPage: 5,
            currentPage: this.currentPage,
            totalItems: this.valoresResolucion.length
          };
          this.totalPages = Math.trunc(this.valoresResolucion.length / this.paginationConfig.itemsPerPage);
          if (this.valoresResolucion.length % this.paginationConfig.itemsPerPage != 0) this.totalPages += 1;
          this.currentItemsPerPage = this.valoresResolucion.slice(5 * (this.currentPage - 1), 5 * (this.currentPage)).length;
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

  crearValorResolucion() {
    this.detallesTecnicosService.crearValorResolucion(this.nuevoValorResolucion).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Creación realizada con éxito.");
          this.router.navigate(['/adminDetalles']); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  actualizarValorResolucion(valorResolucion: ValorResolucion) {
    this.detallesTecnicosService.actualizarValorResolucion(valorResolucion).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Actualización realizada con éxito.");
          this.router.navigate(['/adminDetalles']); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  eliminarValorResolucion(id_valor_resolucion: number) {
    this.detallesTecnicosService.eliminarValorResolucion(id_valor_resolucion).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Eliminación realizada con éxito.");
          this.router.navigate(['/adminDetalles']); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  pageChanged(currentPage: number) {
    this.currentPage = currentPage;
    this.paginationConfig.currentPage = this.currentPage;
    this.currentItemsPerPage = this.valoresResolucion.slice(5 * (this.currentPage - 1), 5 * (this.currentPage)).length;
  }
}