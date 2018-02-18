import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { Image } from './image';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ImageService {

  constructor(
    private http: HttpClient
  ) { }
  
  getImages(): Observable<Image[]> {
    return this.http.get('https://imageservice.azure-api.net/api/v1/all');
  }

}
