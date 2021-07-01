import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: 'containers',
    loadChildren: () => import('./modules/container/container.module').then((m) => m.ContainerModule),
  },
  {
    path: 'products',
    loadChildren: () => import('./modules/product/product.module').then((m) => m.ProductModule),
  },
  {
    path: '**',
    redirectTo: 'containers',
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
