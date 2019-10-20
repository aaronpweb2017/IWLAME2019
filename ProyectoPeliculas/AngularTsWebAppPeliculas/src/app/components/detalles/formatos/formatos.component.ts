import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DetallesTecnicosService } from 'src/app/services/detalles-tecnicos.service';
import { Formato } from 'src/app/interfaces/detalles/formato';

@Component({
  selector: 'app-formato',
  templateUrl: './formatos.component.html',
  styleUrls: []
})
export class FormatoComponent implements OnInit {
  totalPages: number;
  @Input() currentPage: number;
  currentItemsPerPage: number;
  paginationConfig: any;
  formatos: Formato[];
  nuevoFormato: Formato;
  create: boolean;

  constructor(private detallesTecnicosService: DetallesTecnicosService, private router: Router,
    private route: ActivatedRoute, private toastrService: ToastrService) {
    this.totalPages = 0; this.currentItemsPerPage = 0;
    this.paginationConfig = { itemsPerPage: 0, currentPage: 0, totalItems: 0 };
  }

  ngOnInit() {
    this.formatos = []; this.create = false;
    this.nuevoFormato = { id_formato: 0, nombre_formato: "" };
    this.detallesTecnicosService.getFormatos().subscribe(
      response => {
        if (response[0]) {
          this.formatos = response[0];
          this.formatos.push(null);
          if (this.currentPage == 0) this.currentPage = 1;
          this.paginationConfig = {
            itemsPerPage: 5,
            currentPage: this.currentPage,
            totalItems: this.formatos.length
          };
          this.totalPages = Math.trunc(this.formatos.length / this.paginationConfig.itemsPerPage);
          if (this.formatos.length % this.paginationConfig.itemsPerPage != 0) this.totalPages += 1;
          this.currentItemsPerPage = this.formatos.slice(this.paginationConfig.itemsPerPage
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

  crearFormato() {
    this.detallesTecnicosService.crearFormato(this.nuevoFormato).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Creación realizada con éxito.");
          this.router.navigate(['/adminDetalles', { currentPageFormato: this.currentPage }]); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  actualizarFormato(formato: Formato) {
    this.detallesTecnicosService.actualizarFormato(formato).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Actualización realizada con éxito.");
          this.router.navigate(['/adminDetalles', { currentPageFormato: this.currentPage }]); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  eliminarFormato(id_formato: number) {
    this.detallesTecnicosService.eliminarFormato(id_formato).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Eliminación realizada con éxito.");
          this.router.navigate(['/adminDetalles', { currentPageFormato: this.currentPage }]); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  pageChanged(currentPage: number) {
    this.currentPage = currentPage;
    this.paginationConfig.currentPage = this.currentPage;
    this.currentItemsPerPage = this.formatos.slice(this.paginationConfig.itemsPerPage
      * (this.currentPage - 1), this.paginationConfig.itemsPerPage * (this.currentPage)).length;
  }
}