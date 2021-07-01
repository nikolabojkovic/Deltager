import { Component, Input, OnInit } from '@angular/core';
import { Product } from 'src/app/modules/product/product.model';
import { ProductService } from 'src/app/modules/product/product.service';
import { Container } from '../../container.model';
import { ProductPackage } from '../../product-package.model';

@Component({
    selector: 'app-container',
    templateUrl: './container.component.html',
    styleUrls: ['./container.component.scss']
})
export class ContainerComponent implements OnInit {

    @Input() container: Container;

    displayedColumns: string[] = ['id', 'name', 'type'];
    allProducts: Product[];
    productsToAdd: number[] = [];
    productsToRemove: number[] = [];
    selectedProduct: Product;

    constructor(private productService: ProductService) { }

    ngOnInit(): void {
        this.productService.fetchProducts().subscribe(products => this.allProducts = products);
    }

    addProduct(product: Product): void {
        this.productsToAdd.push(product.id);
        this.container.products = [...this.container.products, new ProductPackage(product.id, product.name, product.type, 0)];
        console.log(this.productsToAdd);
    }

    saveContainer(): void {

    }

    removedProduct(index: number, product): void {
        if (product.productPackageId === 0) {
           const indexByProductId = this.productsToAdd.findIndex(id => id === product.id);
           this.productsToAdd.splice(indexByProductId, 1);

           this.container.products = this.container.products.filter(x => x !== this.container.products[index]);
           console.log(this.productsToAdd);

           return;
        }

        // console.log(index);
        this.productsToRemove.push(product.productPackageId);
        console.log(this.productsToRemove);
        this.container.products = this.container.products.filter(x => x !== this.container.products[index]);
    }
}
