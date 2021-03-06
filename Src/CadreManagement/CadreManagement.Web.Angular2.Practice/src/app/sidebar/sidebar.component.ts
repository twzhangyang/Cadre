import { Component, OnInit } from '@angular/core';
import { ROUTES } from './sidebar-routes.config';
import { MenuType } from './sidebar.metadata';

@Component({
    moduleId: "sidebar.component.id",
    selector: 'sidebar-cmp',
    templateUrl: 'sidebar.component.html',
})

export class SidebarComponent implements OnInit {
    public menuItems: any[];
    private  isCollapsed = true;
   
    ngOnInit() {
        this.menuItems = ROUTES.filter(menuItem => menuItem.menuType !== MenuType.BRAND);
    }

    public get menuIcon(): string {
        return this.isCollapsed ? '☰' : '✖';
    }

    public getMenuItemClasses(menuItem: any) {
        return {
            'pull-xs-right': this.isCollapsed && menuItem.menuType === MenuType.RIGHT
        };
    }
}
