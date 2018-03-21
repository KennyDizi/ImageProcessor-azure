import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { Image } from './image';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ImageService {

  constructor(
    private http: HttpClient
  ) { }
  
  getImages(): Observable<Image[]> {
    let headers = new HttpHeaders();
    headers = headers.set('Ocp-Apim-Subscription-Key', '3af6b8bb361b4b84a50a8aa5a14e5b2d');

    return this.http.get('https://imageservice.azure-api.net/api/v1/all', {
      headers: headers
    }) as Observable<Image[]>;
  }

  uploadFile(file: File): Observable<Image> {
    const formData = new FormData();
    formData.append('file', file);

    let headers = new HttpHeaders();
    headers = headers.set('Ocp-Apim-Subscription-Key', '3af6b8bb361b4b84a50a8aa5a14e5b2d');

    return this.http.post('https://imageservice.azure-api.net/api/v1/upload', formData, {
      headers: headers
    }) as Observable<Image>;
  }
}
