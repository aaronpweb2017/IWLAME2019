import { Component, OnInit, Input, Output, EventEmitter, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal'
import { DetalleTecnico } from 'src/app/interfaces/detalles/detalle-tecnico';
import { Formato } from 'src/app/interfaces/detalles/formato';
import { VResolucion } from 'src/app/interfaces/views/v-resolucion';
import { VistasService } from 'src/app/services/vistas.service';
import { DetallesTecnicosService } from 'src/app/services/detalles-tecnicos.service';

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

  constructor(private vistasService: VistasService, private detallesTecnicosService:
    DetallesTecnicosService, private modalService: BsModalService) { }

  ngOnInit() {
    if (this.request.includes("ActualizarDetalleTecnico")) {
      this.technicalDetailToUpdate = {
        id_detalle: this.model.id, id_formato: 0, id_tipo_resolucion: 0,
        id_valor_resolucion: 0, id_relacion_aspecto: 0
      };
      this.vistasService.getResolucionesVista().subscribe(resoluciones => {
        this.resoluciones = resoluciones;
        this.resolutionIndex = this.resoluciones.indexOf(this.resoluciones.filter(r => r.tipo.includes(this.model.tipo)
          && r.valor.includes(this.model.valor) && r.aspecto.includes(this.model.aspecto))[0]);
        this.detallesTecnicosService.getFormatos().subscribe(formatos => { 
          this.formatos = formatos;
          let id_formato: number = this.formatos.filter(f => f.nombre_formato.includes(this.model.formato))[0].id_formato;
          this.technicalDetailToUpdate.id_formato = id_formato;
        });
      });
    }
  }

  emitModelObjectEvent() {
    if (this.request.includes("ActualizarDetalleTecnico")) {
      
      this.technicalDetailToUpdate.id_tipo_resolucion = this.resoluciones[this.resolutionIndex].id1;
      this.technicalDetailToUpdate.id_valor_resolucion = this.resoluciones[this.resolutionIndex].id2;
      this.technicalDetailToUpdate.id_relacion_aspecto = this.resoluciones[this.resolutionIndex].id3;
      this.modelObjectEvent.emit(this.technicalDetailToUpdate); this.modalRef.hide(); return;
    }
    this.modelObjectEvent.emit(this.model); this.modalRef.hide();
  }

  public openModal(modalTemplate: TemplateRef<any>) {
    this.modalRef = this.modalService.show(modalTemplate);
  }
}