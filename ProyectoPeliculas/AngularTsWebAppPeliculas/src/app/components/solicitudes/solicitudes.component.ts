import { Component, OnInit } from '@angular/core';
import { SolicitudesService } from 'src/app/services/solicitudes.service';
import { Solicitud } from 'src/app/interfaces/solicitud';
import { VistasService } from 'src/app/services/vistas.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-solicitudes',
  templateUrl: './solicitudes.component.html',
  styleUrls: []
})
export class SolicitudesComponent implements OnInit {
  currentPage: any;
  paginationConfig: any;
  solicitudes: Solicitud[];

  constructor(private solicitudesService: SolicitudesService, private vistasService: VistasService,
    private router: Router, private route: ActivatedRoute, private toastrService: ToastrService) {
    this.currentPage = this.route.snapshot.params['pg'];
    this.paginationConfig = { itemsPerPage: 0, currentPage: 0, totalItems: 0 };
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };
  }

  ngOnInit() {
    this.vistasService.getSolicitudesVista().subscribe(solicitudes => {
      this.solicitudes = solicitudes;
      this.paginationConfig = {
        itemsPerPage: 5,
        currentPage: this.currentPage,
        totalItems: this.solicitudes.length
      };
    });
  }

  AprobarSolicitud(id_usuario_solicitud: number) {
    this.solicitudesService.aprobarSolicitud(id_usuario_solicitud).subscribe(response => {
      if (response) {
        this.toastrService.info("Solicitud aprobada con éxito...");
        this.router.navigate(['/solicitudes', this.currentPage]); return;
      }
      this.toastrService.error("Aprobación fallida...");
    });
  }

  pageChanged(event) {
    this.currentPage = event;
    this.paginationConfig.currentPage = this.currentPage;
    this.router.navigate(['/solicitudes', this.currentPage]);
  }
}