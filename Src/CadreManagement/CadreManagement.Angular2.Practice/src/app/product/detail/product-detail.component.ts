import Product=CadreManagement.WebApi.Models.Product;

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductHyperMediaService} from './../product.service.hypermedia';

@Component({
    templateUrl: './product-detail.component.html'
})
export class ProductDetailComponent implements OnInit {
     pageTitle: string = 'Product Detail';
     productResource:Product.ProductResource;

    constructor(private route: ActivatedRoute,
        private rotuer: Router,
        private productHyperMediaService: ProductHyperMediaService) {
    }

     ngOnInit(): void {
        let id = +this.route.snapshot.params['id'];
        this.pageTitle += `:${id}`;

        this.productHyperMediaService
            .getProduct(id)
            .subscribe(product=>this.productResource=product);
     }

     onBack(): void {
        this.rotuer.navigate(['/products']);
    }

}