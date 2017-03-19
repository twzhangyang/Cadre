﻿import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    templateUrl: './product-detail.component.html'
})
export class ProductDetailComponent implements OnInit {
    public pageTitle: string = 'Product Detail';

    constructor(private _route: ActivatedRoute,
        private _router: Router) {
    }

    public ngOnInit(): void {
        let id = +this._route.snapshot.params['id'];
        this.pageTitle += `:${id}`;
    }

    public onBack(): void {
        this._router.navigate(['/products']);
    }

}