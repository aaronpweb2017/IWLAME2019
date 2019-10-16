import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { Pelicula } from 'src/app/interfaces/pelicula';
import { Router, ActivatedRoute } from '@angular/router';
import { VDetalleTecnico } from 'src/app/interfaces/views/v-detalle-tecnico';
import { VistasService } from 'src/app/services/vistas.service';
import { PeliculasService } from 'src/app/services/peliculas.service';

@Component({
  selector: 'app-detalles-pelicula',
  templateUrl: './detalles-pelicula.component.html',
  styleUrls: ['./detalles-pelicula.component.css']
})
export class DetallesPeliculaComponent implements OnInit {
  id_pelicula: number;
  pelicula: Pelicula;
  detalleTecnico: VDetalleTecnico;

  constructor(private peliculasService: PeliculasService, private vistasService: VistasService,
    private router: Router, private route: ActivatedRoute, private toastrService: ToastrService) {
  }

  ngOnInit() {
    this.id_pelicula = Number(this.route.snapshot.paramMap.get('id_pelicula'));

    this.peliculasService.getPelicula(this.id_pelicula).subscribe(
      response => {
        if (response[0]) {
          this.pelicula = response[0]; return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
    this.vistasService.getVistaDetalleTecnicoPelicula(this.id_pelicula).subscribe(
      response => {
        if (response[0]) {
          this.detalleTecnico = response[0]; return;
        }
        this.toastrService.error(response[1]);
      }, error => {
        this.toastrService.error(error.message);
      });
  }
}