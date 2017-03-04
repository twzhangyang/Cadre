import { Component, OnInit } from '@angular/core';
import { IProduct } from './../product';
import { ProductListService } from './product-list.service';

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

    public products: IProduct[];

    constructor(private _productListService: ProductListService) {

    }

    public toggleImage(): void {
        this.showImage = !this.showImage;
    }

    public ngOnInit(): void {
        this._productListService.getProducts()
            .subscribe(products => this.products = products,
                error => this.errorMessage = <any>error);
    }

    public onRatingClicked(message: string): void {
        this.pageTitle = 'Product List: ' + message;
    }

}