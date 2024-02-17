import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';


export const routes: Routes = [
    {
        path: '', title: 'Dashboard Page', component: DashboardComponent,
      },
      
];

