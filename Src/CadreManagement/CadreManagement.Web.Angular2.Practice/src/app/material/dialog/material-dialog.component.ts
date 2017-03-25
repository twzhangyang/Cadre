import { Component } from '@angular/core';
import { MdDialog, MdDialogRef } from '@angular/material';

@Component({
    templateUrl: './material-dialog.component.html',
    selector: 'material-dialog'
})
export class MaterialDialogComponent {
    selectedOption: string;

    constructor(private dialog: MdDialog) {

    }

    openDialog() {
        let dialogRef = this.dialog.open(MaterialDialogResult);
        dialogRef.afterClosed().subscribe(result => {
            this.selectedOption = result;
        });
    }
}

@Component({
    templateUrl:'./material-dialog-result.component.html'
})
export class MaterialDialogResult {
    constructor(private dialogRef: MdDialogRef<MaterialDialogComponent>) {
        
    }
}