import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { apiURL } from '../global.service';
import { Pelicula } from '../interfaces/pelicula';

@Injectable()
export class PeliculasService {
    private ApiPeliculasURL: string;
    private ApiGetPeliculasURL: string;

    constructor(private http: HttpClient) {
        this.ApiPeliculasURL = apiURL + "/Peliculas";
    }

    getPeliculas(): Observable<Pelicula[]> {
        this.ApiGetPeliculasURL = this.ApiPeliculasURL + "/GetPeliculas";
        return this.http.get(this.ApiGetPeliculasURL
        ).pipe(map((data: any) => data as Pelicula[]));
    }
}