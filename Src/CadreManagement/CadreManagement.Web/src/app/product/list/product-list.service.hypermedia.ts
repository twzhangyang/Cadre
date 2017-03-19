import Product = CadreManagement.WebApi.Models.Product;


import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { CadreApiNavigator } from '../../cadreApiNavigator';

@Injectable()
export class ProductListHyperMediaService {
    constructor(private apiNavigator: CadreApiNavigator) { }

    public getProducts(): Observable<Product.ProductsResource> {
        var products = this.apiNavigator
            .followLink(home => home.resourceLinks.productHome)
            .followLink(productHome => productHome.resourceLinks.products)
            .execute();

        return products;
    }
}