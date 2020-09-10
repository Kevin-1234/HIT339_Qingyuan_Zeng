import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public items: item[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<item[]>(baseUrl + 'api/items').subscribe(result => {
      this.items = result;
    }, error => console.error(error));
  }
}

interface item {
  itemName: string;
  itemPrice: number;
  itemId: number;
  sellOrBuy: number;
  itemImage: string;
  itemType: number;
}
