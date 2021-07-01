import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/shared/services/http.service';
import { Observable } from 'rxjs';
import { Container } from './container.model';

@Injectable({
    providedIn: 'root'
})
export class ContainerService {

    private containersUrl = 'containers';

    constructor(private httpService: HttpService) {}

    fetchContainers(): Observable<Container[]> {
        return this.httpService.get(this.containersUrl + '?pageNumber=1&pageSize=10');
    }
}
