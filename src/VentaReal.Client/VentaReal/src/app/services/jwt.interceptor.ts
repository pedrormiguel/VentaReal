import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiAuthService } from './apiAuth.service';

@Injectable()
export class JWTInterceptor implements HttpInterceptor {

    constructor(private apiAuthServices: ApiAuthService) {}

    intercept( httpResquest:HttpRequest<any>, next: HttpHandler ) : Observable<HttpEvent<any>> {

        const usuario = this.apiAuthServices.usuarioData;

        if(usuario)
        {
            httpResquest = httpResquest.clone
            (
                {
                    setHeaders: 
                        {
                           Authorization: `Bearer ${usuario.token}`
                        }
                }
            )
        }

        return next.handle(httpResquest);
    }

}
