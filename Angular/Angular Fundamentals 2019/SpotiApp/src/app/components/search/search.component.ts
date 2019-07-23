import { Component, OnInit } from '@angular/core';
import { SpotifyService } from 'src/app/services/spotify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styles: []
})
export class SearchComponent implements OnInit {
  termino: string;
  artists: any[];
  loading: boolean;

  constructor(private spotifyService: SpotifyService, private router: Router) { }

  ngOnInit() {
    this.termino = "";
  }

  buscar() {
    this.artists = []; this.loading = true;
    this.spotifyService.getArtistas(this.termino).subscribe(data => {
      setTimeout(() => {
        this.artists = data;
        this.loading = false;
      }, 1000);
    });
  }

  verArtista(artist: any) {
    let id: number = artist.id
    this.router.navigate(['/artista', id]);
  }
}