
 
 

 

/// <reference path="Enums.ts" />

declare namespace CadreManagement.WebApi.Models {
	interface Product extends CadreManagement.WebApi.Models.ViewModel<CadreManagement.WebApi.Models.Product> {
		Description: string;
		ImageUrl: string;
		Price: number;
		ProductCode: string;
		ProductId: number;
		ProductName: string;
		ReleaseDate: Date;
		StarRating: number;
	}
	interface ViewModel<T> {
	}
}


