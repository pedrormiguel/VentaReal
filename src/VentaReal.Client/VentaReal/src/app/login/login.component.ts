import { Component, Injectable, OnInit } from "@angular/core";
import {
    FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";

import { Router } from "@angular/router";
import { ApiAuthService } from "../services/apiAuth.service";

@Component({
  selector: "app-login",
  templateUrl: "login.component.html",
  styleUrls: ["login.component.css"],
})

@Injectable({ providedIn: "root" })
export class LoginComponent implements OnInit {
    
  constructor(private _authService: ApiAuthService, private _formBuilder: FormBuilder, private _route: Router) {}

  //Method 1

    //   loginForm = new FormGroup({
    //     Correo: new FormControl("", Validators.required),
    //     Password: new FormControl("", Validators.required),
    //   });

  //Metho2 

    loginForm = this._formBuilder.group({ "Correo": [''], "Password": [''] });

  ngOnInit() {}

  ingresar() {
    this._authService.login(this.loginForm.value).subscribe((response) => {
      if (response.exito === 1) {
        this._route.navigate(["/"]);
      }
    });
  }
}
