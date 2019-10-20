import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DetallesTecnicosService } from 'src/app/services/detalles-tecnicos.service';
import { RelacionAspecto } from 'src/app/interfaces/detalles/resoluciones/relacion-aspecto';

@Component({
  selector: 'app-relaciones-aspecto',
  templateUrl: './relaciones-aspecto.component.html',
  styleUrls: []
})
export class RelacionesAspectoComponent implements OnInit {
  totalPages: number;
  @Input() currentPage: number;
  currentItemsPerPage: number;
  paginationConfig: any;
  relacionesAspecto: RelacionAspecto[];
  nuevaRelacionAspecto: RelacionAspecto;
  create: boolean;

  constructor(private detallesTecnicosService: DetallesTecnicosService, private router: Router,
    private route: ActivatedRoute, private toastrService: ToastrService) {
    this.totalPages = 0; this.currentItemsPerPage = 0;
    this.paginationConfig = { itemsPerPage: 0, currentPage: 0, totalItems: 0 };
  }

  ngOnInit() {
    this.relacionesAspecto = []; this.create = false;
    this.nuevaRelacionAspecto = { id_relacion_aspecto: 0, valor_relacion_aspecto: "" };
    this.detallesTecnicosService.getRelacionesAspecto().subscribe(
      response => {
        if (response[0]) {
          this.relacionesAspecto = response[0];
          this.relacionesAspecto.push(null);
          if (this.currentPage == 0) this.currentPage = 1;
          this.paginationConfig = {
            itemsPerPage: 5,
            currentPage: this.currentPage,
            totalItems: this.relacionesAspecto.length
          };
          this.totalPages = Math.trunc(this.relacionesAspecto.length / this.paginationConfig.itemsPerPage);
          if (this.relacionesAspecto.length % this.paginationConfig.itemsPerPage != 0) this.totalPages += 1;
          this.currentItemsPerPage = this.relacionesAspecto.slice(this.paginationConfig.itemsPerPage
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

  crearRelacionAspecto() {
    this.detallesTecnicosService.crearRelacionAspecto(this.nuevaRelacionAspecto).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Creación realizada con éxito.");
          this.router.navigate(['/adminDetalles', { currentPageRelacionesAspecto: this.currentPage }]); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  actualizarRelacionAspecto(relacionAspecto: RelacionAspecto) {
    this.detallesTecnicosService.actualizarRelacionAspecto(relacionAspecto).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Actualización realizada con éxito.");
          this.router.navigate(['/adminDetalles', { currentPageRelacionesAspecto: this.currentPage }]); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  eliminarRelacionAspecto(id_relacion_aspecto: number) {
    this.detallesTecnicosService.eliminarRelacionAspecto(id_relacion_aspecto).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Eliminación realizada con éxito.");
          this.router.navigate(['/adminDetalles', { currentPageRelacionesAspecto: this.currentPage }]); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  pageChanged(currentPage: number) {
    this.currentPage = currentPage;
    this.paginationConfig.currentPage = this.currentPage;
    this.currentItemsPerPage = this.relacionesAspecto.slice(this.paginationConfig.itemsPerPage
      * (this.currentPage - 1), this.paginationConfig.itemsPerPage * (this.currentPage)).length;
  }
}