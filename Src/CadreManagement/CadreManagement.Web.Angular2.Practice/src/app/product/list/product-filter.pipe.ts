import Product=CadreManagement.WebApi.Models.Product;

import { PipeTransform, Pipe } from '@angular/core';


@Pipe({
    name: 'productFilter'
})
export class ProductFilterPipe implements PipeTransform {

    transform(value: Product.Product[], filterBy: string): Product.Product[] {
        filterBy = filterBy ? filterBy.toLocaleLowerCase() : null;
        return filterBy ? value.filter((product: Product.Product) =>
            product.productName.toLocaleLowerCase().indexOf(filterBy) !== -1) : value;
    }
}