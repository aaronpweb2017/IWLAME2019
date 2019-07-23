import { Component, OnInit } from '@angular/core';
import { SpotifyService } from 'src/app/services/spotify.service';
import { GlobalService } from 'src/app/global-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit {
  token: string;
  releases: any;
  loading: boolean;

  constructor(private spotifyService: SpotifyService,
    private globalService: GlobalService, private router: Router) { }

  ngOnInit() {
    this.token = "BQDP1AILWPvPg8kyrWlgOY8w70yJ8QyQtO4-gPfte1UqrAlbAKF5ZfAboyGklK5AwCDIWhRBkkk1tGyPcHE";
    this.globalService.SetTokenValue(this.token); this.releases = []; this.loading = true;
    this.spotifyService.getNewReleases().subscribe(data => {
      setTimeout(() => {
        this.releases = data;
        this.loading = false;
      }, 1000);
    });
  }

  verArtista(release: any, index: number) {
    let id: number = release.artists[index].id
    this.router.navigate(['/artista', id]);
  }
}