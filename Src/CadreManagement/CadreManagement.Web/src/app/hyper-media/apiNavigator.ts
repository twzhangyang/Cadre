import HyperMediaApi = CadreManagement.Web.HyperMediaApi;
import { Http, Response, Headers } from '@angular/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { NextObserver } from 'rxjs/Observer';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/switchMap';

export class SubLinkNavigator<TResource, TParentResource> {
    constructor(
        private http: Http,
        private parent: () => Observable<TParentResource>,
        private navigator: (parentResource: TParentResource) => HyperMediaApi.Link<TResource>) {
    }

    followLink = <TTargetResource>(linkSelectr: (self: TResource) => HyperMediaApi.Link<TTargetResource>) => {
        return new SubLinkNavigator<TTargetResource, TResource>(this.http, <any>this.execute, <any>linkSelectr);
    }

    followLinkTemplate = <TTargetResource, TArgument>(linkSelector: (self: TResource) => HyperMediaApi.LinkTemplate1<TTargetResource, TArgument>, argument: TArgument) => {
        var standardLinkSelector: (self: TResource) => HyperMediaApi.Link<TTargetResource>
            = resource => {
                return { uri: linkSelector(resource).urlTemplate.replace("{0}", <string><any>argument) };
            }

        return new SubLinkNavigator<TTargetResource, TResource>(this.http, <any>this.execute, <any>standardLinkSelector);//<any> cast is to get rid of incorrect error reported by Resharper
    }

    followLinkTemplate2 = <TTargetResource, TArgument, TArgument2>(linkSelector: (self: TResource) => HyperMediaApi.LinkTemplate2<TTargetResource, TArgument, TArgument2>, argument: TArgument, argument2: TArgument2) => {
        var standardLinkSelector: (self: TResource) => HyperMediaApi.Link<TTargetResource>
            = resource => {
                return { uri: linkSelector(resource).urlTemplate.replace("{0}", <string><any>argument).replace("{1}", <string><any>argument2) };
            }

        return new SubLinkNavigator<TTargetResource, TResource>(this.http, <any>this.execute, <any>standardLinkSelector);//<any> cast is to get rid of incorrect error reported by Resharper
    }

    execute = () => {
        var getResource= this.parent()
            .do(data => console.log(JSON.stringify(data)))
            .switchMap((data: TParentResource) => {
                var myLink = this.navigator(data);
                var resource = this.http.get(myLink.uri)
                    .map((response: Response) => <TResource>response.json())
                    .do(data => console.log("All:" + JSON.stringify(data)));

                return resource;
            });

        return getResource;
    };

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}

export class LinkNavigator<TResource> {

    private headers = new Headers({ 'Content-Type': 'application/json' });
    constructor(private http: Http, private rootLink: HyperMediaApi.Link<TResource>) { };

    followLink = <TTargetResource>(linkSelctor: (self: TResource) => HyperMediaApi.Link<TTargetResource>) => {
        return new SubLinkNavigator<TTargetResource, TResource>(this.http, this.execute, linkSelctor);
    }


    execute = () => {
        var resource = this.http.get(this.rootLink.uri)
            .map((response: Response) => <TResource>response.json())
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
        return resource;
    }

    postCommand = <TResponse>(command: HyperMediaApi.HyperMediaCommand<TResponse>) => {
        return this.http.post(command.postUrl.uri, JSON.stringify(command), { headers: this.headers })
            .map((response: Response) => <TResponse>response.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}