import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { Pelicula } from 'src/app/interfaces/pelicula';
import { Router, ActivatedRoute } from '@angular/router';
import { VDetalleTecnico } from 'src/app/interfaces/views/v-detalle-tecnico';
import { VistasService } from 'src/app/services/vistas.service';

@Component({
  selector: 'app-detalles-pelicula',
  templateUrl: './detalles-pelicula.component.html',
  styleUrls: ['./detalles-pelicula.component.css']
})
export class DetallesPeliculaComponent implements OnInit {
  pelicula: Pelicula;
  detalleTecnico: VDetalleTecnico;

  constructor(private vistasService: VistasService, private router: Router,
    private route: ActivatedRoute, private toastrService: ToastrService) {
  }

  ngOnInit() {
    this.pelicula = {
      id_pelicula: Number(this.route.snapshot.paramMap.get('id_pelicula')),
      nombre_pelicula: this.route.snapshot.paramMap.get('nombre_pelicula'),
      fecha_estreno: new Date(this.route.snapshot.paramMap.get('fecha_estreno')),
      presupuesto: Number(this.route.snapshot.paramMap.get('presupuesto')),
      recaudacion: Number(this.route.snapshot.paramMap.get('recaudacion')),
      sinopsis: this.route.snapshot.paramMap.get('sinopsis'),
      calificacion: Number(this.route.snapshot.paramMap.get('calificacion')),
      directores: this.route.snapshot.paramMap.get('directores'),
      generos: this.route.snapshot.paramMap.get('generos'),
      idiomas: this.route.snapshot.paramMap.get('idiomas'),
      productoras: this.route.snapshot.paramMap.get('productoras'),
      actores: this.route.snapshot.paramMap.get('actores'),
      pais: this.route.snapshot.paramMap.get('pais'),
      audios: this.route.snapshot.paramMap.get('audios'),
      subtitulos: this.route.snapshot.paramMap.get('subtitulos'),
      peso: Number(this.route.snapshot.paramMap.get('peso')),
      id_detalle: Number(this.route.snapshot.paramMap.get('id_detalle')),
      rutaImagen: this.route.snapshot.paramMap.get('rutaImagen')
    }
    this.vistasService.getVistaDetalleTecnicoPelicula(this.pelicula.id_pelicula).subscribe(
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