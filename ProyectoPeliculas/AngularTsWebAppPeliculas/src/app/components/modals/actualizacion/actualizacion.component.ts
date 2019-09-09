import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-actualizacion',
  templateUrl: './actualizacion.component.html',
  styleUrls: ['./actualizacion.component.css']
})
export class ActualizacionComponent implements OnInit {
  @Input() request: string;
  @Output() requestResultEvent = new EventEmitter();
  @Input() model: any;
  @Output() modelObjectEvent = new EventEmitter();
  @Input() id_model: number;
  @Output() modelIdEvent = new EventEmitter();
  
  constructor() { }

  ngOnInit() { }

  emitRequestResultEvent(request_result: string) {
    this.requestResultEvent.emit(request_result);
  }

  emitModelObjectEvent(model: any) {
    this.modelObjectEvent.emit(model);
  }

  emitModelIdEvent(id_model: number) {
    this.modelIdEvent.emit(id_model);
  }
}