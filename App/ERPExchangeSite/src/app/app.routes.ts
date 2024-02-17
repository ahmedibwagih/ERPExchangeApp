import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import {  LogInComponent} from './components/log-in/log-in.component';


export const routes: Routes = [
    { path: '', title: 'Dashboard Page', component: LogInComponent},
    { path: 'Dashboard', title: 'Log-in Page', component: DashboardComponent}, 
];

