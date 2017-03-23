import { LinkNavigator } from './hyper-media-api/apiNavigator';
import { Http, Response } from '@angular/http';
import { Injectable } from '@angular/core';
import CadreResource = CadreManagement.WebApi.Models.CadreResource;

@Injectable()
export class CadreApiNavigator extends LinkNavigator<CadreResource> {
    constructor(http: Http) {
        super(http, { uri: 'http://cadreapi.local.com/api' });
    }
}