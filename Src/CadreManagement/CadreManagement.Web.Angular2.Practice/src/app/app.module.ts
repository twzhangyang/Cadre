import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, PreloadAllModules } from '@angular/router';
import { MaterialModule } from '@angular/material';

import { ROUTES } from './app.routes';
import { AppComponent } from './app.component';
import { NoContentComponent } from './no-content';

import { ApiNavigatorModule } from './hyper-media/apiNavigator.module';
import { SidebarModule } from './sidebar/sidebar.module';
import { FooterModule } from './shared/footer/footer.module';
import { NavbarModule } from './shared/navbar/navbar.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { ProductModule } from './product/product.module';
import { MaterialDemoModule } from './material/material-demo.module';
import { CovalentDemoModule } from './covalent/covalent-demo.module';


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
        MaterialModule,
        ApiNavigatorModule,
        SidebarModule,
        FooterModule,
        NavbarModule,
        DashboardModule,
        ProductModule,
        MaterialDemoModule,
        CovalentDemoModule
    ],
    providers: [
        { provide: 'api', useValue: 'http//localhost/api/user' }, //test
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
