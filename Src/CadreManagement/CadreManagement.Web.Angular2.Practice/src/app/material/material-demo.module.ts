import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { MaterialModule } from '@angular/material';
import { MaterialDemoComponent } from './material-demo.component';
import { MaterialChipComponent } from './chip/material-chip.component';
import { MaterialCardComponent } from './card/material-card.component';
import { MaterialDialogComponent, MaterialDialogResult } from './dialog/material-dialog.component';

@NgModule({
    declarations: [
        MaterialDemoComponent,
        MaterialChipComponent,
        MaterialCardComponent,
        MaterialDialogComponent,
        MaterialDialogResult
    ],
    imports: [
        MaterialModule,
        FormsModule,
        BrowserModule,
        RouterModule.forChild([
            { path: 'material', component: MaterialDemoComponent }
        ])
    ],
    entryComponents:[MaterialDialogResult]
})
export class MaterialDemoModule {

}
