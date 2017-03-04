import { Routes } from '@angular/router';
import { NoContentComponent } from './no-content';

// test
import { HomeComponent } from './home';
import { HelloComponent } from './hello';
import { AboutComponent } from './about';
import { DataResolver } from './app.resolver';

export const ROUTES: Routes = [
    { path: '', component: HomeComponent },
    { path: 'home', component: HomeComponent },
    { path: 'about', component: AboutComponent },
    { path: 'hello', component: HelloComponent },
    { path: 'detail', loadChildren: './+detail#DetailModule' },
    { path: 'barrel', loadChildren: './+barrel#BarrelModule' },
    { path: '**', component: NoContentComponent },
];