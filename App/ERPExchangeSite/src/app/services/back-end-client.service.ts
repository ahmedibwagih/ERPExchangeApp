import { Injectable } from '@angular/core';
import { Client } from './api.service';
import { PublicClsService } from './public-cls.service';

@Injectable({
  providedIn: 'root'
})

export class BackEndClientService extends Client {
  
  constructor() {
    super( PublicClsService.baseUrl);
   }

}
