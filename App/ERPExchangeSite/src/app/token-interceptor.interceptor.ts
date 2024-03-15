// import { Injectable } from '@angular/core';
// import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
// import { Observable, from } from 'rxjs';
// import { map } from 'rxjs/operators';

// @Injectable({
//   providedIn: 'root'
// })
// export class HttpInterceptorService {

//   constructor(private http: HttpClient) { }

//   // This method intercepts HttpClient calls and adds Authorization header if it's not already present
//   createFetchInterceptor(url: string | Request, options?: RequestInit): Observable<Response> {
//     const token = localStorage.getItem('token'); // Assuming token is stored in localStorage

//     options = options || {};
//     options.headers = options.headers || {};

//     // Check if options.body exists and is a string, then check if it contains 'userName'
//     if (typeof options.body === 'string' && options.body.includes('userName')) {
//       return new Observable(); // Return an empty observable
//     }

//     // Add the Authorization header with the token if token is available
//     if (token) {
//       // Convert headers to HttpHeaders
//       let headers = new HttpHeaders(options.headers as Record<string, string>);
//       headers = headers.append('Authorization', `Bearer ${token}`);
//     //  options.headers = headers;
//     }

//     // Extract the URL if it's a Request object
//     const requestUrl = typeof url === 'string' ? url : url.url;

//     // Make the HTTP request using HttpClient
//     return from(
//       this.http.request('GET', requestUrl, { ...options, observe: 'response' })
//     ).pipe(
//       map(response => response as Response) // Convert to Response object
//     );
//   }
// }


// // import { Injectable } from '@angular/core';
// // import { HttpClient, HttpHeaders } from '@angular/common/http';
// // import { Observable } from 'rxjs';
// // @Injectable({
// //   providedIn: 'root'
// // })
// // export class HttpInterceptorService {

// //   constructor(private http: HttpClient) { }

// //   createFetchInterceptor(url: RequestInfo, options?: RequestInit): Promise<Response> {
// //     // Get the token from wherever you have stored it (localStorage, sessionStorage, etc.)
// //     const token = localStorage.getItem('token'); // Assuming token is stored in localStorage

// //     debugger;
// //     // If options.headers is undefined, initialize it as an empty object
// //     options = options || {};
// //     options.headers = options.headers || {};
   

// //     if ((options.headers as Record<string, string>)['Authorization'] || (typeof options.body === 'string' && options.body.includes('userName')) ) {
// //       delete (window as any).fetch;
// //       return fetch(url, options);
// //       //return Promise.resolve(new Response());

// //     //   if ((options?.headers as Record<string, string>)['Authorization'].substring(0,10) == 'BearerSign'  )
// //     //   {
// //     //   (options?.headers as Record<string, string>)['Authorization'] = (options?.headers as Record<string, string>)['Authorization'].replace('BearerSign','Bearer');
// //     //   return fetch(url, options);
// //     // }
// //     }

// //     // Add the Authorization header with the token
// //     if (token) {
// //       // Use type assertion to specify the type of options.headers
// //       (options.headers as Record<string, string>)['Authorization'] = `Bearer ${token}`;
// //     }

// //     // Use the native fetch method directly
// //     return fetch(url, options);
// //     // this.http.request<any>('GET', url, options);
// //   }
// // }





// // import { Injectable } from '@angular/core';
// // import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
// // import { Observable } from 'rxjs';

// // @Injectable()
// // export class TokenInterceptor implements HttpInterceptor {

// //   constructor() { }

// //   intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
// //     // Get the token from wherever you have stored it (localStorage, sessionStorage, etc.)
// // debugger;
// //     var token = localStorage.getItem('token');

// //     // Clone the request and add the token to the headers if it exists
// //     if (token) {
// //       request = request.clone({
// //         setHeaders: {
// //           Authorization: `Bearer ${token}`
// //         }
// //       });
// //     }

// //     // Pass on the modified request
// //     return next.handle(request);
// //   }
// // }
