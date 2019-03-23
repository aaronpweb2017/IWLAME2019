import {HttpClient} from '@angular/common/http';
import {Observable, of} from 'rxjs';
import {Injectable} from '@angular/core';

@Injectable({providedIn: 'root'})

export class JSONClientService {
    constructor(private http:HttpClient) { }
    getData():Observable<any> {
        return this.http.get('https://jsonplaceholder.typicode.com/users');
    }
}