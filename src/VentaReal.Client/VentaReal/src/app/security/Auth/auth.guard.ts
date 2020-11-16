import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { ApiAuthService } from 'src/app/services/apiAuth.service';

@Injectable()
export class Authen implements CanActivate {

    constructor(private router: Router, private _apiAuth:ApiAuthService) {}

    canActivate() {

        const usuario = this._apiAuth.usuarioData;

        if(usuario)
            return true;

        this.router.navigate(['/login']);
        return false;
    }

}