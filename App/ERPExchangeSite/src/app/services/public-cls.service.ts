import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BackEndClientService } from './back-end-client.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class PublicClsService {
  // static userId: string = '';
  static baseUrl: string = 'https://localhost:7080';

  jwtHelperNew: JwtHelperService ;
  backend:BackEndClientService;
  constructor( jwtHelper: JwtHelperService,private back:BackEndClientService,public router: Router) { 
    this.jwtHelperNew=jwtHelper;
    this.backend = back;
  }

  CheckQuery(screenname:any)
  {
    this.back.privilageCheckAuthByName(this.Getuserid(),screenname,'query')
    .then((result: boolean) => {
      if (result == false)
      {
        this.router.navigateByUrl('component/Unauthorized/Unauthorized');
     }
    });

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
