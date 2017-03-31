import Product = CadreManagement.WebApi.Models.Product;

import { Component, OnInit } from '@angular/core';
import { ProductListService } from './product-list.service';
import { ProductHyperMediaService } from './../product.service.hypermedia';
import { CadreApiNavigator } from './../../hyper-media/cadreApiNavigator';
import 'rxjs/add/operator/switchMap';

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

    constructor(private productListService: ProductListService, private cadreApiNavigator: CadreApiNavigator) {

    }

    toggleImage(): void {
        this.showImage = !this.showImage;
    }

    ngOnInit(): void {
        this.cadreApiNavigator
            .followLink(cadreHomeResource => cadreHomeResource.resourceLinks.productHome)
            .followLink(productHomeResource => productHomeResource.resourceLinks.products)
            .execute()
            .subscribe((products: Product.ProductsResource) => this.products = products.products);

        this.cadreApiNavigator
            .followLink(cadreHomeResource => cadreHomeResource.resourceLinks.productHome)
            .execute()
            .subscribe((productHomeResource:Product.ProductHomeResource) => this.productHomeResource = productHomeResource);
    }

    onAdd(): void {
        var commond = this.productHomeResource.resourceCommands.addedCommand;
        commond.productName = "test name";
        commond.productCode = "product code";

        this.cadreApiNavigator.postCommand(commond)
            .subscribe((response: Product.ProductAddedResponse) => this.products.push(response.product));
    }

    onRatingClicked(message: string): void {
        this.pageTitle = 'Product List: ' + message;
    }

}