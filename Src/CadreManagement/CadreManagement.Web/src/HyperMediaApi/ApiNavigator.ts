import { Http, Response } from '@angular/http';
import { Injectable } from '@angular/core';


declare namespace  Hypermedia.HyperMediaApi {
    import HyperMediaApi = CadreManagement.Web.HyperMediaApi;


    @Injectable()
    export class LinkNavigator<TResource> {
        constructor(
             _http:Http,
            rootLink: HyperMediaApi.Link<TResource>) {
        }

        //followLink(): SubLinkNavigator {
        //    (selectLink: (self: TResource) => HyperMediaApi.Link<TTargetResource>) => {
        //        return new SubLinkNavigator<TTargetResource, TResource>(this._http, this.$q, this.execute, selectLink);
        //}

        //execute = () => {
        //    var defer = this.$q.defer<TResource>();
        //    this.$http.get<TResource>(this.rootLink.uri)
        //        .then(
        //        response => defer.resolve(response.data),
        //        response => defer.reject(response));
        //    return defer.promise;
        //}

        //private createDeferred = <TResult>(link: HyperMediaApi.Link<TResult>) => this.$q.defer<TResult>();

        //postCommand = <TResponse>(command: HyperMediaApi.HyperMediaCommand<TResponse>) => {
        //    return this.$http.post<TResponse>(command.postUrl.uri, command)
        //        .then(
        //        response => response.data,
        //        response => {
        //            this.errorMessageDialog.showMessage(response.data);
        //            return this.$q.reject(response.data);
        //        });
        //}
    }

    //export class SubLinkNavigator<TResource, TParentResource> {
    //    constructor(
    //        private $http: ng.IHttpService,
    //        private $q: ng.IQService,
    //        private parent: () => ng.IPromise<TParentResource>,
    //        private navigator: (parentResource: TParentResource) => HyperMediaApi.Link<TResource>) {
    //    }

        //followLink = <TTargetResource>(linkSelectr: (self: TResource) => HyperMediaApi.Link<TTargetResource>) => {
        //    return new SubLinkNavigator<TTargetResource, TResource>(this.$http, this.$q, <any>this.execute, <any>linkSelectr);//<any> cast is to get rid of incorrect error reported by Resharper
        //}

        //followLinkTemplate = <TTargetResource, TArgument>(linkSelector: (self: TResource) => HyperMediaApi.LinkTemplate1<TTargetResource, TArgument>, argument: TArgument) => {
        //    var standardLinkSelector: (self: TResource) => HyperMediaApi.Link<TTargetResource>
        //        = resource => {
        //            return { uri: linkSelector(resource).urlTemplate.replace("{0}", <string><any>argument) };
        //        }

        //    return new SubLinkNavigator<TTargetResource, TResource>(this.$http, this.$q, <any>this.execute, <any>standardLinkSelector);//<any> cast is to get rid of incorrect error reported by Resharper
        //}

        //followLinkTemplate2 = <TTargetResource, TArgument, TArgument2>(linkSelector: (self: TResource) => HyperMediaApi.LinkTemplate2<TTargetResource, TArgument, TArgument2>, argument: TArgument, argument2: TArgument2) => {
        //    var standardLinkSelector: (self: TResource) => HyperMediaApi.Link<TTargetResource>
        //        = resource => {
        //            return { uri: linkSelector(resource).urlTemplate.replace("{0}", <string><any>argument).replace("{1}", <string><any>argument2) };
        //        }

        //    return new SubLinkNavigator<TTargetResource, TResource>(this.$http, this.$q, <any>this.execute, <any>standardLinkSelector);//<any> cast is to get rid of incorrect error reported by Resharper
        //}

        //execute = () => {
        //    var defer = this.$q.defer<TResource>();
        //    this.parent()
        //        .then(parentResponse => {
        //            var myLink = this.navigator(parentResponse);
        //            this.$http.get<TResource>(myLink.uri)
        //                .then(
        //                response => defer.resolve(response.data),
        //                response => defer.reject(response));
        //        });
        //    return defer.promise;
        //};
    //}


}


