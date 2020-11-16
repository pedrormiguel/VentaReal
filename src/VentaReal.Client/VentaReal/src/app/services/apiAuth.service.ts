import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Login } from 'src/class/login';

import { Usuario } from 'src/class/usuario';
import { IResponse } from '../../class/response';

@Injectable({providedIn: 'root'})
export class ApiAuthService {

    constructor(private http: HttpClient) {

        this._usuarioSubject = 
            new BehaviorSubject<Usuario>( JSON.parse(  localStorage.getItem('usuario') ) );

    }

    public get usuarioData() : Usuario {

        return this._usuarioSubject.value;

    }

    private _url:string = "https://localhost:8081/api/user/login";

    private _usuarioSubject:BehaviorSubject<Usuario>;

    login(Credentials:Login) : Observable<IResponse>{

       return  this.http.post<IResponse>
       ( 
           
        this._url,  Credentials, 
        
       ).pipe
       ( 
           map( res => { 

                if(res.exito === 1)
                {
                    const user:Usuario = res.data;
                    localStorage.setItem('usuario', JSON.stringify(user));
                    this._usuarioSubject.next(user);
                }

                return res;
           }) 
       )

    }


    logOut() {

        localStorage.removeItem('usuario');
        this._usuarioSubject.next(null);

    }
}