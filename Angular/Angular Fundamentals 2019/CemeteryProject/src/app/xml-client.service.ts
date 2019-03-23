import {HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class XMLClientService {
    constructor(private http:HttpClient) { }
    getTextFile(filename:string):Observable<string> {
        return this.http.get(filename,{responseType:'text'});
    }
}