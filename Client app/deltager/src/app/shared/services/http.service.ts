import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';

@Injectable()
export class HttpService {

    constructor(private http: HttpClient) { }

    get(url): Observable<any> {
        return this.http.get(`${environment.apiUrl}${url}`, this.headers());
    }

    post(url, data): Observable<any> {
        return this.http.post(`${environment.apiUrl}${url}`, JSON.stringify(data), this.headers());
    }

    put(url, data): Observable<any> {
        return this.http.put(`${environment.apiUrl}${url}`, JSON.stringify(data), this.headers());
    }

    delete(url): Observable<any> {
        return this.http.delete(`${environment.apiUrl}${url}`, this.headers());
    }

    private headers(): any {
        return {
            headers: new HttpHeaders({'Content-Type': 'application/json'})
          };
    }
}
