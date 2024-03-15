import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ComponentsRoutes } from './component.routing';
import { NgbdpaginationBasicComponent } from './pagination/pagination.component';
import { NgbdAlertBasicComponent } from './alert/alert.component';
import { NgbdDropdownBasicComponent } from './dropdown-collapse/dropdown-collapse.component';
import { NgbdnavBasicComponent } from './nav/nav.component';
import { NgbdButtonsComponent } from './buttons/buttons.component';
import { CardsComponent } from './card/card.component';
import { TableComponent } from "./table/table.component";
//import { TokenInterceptor } from '../token-interceptor.interceptor';
//import { HTTP_INTERCEPTORS } from '@angular/common/http';
//import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
//import { HttpInterceptorService } from '../token-interceptor.interceptor';
//import { GenericAlertComponent } from './General/generic-alert/generic-alert.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(ComponentsRoutes),
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    NgbdpaginationBasicComponent,
    NgbdAlertBasicComponent,
    NgbdDropdownBasicComponent,
    NgbdnavBasicComponent,
    NgbdButtonsComponent,
    CardsComponent,
    TableComponent, HttpClientModule
  ],
  
  providers: [
    //{ provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true }
  ],
  declarations: [

  ],
})
export class ComponentsModule { 
  // constructor(private httpInterceptor: HttpInterceptorService) {
  //   this.overrideFetch();
  // }

  // overrideFetch() {
  //   debugger;
  //   // Override fetch globally only once
  //   if (!('fetch' in window)) {
  //     const interceptor = this.httpInterceptor.createFetchInterceptor();
  //     (window as any).fetch = interceptor.fetch;
  //   }
  // }

}
