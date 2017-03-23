import ProductsResource = CadreManagement.WebApi.Models.Product.ProductsResource;

import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';

@Injectable()
export class ProductListService {
    private _productUrl = 'http://cadreapi.local.com/api/product/products';

    constructor(private http: Http) {
    }

    public getProducts(): Observable<ProductsResource> {
        return this.http.get(this._productUrl)
            .map((response: Response) => <ProductsResource>response.json())
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}