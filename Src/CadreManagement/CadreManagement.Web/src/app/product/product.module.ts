﻿import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { SharedModule } from './../shared/shared.module';

import { ProductListComponent } from './list/product-list.component';
import { ProductDetailComponent } from './detail/product-detail.component';
import { ProductListService } from './list/product-list.service';
import { ProductDetailGuardService } from './detail/product-detail-guard.service';
import { ProductFilterPipe } from './list/product-filter.pipe';
import { ProductHyperMediaService } from './product.service.hypermedia';

@NgModule({
    declarations: [
        ProductListComponent,
        ProductDetailComponent,
        ProductFilterPipe
    ],
    imports: [
        FormsModule,
        BrowserModule,
        RouterModule.forChild([
            { path: 'products', component: ProductListComponent },
            { path: 'product/:id', component: ProductDetailComponent, canActivate: [ProductDetailGuardService] }
        ]),
        SharedModule
    ],
    providers: [
        ProductListService,
        ProductHyperMediaService,
        ProductDetailGuardService
    ]
})
export class ProductModule { }