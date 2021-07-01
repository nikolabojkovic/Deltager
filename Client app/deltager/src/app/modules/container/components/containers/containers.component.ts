import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Container } from '../../models/container.model';
import { ContainerService } from '../../container.service';
import { ContainerComponent } from '../container/container.component';

@Component({
    selector: 'app-containers',
    templateUrl: './containers.component.html',
    styleUrls: ['./containers.component.scss']
})
export class ContainersComponent implements OnInit {

    @ViewChild(ContainerComponent)
    private containerComponent: ContainerComponent;

    constructor(
        private containerService: ContainerService,
        private router: Router) { }

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
            error: (err) => console.log(err)
        });
    }
}
