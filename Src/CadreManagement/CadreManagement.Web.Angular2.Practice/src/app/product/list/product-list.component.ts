import Product = CadreManagement.WebApi.Models.Product;

import { Component, OnInit } from '@angular/core';
import { ProductListService } from './product-list.service';
import { ProductHyperMediaService } from './../product.service.hypermedia';
import { CadreApiNavigator } from './../../cadreApiNavigator';

@Component({
    templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
    pageTitle: string = 'Product List';
    imageWidth: number = 50;
    imageMargin: number = 2;
    showImage: boolean = false;
    listFilter: string;
    errorMessage: string;
    products: Product.Product[];
    productHomeResource: Product.ProductHomeResource;

    constructor(private _productListService: ProductListService, private productHyperMediaService: ProductHyperMediaService,private apiNavigator:CadreApiNavigator) {

    }

    toggleImage(): void {
        this.showImage = !this.showImage;
    }

    ngOnInit(): void {

        //this._productListService.getProducts()
        //    .subscribe(productsResource => this.products = productsResource.products,
        //        error => this.errorMessage = <any>error);

        this.productHyperMediaService.getProducts()
            .subscribe(productsResource => this.products = productsResource.products);

        this.apiNavigator
        .followLink(home=>home.resourceLinks.productHome)
        .execute()
        .subscribe(productHome=>this.productHomeResource=productHome);
    }

    onAdd(): void {
        if(this.productHomeResource.resourceCommands.addedCommand)
        {
            this.productHomeResource.resourceCommands.addedCommand.productName="test name";
            this.apiNavigator.postCommand(this.productHomeResource.resourceCommands.addedCommand)
            .subscribe((response:Product.ProductAddedResponse)=>this.products.push(response.product));
        }
    }

    onRatingClicked(message: string): void {
        this.pageTitle = 'Product List: ' + message;
    }

}