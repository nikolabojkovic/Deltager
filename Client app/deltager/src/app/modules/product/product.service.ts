import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/shared/services/http.service';
import { Observable } from 'rxjs';
import { Product } from './product.model';

@Injectable({
    providedIn: 'root'
})
export class ProductService {

    private productsUrl = 'products';

    constructor(private httpService: HttpService) {}

    fetchProducts(): Observable<Product[]> {
        return this.httpService.get(this.productsUrl + '?pageNumber=1&pageSize=100');
    }

    creteProduct(product: Product): Observable<void> {
        return this.httpService.post(this.productsUrl, product);
    }
}
