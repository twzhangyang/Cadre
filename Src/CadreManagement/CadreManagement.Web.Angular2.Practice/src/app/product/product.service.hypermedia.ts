import Product = CadreManagement.WebApi.Models.Product;


import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { CadreApiNavigator } from '../cadreApiNavigator';
import Link = CadreManagement.Web.HyperMediaApi.Link;

@Injectable()
export class ProductHyperMediaService {
    constructor(private apiNavigator: CadreApiNavigator) { }

    getProducts(): Observable<Product.ProductsResource> {
        const products = this.apiNavigator
            .followLink(home => home.resourceLinks.productHome)
            .followLink(productHome => productHome.resourceLinks.products)
            .execute();

        return products;
    }

    getProduct(id: number): Observable<Product.ProductResource> {
        const product = this.apiNavigator
            .followLink(home => home.resourceLinks.productHome)
            .followLinkTemplate((productHome: Product.ProductHomeResource) => productHome.resourceLinks.product, id)
            .execute();

        return product;
    }
}