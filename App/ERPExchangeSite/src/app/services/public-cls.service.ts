import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class PublicClsService {
  // static userId: string = '';
  static baseUrl: string = 'https://localhost:7080';

  jwtHelperNew: JwtHelperService ;
  constructor( jwtHelper: JwtHelperService) { 
    this.jwtHelperNew=jwtHelper;
  }

   Getuserid(): string {


 
  debugger;
  const token = localStorage.getItem('token'); // Retrieve token from local storage
const decodedToken = this.jwtHelperNew.decodeToken(token ?? "" ); 
   //const decodedToken = this.jwtHelper.decodeToken( localStorage.getItem('token') ?? "");
   debugger;
   var dd="";
 
    return decodedToken.userId;
   //return "9702DAFA-3A8E-4E4C-AADD-16B702AAFDCC";
  }
}
