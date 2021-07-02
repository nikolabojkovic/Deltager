import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TranslateService } from '@ngx-translate/core';
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
                private containerService: ContainerService,
                private snackBar: MatSnackBar,
                private translate: TranslateService) { }

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
        this.proccessingMessage = 'loading';
        this.productService.fetchProducts().subscribe({
            next: products => {
                this.allProducts = products;
                this.isLoading = false;
            },
            error: () => this.snackBar.open(this.translate.instant('failure.loadContainers'), this.translate.instant('dismiss'))
        });
        this.dataSource = [...this.container.products];
    }

    addProduct(product: Product): void {
        this.productsToAdd.push(product.id);
        this.dataSource = [...this.dataSource, new ProductPackage(product.id, product.name, product.type, 0)];
    }

    saveContainer(): void {
        this.isLoading = true;
        this.proccessingMessage = 'saving';
        this.containerService.updateContainer(this.container.id, this.productsToAdd, this.productsToRemove).subscribe({
            next : () => {
                this.productsToAdd = [];
                this.productsToRemove = [];
                this.refreshContainers.emit();
                this.isLoading = false;
            },
            error: () => this.snackBar.open(this.translate.instant('failure.updateContainer'), this.translate.instant('dismiss'))
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
