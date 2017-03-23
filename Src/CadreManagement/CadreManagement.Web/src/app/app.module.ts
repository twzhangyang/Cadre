import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, PreloadAllModules } from '@angular/router';

import { ROUTES } from './app.routes';
import { AppComponent } from './app.component';
import { NoContentComponent } from './no-content';
import { CadreApiNavigator } from './cadreApiNavigator';

import '../styles/styles.scss';
import '../styles/styles.css';
import '../styles/light-bootstrap-dashboard.css';

import { SidebarModule } from './sidebar/sidebar.module';
import { FooterModule } from './shared/footer/footer.module';
import { NavbarModule } from './shared/navbar/navbar.module';
import { DashboardModule } from './dashboard/dashboard.module';
import {ProductModule} from './product/product.module';



@NgModule({
    declarations: [
        AppComponent,
        NoContentComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        RouterModule.forRoot(ROUTES, { useHash: true, preloadingStrategy: PreloadAllModules }),
        SidebarModule,
        FooterModule,
        NavbarModule,
        DashboardModule,
        ProductModule
    ],
    providers: [
        { provide: 'api', useValue: 'http//localhost/api/user' }, //test
        CadreApiNavigator
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
