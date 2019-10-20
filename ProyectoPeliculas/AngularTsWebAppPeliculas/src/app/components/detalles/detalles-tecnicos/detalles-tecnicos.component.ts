import { Component, OnInit, Input } from '@angular/core';
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
  @Input() currentPage: number;
  currentItemsPerPage: number;
  paginationConfig: any;
  detallesTecnicos: VDetalleTecnico[];
  formatos: Formato[];
  resoluciones: VResolucion[];
  nuevoDetalleTecnico: DetalleTecnico;
  resolutionIndex: number;
  create: boolean;

  constructor(private vistasService: VistasService, private detallesTecnicosService: DetallesTecnicosService,
    private router: Router, private route: ActivatedRoute, private toastrService: ToastrService) {
    this.totalPages = 0; this.currentItemsPerPage = 0;
    this.paginationConfig = { itemsPerPage: 0, currentPage: 0, totalItems: 0 };
  }
  ngOnInit() {
    this.detallesTecnicos = []; this.formatos = [];
    this.resoluciones = []; this.create = false;
    this.inicializaDetalleTecnico();
    this.resolutionIndex = -1;
    this.vistasService.getVistaDetallesTecnicos().subscribe(
      response => {
        if (response[0]) {
          this.detallesTecnicos = response[0];
          this.detallesTecnicos.push(null);
          if(this.currentPage == 0) this.currentPage = 1;
          this.paginationConfig = {
            itemsPerPage: 5,
            currentPage: this.currentPage,
            totalItems: this.detallesTecnicos.length
          };
          this.totalPages = Math.trunc(this.detallesTecnicos.length / this.paginationConfig.itemsPerPage);
          if (this.detallesTecnicos.length % this.paginationConfig.itemsPerPage != 0) this.totalPages += 1;
          this.currentItemsPerPage = this.detallesTecnicos.slice(this.paginationConfig.itemsPerPage * (this.currentPage - 1), this.paginationConfig.itemsPerPage * (this.currentPage)).length;
          this.detallesTecnicosService.getFormatos().subscribe(
            response => {
              if (response[0])
                this.formatos = response[0];
            }, error => {
              this.toastrService.error(error.message);
            });
          this.vistasService.getVistaResoluciones().subscribe(
            response => {
              if (response[0])
                this.resoluciones = response[0];
            }, error => {
              this.toastrService.error(error.message);
            });
          return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  inicializaDetalleTecnico() {
    this.nuevoDetalleTecnico = {
      id_detalle: 0, id_formato: 0, id_tipo_resolucion: 0,
      id_valor_resolucion: 0, id_relacion_aspecto: 0
    };
  }

  setCreateFlag(flag: boolean) {
    this.create = flag;
  }

  crearDetalleTecnico() {
    this.nuevoDetalleTecnico.id_tipo_resolucion = this.resoluciones[this.resolutionIndex].id_tipo_resolucion;
    this.nuevoDetalleTecnico.id_valor_resolucion = this.resoluciones[this.resolutionIndex].id_valor_resolucion;
    this.nuevoDetalleTecnico.id_relacion_aspecto = this.resoluciones[this.resolutionIndex].id_relacion_aspecto;
    this.detallesTecnicosService.crearDetalleTecnico(this.nuevoDetalleTecnico).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Creación realizada con éxito.");
          this.router.navigate(['/adminDetalles', { currentPageDetallesTecnicos: this.currentPage }]);
          this.inicializaDetalleTecnico(); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  actualizarDetalleTecnico(detalleTecnico: VDetalleTecnico) {
    this.nuevoDetalleTecnico.id_detalle = detalleTecnico.id_detalle;
    this.nuevoDetalleTecnico.id_formato = detalleTecnico.id_formato;
    this.nuevoDetalleTecnico.id_tipo_resolucion = detalleTecnico.id_tipo_resolucion;
    this.nuevoDetalleTecnico.id_valor_resolucion = detalleTecnico.id_valor_resolucion;
    this.nuevoDetalleTecnico.id_relacion_aspecto = detalleTecnico.id_relacion_aspecto;
    this.detallesTecnicosService.actualizarDetalleTecnico(detalleTecnico).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Actualización realizada con éxito.");
          this.router.navigate(['/adminDetalles', { currentPageDetallesTecnicos: this.currentPage }]); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  eliminarDetalleTecnico(id_detalle: number) {
    this.detallesTecnicosService.eliminarDetalleTecnico(id_detalle).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Eliminación realizada con éxito.");
          this.router.navigate(['/adminDetalles', { currentPageDetallesTecnicos: this.currentPage }]); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  pageChanged(currentPage: number) {
    this.currentPage = currentPage;
    this.paginationConfig.currentPage = this.currentPage;
    this.currentItemsPerPage = this.detallesTecnicos.slice(this.paginationConfig.itemsPerPage * (this.currentPage - 1), this.paginationConfig.itemsPerPage * (this.currentPage)).length;
  }
}