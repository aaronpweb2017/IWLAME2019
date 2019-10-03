import { Component, OnInit, Input, Output, EventEmitter, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal'
import { DetalleTecnico } from 'src/app/interfaces/detalles/detalle-tecnico';
import { Formato } from 'src/app/interfaces/detalles/formato';
import { VResolucion } from 'src/app/interfaces/views/v-resolucion';
import { Descarga } from 'src/app/interfaces/descargas/descarga';
import { TipoArchivo } from 'src/app/interfaces/descargas/tipo-archivo';
import { Servidor } from 'src/app/interfaces/descargas/servidor';
import { Pelicula } from 'src/app/interfaces/pelicula';
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
  @Input() resoluciones: VResolucion[];
  @Input() formatos: Formato[];
  resolutionIndex: number;
  @Input() technicalDetailToUpdate: DetalleTecnico;
  @Input() tiposArchivo: TipoArchivo[];
  @Input() servidores: Servidor[];
  @Input() peliculas: Pelicula[];
  @Input() downloadToUpdate: Descarga;
  @Input() descargas: VDescarga[];
  @Input() linkToUpdate: Enlace;
  @Input() detallesTecnicos: VDetalleTecnico[];
  fecha_estreno: string;
  @Input() movieToUpdate: Pelicula;

  constructor(private modalService: BsModalService) { }

  ngOnInit() {
    if (this.request.includes("ActualizarDetalleTecnico")) {
      this.resolutionIndex = this.resoluciones.indexOf(this.resoluciones.filter(r =>
        r.id_tipo_resolucion == this.model.id_tipo_resolucion
        && r.id_valor_resolucion == this.model.id_valor_resolucion
        && r.id_relacion_aspecto == this.model.id_relacion_aspecto)[0]);
      return;
    }
    if (this.request.includes("ActualizarPelicula")) {
      this.fecha_estreno = this.model.fecha_estreno.substring(0, 10);
    }
  }

  emitModelObjectEvent() {
    if (this.request.includes("ActualizarDetalleTecnico")) {
      this.technicalDetailToUpdate.id_tipo_resolucion = this.resoluciones[this.resolutionIndex].id_tipo_resolucion;
      this.technicalDetailToUpdate.id_valor_resolucion = this.resoluciones[this.resolutionIndex].id_valor_resolucion;
      this.technicalDetailToUpdate.id_relacion_aspecto = this.resoluciones[this.resolutionIndex].id_relacion_aspecto;
      this.modelObjectEvent.emit(this.technicalDetailToUpdate); this.modalRef.hide();
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
    else
      this.modelObjectEvent.emit(this.model);
    this.modalRef.hide();
  }

  public openModal(modalTemplate: TemplateRef<any>) {
    this.modalRef = this.modalService.show(modalTemplate);
  }
}