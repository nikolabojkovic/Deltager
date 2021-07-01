import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContainersComponent } from './components/containers/containers.component';


const routes: Routes = [
  {
    path: '',
    component: ContainersComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ContainerRoutingModule { }
