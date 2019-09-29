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
  movieToUpdate: Pelicula;

  constructor(private vistasService: VistasService, private detallesTecnicosService:
    DetallesTecnicosService, private descargasService: DescargasService,
    private peliculasService: PeliculasService, private modalService: BsModalService) { }

  ngOnInit() {
    if (this.request.includes("ActualizarDetalleTecnico")) {
      this.technicalDetailToUpdate = {
        id_detalle: this.model.id_detalle, id_formato: this.model.id_formato,
        id_tipo_resolucion: this.model.id_tipo_resolucion,
        id_valor_resolucion: this.model.id_valor_resolucion,
        id_relacion_aspecto: this.model.id_relacion_aspecto
      };
      this.vistasService.getVistaResoluciones().subscribe(resoluciones => {
        this.resoluciones = resoluciones;
        this.resolutionIndex = this.resoluciones.indexOf(this.resoluciones.filter(r =>
          r.id_tipo_resolucion == this.model.id_tipo_resolucion
          && r.id_valor_resolucion == this.model.id_valor_resolucion
          && r.id_relacion_aspecto == this.model.id_relacion_aspecto)[0]);
        this.detallesTecnicosService.getFormatos().subscribe(formatos => { this.formatos = formatos; });
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
      this.descargasService.getTiposArchivo().subscribe(tiposArchivo => { this.tiposArchivo = tiposArchivo; });
      this.descargasService.getServidores().subscribe(servidores => { this.servidores = servidores; });
      this.peliculasService.getPeliculas().subscribe(peliculas => { this.peliculas = peliculas; });
    }
    if (this.request.includes("ActualizarEnlace")) {
      this.linkToUpdate = {
        id_enlace: this.model.id_enlace, valor_enlace: this.model.valor_enlace,
        status_enlace: this.model.status_enlace, id_descarga: this.model.id_descarga
      };
      this.vistasService.getVistaDescargas().subscribe(descargas => {
        this.descargas = descargas;
      });
    }
    if (this.request.includes("ActualizarPelicula")) {
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
        id_detalle: this.model.id_detalle,
        rutaImagen: this.model.rutaImagen,
      };
      this.vistasService.getVistaDetallesTecnicos().subscribe(detallesTecnicos => { this.detallesTecnicos = detallesTecnicos; });
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