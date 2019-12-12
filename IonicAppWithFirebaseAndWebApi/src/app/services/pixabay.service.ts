import { Injectable } from '@angular/core';
import { HTTP } from '@ionic-native/http/ngx';

@Injectable({
  providedIn: 'root'
})
export class PixabayService {

  url = 'https://pixabay.com/api/';
  apiKey = '14449888-bc4db867b94511e72f61ed34a'; // <-- Enter your own key here!

  constructor(private http: HTTP) { }

  searchChanged(title: string): Promise<any> {
    return this.http.get(`${this.url}?apikey=${this.apiKey}&q=${encodeURI(title)}`, {}, {});
  }

  getDetails(id) {
    return this.http.get(`${this.url}?apikey=${this.apiKey}&id=${id}`, {}, {});
  }
}
