
 
 

 



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


