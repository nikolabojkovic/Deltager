import { Component, OnInit } from '@angular/core';
import { Product } from '../../product.model';
import { ProductService } from '../../product.service';

@Component({
    selector: 'app-products',
    templateUrl: './products.component.html',
    styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

    dataSource = [ ];
    displayedColumns: string[] = ['id', 'name', 'type'];
    productName: string;
    prouctType: string;

    constructor(private productService: ProductService) { }

    ngOnInit(): void {
        this.productService.fetchProducts().subscribe((containers) => this.dataSource = containers);
    }

    addProduct(): void {
        const product = new Product(this.productName, this.prouctType);
        this.productService.creteProduct(product).subscribe(() =>
            this.productService.fetchProducts().subscribe((containers) => this.dataSource = containers));
    }
}
