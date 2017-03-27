import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-main',
    templateUrl: './main.component.html',
})
export class MainComponent {

    routes: Object[] = [{
        title: '实时监控',
        route: '/',
        icon: 'dashboard',
    },
    {
        title: '全程纪实',
        route: '/product',
        icon: 'view_quilt',
    },
    {
        title: '亮灯报警',
        route: '/logs',
        icon: 'receipt',
    },
    {
        title: '责任界定',
        route: '/templates',
        icon: 'view_module',
    },
    {
        title: '干部管理',
        route: '/users',
        icon: 'people',
    }
    ];

    constructor(private _router: Router) { }

    logout(): void {
        this._router.navigate(['/login']);
    }
}
