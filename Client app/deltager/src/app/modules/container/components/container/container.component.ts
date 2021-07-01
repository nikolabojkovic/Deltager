import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Product } from 'src/app/modules/product/product.model';
import { ProductService } from 'src/app/modules/product/product.service';
import { ContainerService } from '../../container.service';
import { Container } from '../../models/container.model';
import { ProductPackage } from '../../models/product-package.model';

@Component({
    selector: 'app-container',
    templateUrl: './container.component.html',
    styleUrls: ['./container.component.scss']
})
export class ContainerComponent implements OnInit {

    constructor(private productService: ProductService,
                private containerService: ContainerService) { }

    @Input() container: Container;
    @Output() refreshContainers = new EventEmitter();

    displayedColumns: string[] = ['id', 'name', 'type'];
    dataSource: ProductPackage[] = [];
    allProducts: Product[];
    productsToAdd: number[] = [];
    productsToRemove: number[] = [];
    selectedProduct: Product;
    isLoading: boolean;
    proccessingMessage: string;

    ngOnInit(): void {
        this.isLoading = true;
        this.proccessingMessage = 'Loading...';
        this.productService.fetchProducts().subscribe(products => {
            this.allProducts = products;
            this.isLoading = false;
        });
        this.dataSource = [...this.container.products];
    }

    addProduct(product: Product): void {
        this.productsToAdd.push(product.id);
        this.dataSource = [...this.dataSource, new ProductPackage(product.id, product.name, product.type, 0)];
    }

    saveContainer(): void {
        this.isLoading = true;
        this.proccessingMessage = 'Saving...';
        this.containerService.updateContainer(this.container.id, this.productsToAdd, this.productsToRemove).subscribe(
            () => {
                this.productsToAdd = [];
                this.productsToRemove = [];
                this.refreshContainers.emit();
                this.isLoading = false;
            });
    }

    removedProduct(index: number, product): void {
        if (product.productPackageId === 0) {
           const indexByProductId = this.productsToAdd.findIndex(id => id === product.id);
           this.productsToAdd.splice(indexByProductId, 1);

           this.dataSource = this.dataSource.filter(x => x !== this.dataSource[index]);

           return;
        }

        this.productsToRemove.push(product.productPackageId);
        this.dataSource = this.dataSource.filter(x => x !== this.dataSource[index]);
    }
}
