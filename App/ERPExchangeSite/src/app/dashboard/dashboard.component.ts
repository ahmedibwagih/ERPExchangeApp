import { Component, AfterViewInit } from '@angular/core';
import { PublicClsService } from '../services/public-cls.service';
import { Router } from '@angular/router';
//declare var require: any;

@Component({
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent implements AfterViewInit {
  subtitle: string;
  constructor(private router: Router) {
    this.subtitle = 'This is some text within a card block.';
  }

  ngAfterViewInit() { 
   var token = localStorage.getItem('token');
    if(!token)
      this.router.navigate(['/login']);

  }
}
