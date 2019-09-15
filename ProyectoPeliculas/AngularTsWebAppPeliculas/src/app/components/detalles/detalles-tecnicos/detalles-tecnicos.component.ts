import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { VistasService } from 'src/app/services/vistas.service';
import { DetallesTecnicosService } from 'src/app/services/detalles-tecnicos.service';
import { VDetalleTecnico } from 'src/app/interfaces/views/v-detalle-tecnico';
import { Formato } from 'src/app/interfaces/detalles/formato';
import { VResolucion } from 'src/app/interfaces/views/v-resolucion';
import { DetalleTecnico } from 'src/app/interfaces/detalles/detalle-tecnico';

@Component({
  selector: 'app-detalles-tecnicos',
  templateUrl: './detalles-tecnicos.component.html',
  styleUrls: []
})
export class DetallesTecnicosComponent implements OnInit {
  totalPages: number;
  currentPage: number;
  currentItemsPerPage: number;
  paginationConfig: any;
  detallesTecnicos: VDetalleTecnico[];
  formatos: Formato[];
  resoluciones: VResolucion[];
  nuevoDetalleTecnico: DetalleTecnico;
  create: boolean;

  constructor(private vistasService: VistasService, private detallesTecnicosService: DetallesTecnicosService,
    private router: Router, private route: ActivatedRoute, private toastrService: ToastrService) {
    this.totalPages = 0; this.currentPage = 1; this.currentItemsPerPage = 0;
    this.paginationConfig = { itemsPerPage: 0, currentPage: 0, totalItems: 0 };
  }

  ngOnInit() {
    this.detallesTecnicos = []; this.formatos = [];
    this.resoluciones = []; this.create = false;
    this.nuevoDetalleTecnico = {
      id_detalle: 0, id_formato: 0,
      id_tipo_resolucion: 0, id_valor_resolucion: 0, id_relacion_aspecto: 0
    };
    this.vistasService.getDetallesTecnicosVista().subscribe(detallesTecnicos => {
      this.detallesTecnicos = detallesTecnicos; this.detallesTecnicos.push(null);
      this.paginationConfig = {
        itemsPerPage: 5,
        currentPage: this.currentPage,
        totalItems: this.detallesTecnicos.length
      };
      this.totalPages = Math.trunc(this.detallesTecnicos.length / this.paginationConfig.itemsPerPage);
      if (this.detallesTecnicos.length % this.paginationConfig.itemsPerPage != 0) this.totalPages += 1;
      this.currentItemsPerPage = this.detallesTecnicos.slice(5 * (this.currentPage - 1), 5 * (this.currentPage)).length;
      this.detallesTecnicosService.getFormatos().subscribe(formatos => { this.formatos = formatos; });
      this.vistasService.getResolucionesVista().subscribe(resoluciones => { this.resoluciones = resoluciones; });
    });
  }

  setCreateFlag() {
    if (this.create) {
      this.create = false; return;
    }
    this.create = true;
  }

  crearDetalleTecnico() {
    this.detallesTecnicosService.crearDetalleTecnico(this.nuevoDetalleTecnico).subscribe(response => {
      if (response) {
        this.toastrService.success("Creación realizada con éxito.");
        this.router.navigate(['/adminDetalles']); return;
      }
      this.toastrService.error("Creación fallida...");
    });
  }

  actualizarDetalleTecnico(detalleTecnico: DetalleTecnico) {
    console.log("Actualizar el detalle tecnico: " + detalleTecnico.id_detalle);
    // this.detallesTecnicosService.actualizarDetalleTecnico(detalleTecnico).subscribe(response => {
    // if(response) {
    //   this.toastrService.success("Actualización realizada con éxito.");
    //   this.router.navigate(['/adminDetalles']); return;
    // }
    // this.toastrService.error("Actualización fallida...");
    // });
  }

  eliminarDetalleTecnico(id_detalle: number) {
    console.log("Eliminar el detalle tecnico: " + id_detalle);
    this.detallesTecnicosService.eliminarDetalleTecnico(id_detalle).subscribe(response => {
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
    this.currentItemsPerPage = this.detallesTecnicos.slice(5 * (this.currentPage - 1), 5 * (this.currentPage)).length;
  }
}