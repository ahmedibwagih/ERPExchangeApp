import { Component } from '@angular/core';

import { Router } from '@angular/router';
import {  Client, LoginDto, TokenDto } from '../../services/api.service';
@Component({
  selector: 'app-log-in',
  standalone: true,
  imports: [],
  templateUrl: './log-in.component.html',
  styleUrl: './log-in.component.css'
})


export class LogInComponent {
  private client: Client;
  constructor(private router: Router) {
    this.client = new Client('https://localhost:7080');
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
    this.client.authenticationLogin(credentials)
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
