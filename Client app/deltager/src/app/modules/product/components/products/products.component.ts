import { Component, OnInit } from '@angular/core';
import { Product } from '../../product.model';
import { ProductService } from '../../product.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'app-products',
    templateUrl: './products.component.html',
    styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

    constructor(private productService: ProductService,
                private snackBar: MatSnackBar,
                private translate: TranslateService) { }

    dataSource = [ ];
    displayedColumns: string[] = ['id', 'name', 'type'];
    productName: string;
    productType: string;
    isLoading: boolean;

    ngOnInit(): void {
        this.fetchProducts();
    }

    addProduct(): void {
        const product = new Product(this.productName, this.productType);
        this.productService.creteProduct(product).subscribe({
            next: () => this.fetchProducts(),
            error: () => this.snackBar.open(this.translate.instant('failure.createProduct'), this.translate.instant('dismiss'))
        });
    }

    fetchProducts(): void {
        this.isLoading = true;
        this.productService.fetchProducts().subscribe({
            next: (containers) => {
                this.dataSource = containers;
                this.isLoading = false;
            },
            error: () => {
                this.snackBar.open(this.translate.instant('failure.loadProducts'), this.translate.instant('dismiss'));
                this.isLoading = false;
            }
        });
    }
}
