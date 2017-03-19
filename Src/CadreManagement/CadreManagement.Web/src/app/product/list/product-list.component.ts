import Product = CadreManagement.WebApi.Models.Product;

import { Component, OnInit } from '@angular/core';
import { ProductListService } from './product-list.service';
import {ProductListHyperMediaService} from './product-list.service.hypermedia';

@Component({
    templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
    public pageTitle: string = 'Product List';
    public imageWidth: number = 50;
    public imageMargin: number = 2;
    public showImage: boolean = false;
    public listFilter: string;
    public errorMessage: string;

    public products: Product.Product[];

    constructor(private _productListService: ProductListService, private productHyperMediaService:ProductListHyperMediaService) {

    }

    public toggleImage(): void {
        this.showImage = !this.showImage;
    }

    public ngOnInit(): void {
        //this._productListService.getProducts()
        //    .subscribe(productsResource => this.products = productsResource.products,
        //        error => this.errorMessage = <any>error);

        this.productHyperMediaService.getProducts()
            .subscribe(productsResource => this.products = productsResource.products);
    }

    public onRatingClicked(message: string): void {
        this.pageTitle = 'Product List: ' + message;
    }

}