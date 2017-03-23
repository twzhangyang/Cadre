
 
 

 



declare namespace CadreManagement.Web.HyperMediaApi {
	interface HyperMediaCommand<TResponseType> {
		postUrl: CadreManagement.Web.HyperMediaApi.Link<TResponseType>;
	}
	interface HyperMediaCommandMetaInformation {
		commandClasses: string;
		confirmExecutionQuestion: string;
		description: string;
		hoverMessage: string;
		isAvailable: boolean;
		name: string;
		reasonForBeingUnavailable: string;
		webPageUrl: string;
	}
	interface HyperMediaCommandWithMetainformation<TResponseType> extends CadreManagement.Web.HyperMediaApi.HyperMediaCommand<TResponseType> , CadreManagement.Web.HyperMediaApi.IHyperMediaCommandWithMetaInformation {
		commandMetaInformation: CadreManagement.Web.HyperMediaApi.HyperMediaCommandMetaInformation;
	}
	interface IHyperMediaCommandWithMetaInformation {
		commandMetaInformation: CadreManagement.Web.HyperMediaApi.HyperMediaCommandMetaInformation;
	}
	interface Link<TResource> {
		uri: string;
	}
	interface LinkTemplate1<TTargetResource, TArgument1> {
		urlTemplate: string;
	}
	interface LinkTemplate2<TTargetResource, TArgument1, TArgument2> {
		urlTemplate: string;
	}
	interface LinkTemplate3<TTargetResource, TArgument1, TArgument2, TArgument3> {
		urlTemplate: string;
	}
	interface UrlTemplate1<TArgument1> {
		urlTemplate: string;
	}
	interface UrlTemplate2<TArgument1, TArgument2> {
		urlTemplate: string;
	}
	interface UrlTemplate3<TArgument1, TArgument2, TArgument3> {
		urlTemplate: string;
	}
}
declare namespace CadreManagement.WebApi.Models {
	interface CadreResource {
		resourceLinks: CadreManagement.WebApi.Models.CadreResource.Links;
	}
}
declare namespace CadreManagement.WebApi.Models.CadreResource {
	interface Links {
		productHome: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductHomeResource>;
		self: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.CadreResource>;
	}
}
declare namespace CadreManagement.WebApi.Models.Product {
	interface Product {
		description: string;
		imageUrl: string;
		price: number;
		productCode: string;
		productId: number;
		productName: string;
		releaseDate: Date;
		starRating: number;
	}
	interface ProductAddedCommand extends CadreManagement.Web.HyperMediaApi.HyperMediaCommand<CadreManagement.WebApi.Models.Product.ProductAddedResponse> {
		productId: number;
		productName: string;
	}
	interface ProductAddedResponse {
		product: CadreManagement.WebApi.Models.Product.Product;
		resourceLinks: CadreManagement.WebApi.Models.Product.ProductAddedResponse.Links;
	}
	interface ProductHomeResource {
		resourceCommands: CadreManagement.WebApi.Models.Product.ProductHomeResource.Commands;
		resourceLinks: CadreManagement.WebApi.Models.Product.ProductHomeResource.Links;
	}
	interface ProductRemovedCommand extends CadreManagement.Web.HyperMediaApi.HyperMediaCommand<CadreManagement.WebApi.Models.Product.ProductRemovedResponse> {
		productId: number;
	}
	interface ProductRemovedResponse {
		resourceLinks: CadreManagement.WebApi.Models.Product.ProductRemovedResponse.Links;
		result: boolean;
	}
	interface ProductResource {
		product: CadreManagement.WebApi.Models.Product.Product;
		resourceLinks: CadreManagement.WebApi.Models.Product.ProductResource.Links;
	}
	interface ProductsResource {
		products: CadreManagement.WebApi.Models.Product.Product[];
		resourceLinks: CadreManagement.WebApi.Models.Product.ProductsResource.Links;
	}
}
declare namespace CadreManagement.WebApi.Models.Product.ProductAddedResponse {
	interface Links {
		product: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductResource>;
	}
}
declare namespace CadreManagement.WebApi.Models.Product.ProductHomeResource {
	interface Commands {
		addedCommand: CadreManagement.WebApi.Models.Product.ProductAddedCommand;
		removedCommand: CadreManagement.WebApi.Models.Product.ProductRemovedCommand;
	}
	interface Links {
		product: CadreManagement.Web.HyperMediaApi.LinkTemplate1<CadreManagement.WebApi.Models.Product.ProductResource, number>;
		products: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductsResource>;
		self: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductHomeResource>;
	}
}
declare namespace CadreManagement.WebApi.Models.Product.ProductRemovedResponse {
	interface Links {
		products: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductsResource>;
	}
}
declare namespace CadreManagement.WebApi.Models.Product.ProductResource {
	interface Links {
		self: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductResource>;
	}
}
declare namespace CadreManagement.WebApi.Models.Product.ProductsResource {
	interface Links {
		addProduct: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductAddedResponse>;
		product: CadreManagement.Web.HyperMediaApi.LinkTemplate1<CadreManagement.WebApi.Models.Product.ProductResource, number>;
		removeProduct: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductRemovedResponse>;
		self: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductsResource>;
	}
}


