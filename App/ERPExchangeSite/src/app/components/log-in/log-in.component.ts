import { Component } from '@angular/core';

import { Router } from '@angular/router';
import {  Client, LoginDto, TokenDto } from '../../services/api.service';
import { BackEndClientService } from '../../services/back-end-client.service';
@Component({
  selector: 'app-log-in',
  standalone: true,
  imports: [],
  templateUrl: './log-in.component.html',
  styleUrl: './log-in.component.css'
})


export class LogInComponent {

  backend:BackEndClientService;
  constructor(private router: Router,private back:BackEndClientService) {
    this.backend = back;
  }



  redirectToAboutPage() {
    const credentials: LoginDto = {
      userName: 'admin@admin.com',
      password: 'Default@123'
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
        console.log('Logged in successfully:', token);
      })
      .catch(error => {
        // Handle login error
        console.error('Login error:', error);
      });
    this.router.navigate(['/Dashboard']); // Redirect to the 'about' route
  }

  
}
