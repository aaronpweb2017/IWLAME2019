import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SpotifyService } from 'src/app/services/spotify.service';

@Component({
  selector: 'app-artista',
  templateUrl: './artista.component.html',
  styles: []
})
export class ArtistaComponent implements OnInit {
  id_artista: string;
  artista: any;
  tracks: any;
  loading: boolean;

  constructor(private spotifyService: SpotifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.loading = true;
    this.id_artista = this.route.snapshot.params['id'];
    this.spotifyService.getArtista(this.id_artista)
      .subscribe(data => {
        //setTimeout(() => {
          this.artista = data;
          this.loading = false;
          this.spotifyService.getTopTracks(this.id_artista)
          .subscribe(data => {
            this.tracks = data;
            console.log(this.tracks);
          });
        //}, 1000);
      });
  }
}