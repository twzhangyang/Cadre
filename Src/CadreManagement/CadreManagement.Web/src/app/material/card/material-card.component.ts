import { Component } from '@angular/core';

@Component({
    templateUrl: './material-card.component.html',
    selector:'material-card'
})
export class MaterialCardComponent {
    color = "primary";
    mode = "determinate";
    value=50;
}