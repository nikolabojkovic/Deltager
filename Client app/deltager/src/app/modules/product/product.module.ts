import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';

import { ProductsComponent } from './components/products/products.component';
import { ProductRoutingModule } from './product-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        ProductsComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        SharedModule,
        ProductRoutingModule,
        TranslateModule.forChild({ extend: true }),
    ]
})
export class ProductModule { }
