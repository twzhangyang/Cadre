
 
 

 

/// <reference path="Enums.ts" />

declare namespace CadreManagement.Web.HyperMediaApi {
	interface HyperMediaCommand<TResponseType> {
		PostUrl: CadreManagement.Web.HyperMediaApi.Link<TResponseType>;
	}
	interface HyperMediaCommandMetaInformation {
		CommandClasses: string;
		ConfirmExecutionQuestion: string;
		Description: string;
		HoverMessage: string;
		IsAvailable: boolean;
		Name: string;
		ReasonForBeingUnavailable: string;
		WebPageUrl: string;
	}
	interface HyperMediaCommandWithMetainformation<TResponseType> extends CadreManagement.Web.HyperMediaApi.HyperMediaCommand<TResponseType> , CadreManagement.Web.HyperMediaApi.IHyperMediaCommandWithMetaInformation {
		CommandMetaInformation: CadreManagement.Web.HyperMediaApi.HyperMediaCommandMetaInformation;
	}
	interface IHyperMediaCommandWithMetaInformation {
		CommandMetaInformation: CadreManagement.Web.HyperMediaApi.HyperMediaCommandMetaInformation;
	}
	interface Link<TResource> {
		Uri: string;
	}
	interface LinkTemplate1<TTargetResource, TArgument1> {
		UrlTemplate: string;
	}
	interface LinkTemplate2<TTargetResource, TArgument1, TArgument2> {
		UrlTemplate: string;
	}
	interface LinkTemplate3<TTargetResource, TArgument1, TArgument2, TArgument3> {
		UrlTemplate: string;
	}
	interface UrlTemplate1<TArgument1> {
		UrlTemplate: string;
	}
	interface UrlTemplate2<TArgument1, TArgument2> {
		UrlTemplate: string;
	}
	interface UrlTemplate3<TArgument1, TArgument2, TArgument3> {
		UrlTemplate: string;
	}
}
declare namespace CadreManagement.WebApi.Models {
	interface CadreResource {
		ResourceLinks: CadreManagement.WebApi.Models.CadreResource.Links;
	}
}
declare namespace CadreManagement.WebApi.Models.CadreResource {
	interface Links {
		ProductHome: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductHomeResource>;
		Self: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.CadreResource>;
	}
}
declare namespace CadreManagement.WebApi.Models.Product {
	interface Product {
		Description: string;
		ImageUrl: string;
		Price: number;
		ProductCode: string;
		ProductId: number;
		ProductName: string;
		ReleaseDate: Date;
		StarRating: number;
	}
	interface ProductAddedCommand extends CadreManagement.Web.HyperMediaApi.HyperMediaCommand<CadreManagement.WebApi.Models.Product.ProductAddedResponse> {
		ProductId: number;
		ProductName: string;
	}
	interface ProductAddedResponse {
		Product: CadreManagement.WebApi.Models.Product.Product;
		ResourceLinks: CadreManagement.WebApi.Models.Product.ProductAddedResponse.Links;
	}
	interface ProductHomeResource {
		ResourceCommands: CadreManagement.WebApi.Models.Product.ProductHomeResource.Commands;
		ResourceLinks: CadreManagement.WebApi.Models.Product.ProductHomeResource.Links;
	}
	interface ProductRemovedCommand extends CadreManagement.Web.HyperMediaApi.HyperMediaCommand<CadreManagement.WebApi.Models.Product.ProductRemovedResponse> {
		ProductId: number;
	}
	interface ProductRemovedResponse {
		ResourceLinks: CadreManagement.WebApi.Models.Product.ProductRemovedResponse.Links;
		Result: boolean;
	}
	interface ProductResource {
		Product: CadreManagement.WebApi.Models.Product.Product;
		ResourceLinks: CadreManagement.WebApi.Models.Product.ProductResource.Links;
	}
	interface ProductsResource {
		Products: CadreManagement.WebApi.Models.Product.Product[];
		ResourceLinks: CadreManagement.WebApi.Models.Product.ProductsResource.Links;
	}
}
declare namespace CadreManagement.WebApi.Models.Product.ProductAddedResponse {
	interface Links {
		Product: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductResource>;
	}
}
declare namespace CadreManagement.WebApi.Models.Product.ProductHomeResource {
	interface Commands {
		AddedCommand: CadreManagement.WebApi.Models.Product.ProductAddedCommand;
		RemovedCommand: CadreManagement.WebApi.Models.Product.ProductRemovedCommand;
	}
	interface Links {
		Product: CadreManagement.Web.HyperMediaApi.LinkTemplate1<CadreManagement.WebApi.Models.Product.ProductResource, number>;
		Products: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductsResource>;
		Self: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductHomeResource>;
	}
}
declare namespace CadreManagement.WebApi.Models.Product.ProductRemovedResponse {
	interface Links {
		Products: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductsResource>;
	}
}
declare namespace CadreManagement.WebApi.Models.Product.ProductResource {
	interface Links {
		Self: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductResource>;
	}
}
declare namespace CadreManagement.WebApi.Models.Product.ProductsResource {
	interface Links {
		AddProduct: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductAddedResponse>;
		Product: CadreManagement.Web.HyperMediaApi.LinkTemplate1<CadreManagement.WebApi.Models.Product.ProductResource, number>;
		RemoveProduct: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductRemovedResponse>;
		Self: CadreManagement.Web.HyperMediaApi.Link<CadreManagement.WebApi.Models.Product.ProductsResource>;
	}
}


