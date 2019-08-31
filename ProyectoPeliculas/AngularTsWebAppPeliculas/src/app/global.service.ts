import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
export let token: string = "";
export let header: HttpHeaders;
export let logged: boolean = false;

@Injectable()
export class GlobalService {
    SetTokenValue(tokenValue: string) {
        token = "Bearer " + tokenValue;
        header = new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': token
        });
    }

    getToken(): string {
        return token;
    }

    getHeader(): HttpHeaders {
        return header;
    }

    setLoggedValue(isLogged: boolean) {
        logged = isLogged; 
    }

    getLoggedValue(): boolean {
        return logged;
    }
}