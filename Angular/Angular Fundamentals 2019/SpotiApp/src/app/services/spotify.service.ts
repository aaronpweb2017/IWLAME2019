import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { header } from '../global-service';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable()
export class SpotifyService implements OnInit {
  ApiSpotifyURL: string;
  grant_type: string;
  client_id: string;
  client_secret: string;

  constructor(private http: HttpClient) {
    this.ApiSpotifyURL = "https://api.spotify.com/v1/";
  }

  ngOnInit() {
    this.grant_type = "client_credentials";
    this.client_id = "a8be3d65fa2d45d687b988b665b8bbd0";
    this.client_secret = "bbe6aba52be944e7bda0118295f9a92f";
    //POST: https://accounts.spotify.com/api/token
  }

  getNewReleases(): Observable<any> {
    return this.http.get(`${this.ApiSpotifyURL}browse/new-releases`,
      { headers: header }).pipe(map((data: any) => data.albums.items));
  }

  getArtistas(termino: string): Observable<any> {
    return this.http.get(`${this.ApiSpotifyURL}search?q=${termino}&type=artist&limit=10`,
      { headers: header }).pipe(map((data: any) => data.artists.items));
  }

  getArtista(id_artista: string): Observable<any> {
    return this.http.get(`${this.ApiSpotifyURL}artists/${id_artista}`,
      { headers: header });
  }

  getTopTracks(id_artista: string): Observable<any> {
    return this.http.get(`${this.ApiSpotifyURL}artists/${id_artista}/top-tracks?country=us`,
    { headers: header }).pipe(map((data:any) => data.tracks));
  }
}