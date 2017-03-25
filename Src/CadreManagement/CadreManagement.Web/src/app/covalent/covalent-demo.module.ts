import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import {BrowserModule} from '@angular/platform-browser';
import { CovalentCoreModule } from '@covalent/core';
import {CovalentDemoComponent} from './covalent-demo.component';

@NgModule({
    declarations: [
        CovalentDemoComponent
    ],
    imports: [
        FormsModule,
        BrowserModule,
        RouterModule.forChild([
            { path: 'covalent', component: CovalentDemoComponent }
        ]),
        CovalentCoreModule]
})
export class CovalentDemoModule {
    
}
