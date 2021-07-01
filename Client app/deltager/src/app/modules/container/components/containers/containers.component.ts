import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Container } from '../../container.model';
import { ContainerService } from '../../container.service';

@Component({
    selector: 'app-containers',
    templateUrl: './containers.component.html',
    styleUrls: ['./containers.component.scss']
})
export class ContainersComponent implements OnInit {
    constructor(
        private containerService: ContainerService,
        private router: Router) { }

    dataSource: Container[] = [];
    displayedColumns: string[] = ['id', 'name'];
    containerToEdit: Container;

    ngOnInit(): void {
        this.containerService.fetchContainers().subscribe((containers) => this.dataSource = containers);
    }

    openContainer(container: any): void {
        this.containerToEdit = container;
    }
}
