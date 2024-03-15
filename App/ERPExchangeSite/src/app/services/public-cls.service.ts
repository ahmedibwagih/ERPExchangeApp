import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PublicClsService {
  //static authToken: string = '';
  static baseUrl: string = 'https://localhost:7080';
  constructor() { }
}
