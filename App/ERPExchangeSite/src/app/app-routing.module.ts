import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FullComponent } from './layouts/full/full.component';
import { LoginComponent } from './login/login.component';
import { DashboardModule } from './dashboard/dashboard.module';

export const Approutes: Routes = [
  { path: 'starter', component: LoginComponent },
    { path: 'login', component: LoginComponent },
 
    
   //{ path: '', redirectTo: '/login', pathMatch: 'full' },
  //  { path: 'dashboard', component: DashboardModule },
  {path:'',component: FullComponent,children: [
{ path: '', redirectTo: '/dashboard', pathMatch: 'full' },
//{ path: '', redirectTo: '/login', pathMatch: 'full' },
//{ path: 'login', component: LoginComponent },
      {path: 'dashboard',loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)},
      {path: 'about',loadChildren: () => import('./about/about.module').then(m => m.AboutModule)},
      {path: 'component',loadChildren: () => import('./component/component.module').then(m => m.ComponentsModule)}
      ]
  }
  ,
  {
    path: '**',
    redirectTo: '/starter'
  }
];
