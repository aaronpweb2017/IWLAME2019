import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { VistasService } from 'src/app/services/vistas.service';
import { DetallesTecnicosService } from 'src/app/services/detalles-tecnicos.service';
import { VResolucion } from 'src/app/interfaces/views/v-resolucion';
import { TipoResolucion } from 'src/app/interfaces/detalles/resoluciones/tipo-resolucion';
import { ValorResolucion } from 'src/app/interfaces/detalles/resoluciones/valor-resolucion';
import { RelacionAspecto } from 'src/app/interfaces/detalles/resoluciones/relacion-aspecto';
import { Resolucion } from 'src/app/interfaces/detalles/resoluciones/resolucion';

@Component({
  selector: 'app-resoluciones',
  templateUrl: './resoluciones.component.html',
  styleUrls: []
})
export class ResolucionesComponent implements OnInit {
  totalPages: number;
  @Input() currentPage: number;
  currentItemsPerPage: number;
  paginationConfig: any;
  resoluciones: VResolucion[];
  tiposResolucion: TipoResolucion[];
  valoresResolucion: ValorResolucion[];
  relacionesAspecto: RelacionAspecto[];
  nuevaResolucion: Resolucion;
  create: boolean;

  constructor(private vistasService: VistasService, private detallesTecnicosService: DetallesTecnicosService,
    private router: Router, private route: ActivatedRoute, private toastrService: ToastrService) {
    this.totalPages = 0; this.currentItemsPerPage = 0;
    this.paginationConfig = { itemsPerPage: 0, currentPage: 0, totalItems: 0 };
  }

  ngOnInit() {
    this.resoluciones = []; this.tiposResolucion = [];
    this.valoresResolucion = []; this.relacionesAspecto = []; this.create = false;
    this.nuevaResolucion = { id_tipo_resolucion: 0, id_valor_resolucion: 0, id_relacion_aspecto: 0 };
    this.vistasService.getVistaResoluciones().subscribe(
      response => {
        if (response[0]) {
          this.resoluciones = response[0]; this.resoluciones.push(null);
          if(this.currentPage == 0) this.currentPage = 1;
          this.paginationConfig = {
            itemsPerPage: 5,
            currentPage: this.currentPage,
            totalItems: this.resoluciones.length
          };
          this.totalPages = Math.trunc(this.resoluciones.length / this.paginationConfig.itemsPerPage);
          if (this.resoluciones.length % this.paginationConfig.itemsPerPage != 0) this.totalPages += 1;
          this.currentItemsPerPage = this.resoluciones.slice(5 * (this.currentPage - 1), 5 * (this.currentPage)).length;
          this.detallesTecnicosService.getTiposResolucion().subscribe(
            response => {
              if (response[0])
                this.tiposResolucion = response[0];
            }, error => {
              this.toastrService.error(error.message);
            });
          this.detallesTecnicosService.getValoresResolucion().subscribe(
            response => {
              if (response[0])
                this.valoresResolucion = response[0];
            }, error => {
              this.toastrService.error(error.message);
            });
          this.detallesTecnicosService.getRelacionesAspecto().subscribe(
            response => {
              if (response[0])
                this.relacionesAspecto = response[0];
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

  setCreateFlag(flag: boolean) {
    this.create = flag;
  }

  crearResolucion() {
    this.detallesTecnicosService.crearResolucion(this.nuevaResolucion).subscribe(
      response => {
        if (response[0]) {
          this.toastrService.success("Creación realizada con éxito.");
          this.router.navigate(['/adminDetalles', { currentPageResoluciones: this.currentPage }]); return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }

  eliminarResolucion(resolucion: VResolucion) {
    this.detallesTecnicosService.eliminarResolucion(resolucion.id_tipo_resolucion,
      resolucion.id_valor_resolucion, resolucion.id_relacion_aspecto).subscribe(
        response => {
          if (response[0]) {
            this.toastrService.success("Eliminación realizada con éxito.");
            this.router.navigate(['/adminDetalles', { currentPageResoluciones: this.currentPage }]); return;
          }
          this.toastrService.error(response[1]);
        }, error => {
          this.toastrService.error(error.message);
        });
  }

  pageChanged(currentPage: number) {
    this.currentPage = currentPage;
    this.paginationConfig.currentPage = this.currentPage;
    this.currentItemsPerPage = this.resoluciones.slice(5 * (this.currentPage - 1), 5 * (this.currentPage)).length;
  }
}