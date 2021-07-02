import { Component, OnInit, ViewChild } from '@angular/core';
import { Container } from '../../models/container.model';
import { ContainerService } from '../../container.service';
import { ContainerComponent } from '../container/container.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'app-containers',
    templateUrl: './containers.component.html',
    styleUrls: ['./containers.component.scss']
})
export class ContainersComponent implements OnInit {

    @ViewChild(ContainerComponent)
    private containerComponent: ContainerComponent;

    constructor(private containerService: ContainerService,
                private snackBar: MatSnackBar,
                private translate: TranslateService) { }

    dataSource: Container[] = [];
    displayedColumns: string[] = ['id', 'name'];
    containerToEdit: Container;
    isLoading: boolean;

    ngOnInit(): void {
        this.fetchContainers();
    }

    openContainer(container: Container): void {
        this.containerToEdit = container;

        if (this.containerComponent) {
            this.containerComponent.productsToAdd = [];
            this.containerComponent.productsToRemove = [];
            this.containerComponent.dataSource = container.products;
        }
    }

    fetchContainers(): void {
        this.isLoading = true;
        this.containerService.fetchContainers().subscribe({
            next: (containers) => {
                this.dataSource = containers;
                this.isLoading = false;
            },
            error: () => this.snackBar.open(this.translate.instant('failure.loadContainers'),
                                               this.translate.instant('dismiss'))
        });
    }
}
