import { Component } from '@angular/core';
//import { HttpInterceptorService } from './token-interceptor.interceptor';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'app';
 // private fetchInterceptor: any;
 //private httpInterceptor: HttpInterceptorService
  constructor() {
   // this.overrideFetch();
  }

  // overrideFetch() {
  //   // Override fetch globally
  //   debugger;
  //   if (!('fetch' in window)) {
  //   (window as any).fetch = this.httpInterceptor.fetch.bind(this.httpInterceptor);
  //   }
  // }



  // constructor(private httpInterceptor: HttpInterceptorService) {
  //   this.overrideFetch(true);

  // }

  // overrideFetch(applyOnlyWhenNoAuthorizationHeader: boolean) {
  //   debugger;
  
  //     // const interceptor = this.httpInterceptor.createFetchInterceptor();
  //     // (window as any).fetch = interceptor.fetch;

  //     if (this.fetchInterceptor) {
  //       // If the interceptor is already created, remove it
  //       delete (window as any).fetch;
  //       this.fetchInterceptor = false; 
  //     }
  //     else
  //     {
  //     (window as any).fetch = this.httpInterceptor.createFetchInterceptor.bind(this.httpInterceptor).bind(applyOnlyWhenNoAuthorizationHeader);
  //     //this.fetchInterceptor = true;  
  //   }
    
  // }

  

}
