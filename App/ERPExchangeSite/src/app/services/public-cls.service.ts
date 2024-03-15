import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable({
  providedIn: 'root'
})
export class PublicClsService {
  // static userId: string = '';
  static baseUrl: string = 'https://localhost:7080';
  static jwtHelper: JwtHelperService;

  constructor() {
    PublicClsService.jwtHelper = new JwtHelperService();
  }

  static Getuserid(): string {


 
   // const decodedToken = this.jwtHelper.decodeToken( localStorage.getItem('token') ?? "");


    //return decodedToken.userId;
   return "9702DAFA-3A8E-4E4C-AADD-16B702AAFDCC";
  }
}
