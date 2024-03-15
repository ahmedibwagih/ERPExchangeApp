import { Component } from '@angular/core';

import { Router } from '@angular/router';
import {  Client, LoginDto, TokenDto } from '../services/api.service';
import { BackEndClientService } from '../services/back-end-client.service';
import { PublicClsService } from '../services/public-cls.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  username: string ;
  password: string ;

  backend:BackEndClientService;
  constructor(private router: Router,private back:BackEndClientService) {
    this.backend = back;
    this.username="admin@admin.com";
    this.password="Default@123";
  }

  login() {

debugger;
    const credentials: LoginDto = {
      userName: this.username,
      password: this.password
     ,
      init: function (_data?: any): void {
        if (_data) {
          this.userName = _data["userName"];
          this.password = _data["password"];
      }
      },
      toJSON: function (data?: any) {
        data = typeof data === 'object' ? data : {};
        data["userName"] = this.userName;
        data["password"] = this.password;
        return data;
      }
    };
    
 debugger;
    this.backend.authenticationLogin(credentials)
      .then((token: TokenDto) => {
        // Handle successful login
     
        localStorage.setItem('token', token.token || "");
       // PublicClsService.authToken = token.token || "";
        this.router.navigate(['/']);
        console.log('Logged in successfully:', token);
      })
      .catch(error => {
        // Handle login error
        //PublicClsService.authToken="";
    
        localStorage.setItem('token', "");
        console.error('Login error:', error);
      });

     // Redirect to the 'about' route
  }
}
