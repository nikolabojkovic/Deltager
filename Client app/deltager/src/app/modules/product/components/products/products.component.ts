import { Component, OnInit } from '@angular/core';
import { Product } from '../../product.model';
import { ProductService } from '../../product.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
    selector: 'app-products',
    templateUrl: './products.component.html',
    styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

    constructor(private productService: ProductService,
                private snackBar: MatSnackBar) { }

    dataSource = [ ];
    displayedColumns: string[] = ['id', 'name', 'type'];
    productName: string;
    prouctType: string;
    isLoading: boolean;

    ngOnInit(): void {
        this.fetchProducts();
    }

    addProduct(): void {
        const product = new Product(this.productName, this.prouctType);
        this.productService.creteProduct(product).subscribe({
            next: () => this.fetchProducts(),
            error: (err) => this.snackBar.open('Adding product failed', 'Dismiss')
        });
    }

    fetchProducts(): void {
        this.isLoading = true;
        this.productService.fetchProducts().subscribe({
            next: (containers) => {
                this.dataSource = containers;
                this.isLoading = false;
            },
            error: (err) => {
                this.snackBar.open('Loading products failed', 'Dismiss');
                this.isLoading = false;
            }
        });
    }
}
