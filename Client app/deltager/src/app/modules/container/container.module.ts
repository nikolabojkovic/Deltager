import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { HttpService } from 'src/app/shared/services/http.service';

import { ContainersComponent } from './components/containers/containers.component';
import { ContainerRoutingModule } from './container-routing.module';
import { ContainerComponent } from './components/container/container.component';

@NgModule({
    declarations: [
        ContainersComponent,
        ContainerComponent
    ],
    imports: [
        CommonModule,
        ContainerRoutingModule,
        SharedModule,
        TranslateModule.forChild({ extend: true })
    ],
    exports: [],
    providers: [
        HttpService
    ],
})
export class ContainerModule {}
