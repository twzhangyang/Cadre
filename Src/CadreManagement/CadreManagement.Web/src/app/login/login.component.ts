import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { TdLoadingService } from '@covalent/core';

@Component({
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {

  username: string;
  password: string;

  constructor(private _router: Router,
              private _loadingService: TdLoadingService) {}

  login(): void {
    this._loadingService.register();
    setTimeout(() => {
      this._router.navigate(['/']);
      this._loadingService.resolve();
    }, 2000);
  }
}
