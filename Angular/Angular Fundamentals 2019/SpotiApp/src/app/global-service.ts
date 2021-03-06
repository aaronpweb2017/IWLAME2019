import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
export let token: string = "";
export let header: HttpHeaders;

@Injectable()
export class GlobalService {
    SetTokenValue(tokenValue: string) {
        token = "Bearer " + tokenValue;
        header = new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': token
        });
    }
}