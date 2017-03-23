/*
 * Angular 2 decorators and services
 */
import {
    Component,
    OnInit,
    ViewEncapsulation
    } from '@angular/core';
import { AppState } from './app.service';

/*
 * App Component
 * Top Level Component
 */
@Component({
    selector: 'app',
    encapsulation: ViewEncapsulation.None,
    styleUrls: [
        './app.component.css'
    ],
    templateUrl: 'app.component.html'
})
export class AppComponent implements OnInit {
    public pageTitle: string='PageTitle';
    constructor(
        public appState: AppState
    ) {
    }

    public ngOnInit() {
        console.log('Initial App State', this.appState.state);
    }

    public isMaps(path) {
        if (path == window.location.pathname) {
            return true;
        }
        else {
            return false;
        }
    }

}
