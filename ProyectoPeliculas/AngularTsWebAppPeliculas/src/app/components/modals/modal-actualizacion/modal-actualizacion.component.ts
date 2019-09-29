import { Component, OnInit, Input, Output, EventEmitter, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal'
import { DetalleTecnico } from 'src/app/interfaces/detalles/detalle-tecnico';
import { Formato } from 'src/app/interfaces/detalles/formato';
import { VResolucion } from 'src/app/interfaces/views/v-resolucion';
import { VistasService } from 'src/app/services/vistas.service';
import { DetallesTecnicosService } from 'src/app/services/detalles-tecnicos.service';
import { Descarga } from 'src/app/interfaces/descargas/descarga';
import { TipoArchivo } from 'src/app/interfaces/descargas/tipo-archivo';
import { Servidor } from 'src/app/interfaces/descargas/servidor';
import { Pelicula } from 'src/app/interfaces/pelicula';
import { DescargasService } from 'src/app/services/descargas.service';
import { PeliculasService } from 'src/app/services/peliculas.service';
import { VDescarga } from 'src/app/interfaces/views/v-descarga';
import { Enlace } from 'src/app/interfaces/descargas/enlace';
import { VDetalleTecnico } from 'src/app/interfaces/views/v-detalle-tecnico';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-modal-actualizacion',
  templateUrl: './modal-actualizacion.component.html',
  styleUrls: []
})
export class ModalActualizacionComponent implements OnInit {
  modalRef: BsModalRef;
  @Input() request: string;
  @Input() model: any;
  @Output() modelObjectEvent = new EventEmitter();

  resoluciones: VResolucion[];
  formatos: Formato[];
  resolutionIndex: number;
  technicalDetailToUpdate: DetalleTecnico;
  tiposArchivo: TipoArchivo[];
  servidores: Servidor[];
  peliculas: Pelicula[];
  downloadToUpdate: Descarga;
  descargas: VDescarga[];
  linkToUpdate: Enlace;
  detallesTecnicos: VDetalleTecnico[];
  fecha_estreno: string;
  movieToUpdate: Pelicula;

  constructor(private vistasService: VistasService, private detallesTecnicosService: DetallesTecnicosService,
    private descargasService: DescargasService, private peliculasService: PeliculasService,
    private modalService: BsModalService, private toastrService: ToastrService) { }

  ngOnInit() {
    if (this.request.includes("ActualizarDetalleTecnico")) {
      this.technicalDetailToUpdate = {
        id_detalle: this.model.id_detalle, id_formato: this.model.id_formato,
        id_tipo_resolucion: this.model.id_tipo_resolucion,
        id_valor_resolucion: this.model.id_valor_resolucion,
        id_relacion_aspecto: this.model.id_relacion_aspecto
      };
      this.vistasService.getVistaResoluciones().subscribe(
        resoluciones => {
          this.resoluciones = resoluciones;
          this.resolutionIndex = this.resoluciones.indexOf(this.resoluciones.filter(r =>
            r.id_tipo_resolucion == this.model.id_tipo_resolucion
            && r.id_valor_resolucion == this.model.id_valor_resolucion
            && r.id_relacion_aspecto == this.model.id_relacion_aspecto)[0]);
          this.detallesTecnicosService.getFormatos().subscribe(
            formatos => {
              this.formatos = formatos;
            }, error => {
              this.toastrService.error(error.message);
            });
        }, error => {
          this.toastrService.error(error.message);
        });
    }
    if (this.request.includes("ActualizarDescarga")) {
      this.downloadToUpdate = {
        id_descarga: this.model.id_descarga,
        password_descarga: this.model.password_descarga,
        id_tipo_archivo: this.model.id_tipo_archivo,
        id_servidor: this.model.id_servidor,
        id_pelicula: this.model.id_pelicula
      };
      this.descargasService.getTiposArchivo().subscribe(
        tiposArchivo => {
          this.tiposArchivo = tiposArchivo;
        }, error => {
          this.toastrService.error(error.message);
        });
      this.descargasService.getServidores().subscribe(
        servidores => {
          this.servidores = servidores;
        }, error => {
          this.toastrService.error(error.message);
        });
      this.peliculasService.getPeliculas().subscribe(
        peliculas => {
          this.peliculas = peliculas;
        }, error => {
          this.toastrService.error(error.message);
        });
    }
    if (this.request.includes("ActualizarEnlace")) {
      this.linkToUpdate = {
        id_enlace: this.model.id_enlace, valor_enlace: this.model.valor_enlace,
        status_enlace: this.model.status_enlace, id_descarga: this.model.id_descarga
      };
      this.vistasService.getVistaDescargas().subscribe(
        descargas => {
          this.descargas = descargas;
        }, error => {
          this.toastrService.error(error.message);
        });
    }
    if (this.request.includes("ActualizarPelicula")) {
      this.fecha_estreno = this.model.fecha_estreno.substring(0, 10);
      this.movieToUpdate = {
        id_pelicula: this.model.id_pelicula,
        nombre_pelicula: this.model.nombre_pelicula,
        fecha_estreno: this.model.fecha_estreno,
        presupuesto: this.model.presupuesto,
        recaudacion: this.model.recaudacion,
        sinopsis: this.model.sinopsis,
        calificacion: this.model.calificacion,
        directores: this.model.directores,
        generos: this.model.generos,
        idiomas: this.model.idiomas,
        productoras: this.model.productoras,
        actores: this.model.actores,
        pais: this.model.pais,
        audios: this.model.audios,
        subtitulos: this.model.subtitulos,
        peso: this.model.peso,
        id_detalle: this.model.id_detalle,
        rutaImagen: this.model.rutaImagen,
      };
      this.vistasService.getVistaDetallesTecnicos().subscribe(
        detallesTecnicos => {
          this.detallesTecnicos = detallesTecnicos;
        }, error => {
          this.toastrService.error(error.message);
        });
    }
  }

  emitModelObjectEvent() {
    if (this.request.includes("ActualizarDetalleTecnico")) {
      this.technicalDetailToUpdate.id_tipo_resolucion = this.resoluciones[this.resolutionIndex].id_tipo_resolucion;
      this.technicalDetailToUpdate.id_valor_resolucion = this.resoluciones[this.resolutionIndex].id_valor_resolucion;
      this.technicalDetailToUpdate.id_relacion_aspecto = this.resoluciones[this.resolutionIndex].id_relacion_aspecto;
      this.modelObjectEvent.emit(this.technicalDetailToUpdate); this.modalRef.hide(); return;
    }
    else if (this.request.includes("ActualizarDescarga")) {
      this.modelObjectEvent.emit(this.downloadToUpdate);
    }
    else if (this.request.includes("ActualizarEnlace")) {
      this.modelObjectEvent.emit(this.linkToUpdate);
    }
    else if (this.request.includes("ActualizarPelicula")) {
      this.movieToUpdate.fecha_estreno = new Date(this.fecha_estreno);
      this.modelObjectEvent.emit(this.movieToUpdate);
    }
    else {
      this.modelObjectEvent.emit(this.model);
    }
    this.modalRef.hide();
  }

  public openModal(modalTemplate: TemplateRef<any>) {
    this.modalRef = this.modalService.show(modalTemplate);
  }
}