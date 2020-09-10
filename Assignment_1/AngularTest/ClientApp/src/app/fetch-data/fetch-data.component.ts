import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Item } from '../model/item';
@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public items: Item[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  
  }

  getItems() {

    this.http.get<Item[]>(this.baseUrl + 'api/items').subscribe(result => {
      this.items = result;
    }, error => console.error(error));
  }

}


