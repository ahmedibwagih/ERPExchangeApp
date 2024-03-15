import { BrowserModule } from '@angular/platform-browser';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  CommonModule, LocationStrategy,
  PathLocationStrategy
} from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatTableModule } from '@angular/material/table';
import { FullComponent } from './layouts/full/full.component';
import { NavigationComponent } from './shared/header/navigation.component';
import { SidebarComponent } from './shared/sidebar/sidebar.component';
import { MatIconModule } from '@angular/material/icon'; // Import MatIconModule
import { Approutes } from './app-routing.module';
import { AppComponent } from './app.component';
import { SpinnerComponent } from './shared/spinner.component';
import { LoginComponent } from './login/login.component';
import { BanksComponent } from './component/lookups/banks/banks.component';
import { UnauthorizedComponent } from './component/Unauthorized/Unauthorized.component';
import { PrivilagesComponent } from './component/Privilage/Privilage/Privilage.component';
import { MatSelectModule } from '@angular/material/select';
import { FlexLayoutModule } from '@angular/flex-layout';
import { GenericAlertComponent } from './component/General/generic-alert/generic-alert.component';
import { JobsComponent } from './component/lookups/Jobs/Jobs.component';
import { CountriesComponent } from './component/lookups/countries/countries.component';
import { CurrenciesComponent } from './component/lookups/currencies/currencies.component';
import { IdentitySourcesComponent } from './component/lookups/identitySources/identitySources.component';
import { TransferPurposesComponent } from './component/lookups/transferPurposes/transferPurposes.component';
import { UserManagementComponent } from './component/Privilage/user-management/user-management.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
//import { TokenInterceptor } from './token-interceptor.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    SpinnerComponent,
    LoginComponent,
    BanksComponent
    ,UnauthorizedComponent,
    PrivilagesComponent,
    GenericAlertComponent,
    JobsComponent,
    CountriesComponent,
CurrenciesComponent,
IdentitySourcesComponent,
TransferPurposesComponent,
UserManagementComponent
  ],
  imports: [
    JwtModule.forRoot({
      config: {
        tokenGetter: () => {
          return localStorage.getItem('token'); // Function to retrieve the token from local storage
        },
       // allowedDomains: ['example.com'], // Whitelisted domains (optional)
       // disallowedRoutes: ['example.com/login'] // Disallowed routes (optional)
      }
    }),
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgbModule,
    RouterModule.forRoot(Approutes, { useHash: false }),
    FullComponent,
    NavigationComponent,
    SidebarComponent, MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule ,MatTableModule  ,MatInputModule,MatIconModule ,MatSelectModule,FlexLayoutModule
  ],
  providers: [
    {
      provide: LocationStrategy,
      useClass: PathLocationStrategy,
     
    },

    //{ provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
