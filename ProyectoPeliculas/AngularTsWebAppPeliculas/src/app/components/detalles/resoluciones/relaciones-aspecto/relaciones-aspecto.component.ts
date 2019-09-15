import { Component, OnInit } from '@angular/core';
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
  currentPage: number;
  currentItemsPerPage: number;
  paginationConfig: any;
  relacionesAspecto: RelacionAspecto[];
  nuevaRelacionAspecto: RelacionAspecto;
  create: boolean;

  constructor(private detallesTecnicosService: DetallesTecnicosService, private router: Router,
    private route: ActivatedRoute, private toastrService: ToastrService) {
    this.totalPages = 0; this.currentPage = 1; this.currentItemsPerPage = 0;
    this.paginationConfig = { itemsPerPage: 0, currentPage: 0, totalItems: 0 };
  }

  ngOnInit() {
    this.relacionesAspecto = []; this.create = false;
    this.nuevaRelacionAspecto = { id_relacion_aspecto: 0, valor_relacion_aspecto: "" };
    this.detallesTecnicosService.getRelacionesAspecto().subscribe(relacionesAspecto => {
      this.relacionesAspecto = relacionesAspecto; this.relacionesAspecto.push(null);
      this.paginationConfig = {
        itemsPerPage: 5,
        currentPage: this.currentPage,
        totalItems: this.relacionesAspecto.length
      };
      this.totalPages = Math.trunc(this.relacionesAspecto.length / this.paginationConfig.itemsPerPage);
      if (this.relacionesAspecto.length % this.paginationConfig.itemsPerPage != 0) this.totalPages += 1;
      this.currentItemsPerPage = this.relacionesAspecto.slice(5 * (this.currentPage - 1), 5 * (this.currentPage)).length;
    });
  }

  setCreateFlag() {
    if (this.create) {
      this.create = false; return;
    }
    this.create = true;
  }

  crearRelacionAspecto() {
    this.detallesTecnicosService.crearRelacionAspecto(this.nuevaRelacionAspecto).subscribe(response => {
      if (response) {
        this.toastrService.success("Creación realizada con éxito.");
        this.router.navigate(['/adminDetalles']); return;
      }
      this.toastrService.error("Creación fallida...");
    });
  }

  actualizarRelacionAspecto(relacionAspecto: RelacionAspecto) {
    console.log("Actualizar la relación de aspecto: " + relacionAspecto.id_relacion_aspecto);
    //this.detallesTecnicosService.actualizarRelacionAspecto(relacionAspecto).subscribe(response => {
    //if(response) {
    //  this.toastrService.success("Actualización realizada con éxito.");
    //  this.router.navigate(['/adminDetalles']); return;
    //}
    //this.toastrService.error("Actualización fallida...");
    //});
  }

  eliminarRelacionAspecto(id_relacion_aspecto: number) {
    console.log("Eliminar la relación de aspecto " + id_relacion_aspecto);
    //this.detallesTecnicosService.eliminarRelacionAspecto(id_relacion_aspecto).subscribe(response => {
    //if(response) {
    //  this.toastrService.success("Eliminación realizada con éxito.");
    //  this.router.navigate(['/adminDetalles']); return;
    //}
    //this.toastrService.error("Eliminación fallida...");
    //});
  }

  pageChanged(currentPage: number) {
    this.currentPage = currentPage;
    this.paginationConfig.currentPage = this.currentPage;
    this.currentItemsPerPage = this.relacionesAspecto.slice(5 * (this.currentPage - 1), 5 * (this.currentPage)).length;
  }
}