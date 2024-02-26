import { Injectable } from '@angular/core';
import { Client } from './api.service';

@Injectable({
  providedIn: 'root'
})

export class BackEndClientService extends Client {
  
  constructor() {
    super('https://localhost:7080');
   }

}
