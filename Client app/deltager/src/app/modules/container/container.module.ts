import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { ContainersComponent } from './components/containers/containers.component';
import { ContainerRoutingModule } from './container-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
    declarations: [ContainersComponent],
    imports: [
        CommonModule,
        ContainerRoutingModule,
        SharedModule,
        TranslateModule.forChild({ extend: true })
    ],
    exports: [],
    providers: [],
})
export class ContainerModule {}
