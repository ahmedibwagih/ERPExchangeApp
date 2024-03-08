import { Component } from '@angular/core';

import { Router } from '@angular/router';
import {  Client, LoginDto, TokenDto } from '../services/api.service';
import { BackEndClientService } from '../services/back-end-client.service';
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
//     const credentials: LoginDto = {
//       userName: this.username,
//       password: this.password
//      ,
//       init: function (_data?: any): void {
//         if (_data) {
//           this.userName = _data["userName"];
//           this.password = _data["password"];
//       }
//       },
//       toJSON: function (data?: any) {
//         data = typeof data === 'object' ? data : {};
//         data["userName"] = this.userName;
//         data["password"] = this.password;
//         return data;
//       }
//     };
    
// debugger;
//     this.backend.authenticationLogin(credentials)
//       .then((token: TokenDto) => {
//         // Handle successful login
//         console.log('Logged in successfully:', token);
//       })
//       .catch(error => {
//         // Handle login error
//         console.error('Login error:', error);
//       });

    this.router.navigate(['/']); // Redirect to the 'about' route
  }
}
