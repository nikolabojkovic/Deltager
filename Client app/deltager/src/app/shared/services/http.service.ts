import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { environment } from '../../../environments/environment';

@Injectable()
export class HttpService {

    constructor(private http: HttpClient) { }

    get(url): Observable<any> {
        return this.http.get(`${environment.apiUrl}${url}`, this.headers()).pipe(catchError((err) => {
            console.log(err);
            throw err;
        }));
    }

    post(url, data): Observable<any> {
        return this.http.post(`${environment.apiUrl}${url}`, JSON.stringify(data), this.headers()).pipe(catchError((err) => {
            console.log(err);
            throw err;
        }));
    }

    put(url, data): Observable<any> {
        return this.http.put(`${environment.apiUrl}${url}`, JSON.stringify(data), this.headers()).pipe(catchError((err) => {
            console.log(err);
            throw err;
        }));
    }

    delete(url): Observable<any> {
        return this.http.delete(`${environment.apiUrl}${url}`, this.headers()).pipe(catchError((err) => {
            console.log(err);
            throw err;
        }));
    }

    private headers(): any {
        return {
            headers: new HttpHeaders({'Content-Type': 'application/json'})
          };
    }
}
