import { Component, OnInit } from '@angular/core';
import { SolicitudesService } from 'src/app/services/solicitudes.service';
import { Solicitud } from 'src/app/interfaces/solicitud';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-solicitudes',
  templateUrl: './solicitudes.component.html',
  styleUrls: ['./solicitudes.component.css']
})
export class SolicitudesComponent implements OnInit {
  NoSolicitudes: number;
  solicitudes: Solicitud[];
  id_usuario_solicitud: number;
  NoPaginas: number;
  pageIndexes: number[];
  curerntPage: number = 1;

  constructor(private solicitudesService: SolicitudesService,
    private router: Router, private toastrService: ToastrService) {
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };
  }

  ngOnInit() {
    this.NoSolicitudes = 0;
    this.solicitudes = []
    this.id_usuario_solicitud = 0;
    this.NoPaginas = 0;
    this.pageIndexes = [];
    this.solicitudesService.getNoSolicitudes().subscribe(data => {
      this.NoSolicitudes = Number(data);
      this.NoPaginas = Math.trunc(this.NoSolicitudes / 10);
      if (this.NoSolicitudes % 10 != 0)
        this.NoPaginas = this.NoPaginas + 1;
      for (let i: number = 0; i < this.NoPaginas; i++)
        this.pageIndexes[i] = i + 1;
      this.MuestraPagina(this.curerntPage);
    });

  }

  MuestraPagina(NoPagina: number) {
    this.curerntPage = NoPagina;
    this.solicitudesService.getSolicitudesViewPaginacion(NoPagina).subscribe(data => {
      this.solicitudes = data as Solicitud[];
    });
  }

  AprobarSolicitud(id_usuario_solicitud: number) {
    this.solicitudesService.aprobarSolicitud(id_usuario_solicitud).subscribe(data => {
      let response: boolean = data as boolean;
      if (response) {
        this.toastrService.info("Solicitud aprobada con éxito...");
        this.router.navigate(['/solicitudes']); return;
      }
      this.toastrService.error("Aprobación fallida...");
    });

  }
}