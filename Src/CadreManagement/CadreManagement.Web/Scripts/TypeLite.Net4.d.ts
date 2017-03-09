
 
 

 



declare namespace CadreManagement.WebApi.Models {
	interface Product extends CadreManagement.WebApi.Models.ViewModel<CadreManagement.WebApi.Models.Product> {
		description: string;
		imageUrl: string;
		price: number;
		productCode: string;
		productId: number;
		productName: string;
		releaseDate: Date;
		starRating: number;
	}
	interface ViewModel<T> {
	}
}


