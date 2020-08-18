import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
//map operator allows passing data to a function
import { map } from 'rxjs/operators';
import { MyItem } from '../item-list/MyItem.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EshoppingService {

  constructor(private http: HttpClient) { }

  //receive parameter 'SellRent' to determine which items to push
  getAllItems(SellRent: number): Observable<MyItem[]> {
    //pipe method transform one object to another type of object 
    return this.http.get('data/items.json').pipe(
      map(data => {
        const sellingItems: Array<MyItem> = [];
        for (const id in data) {
          //the items with the same value of SellRent as the function received will be push
          if (data.hasOwnProperty(id) && data[id].SellRent === SellRent) {
            sellingItems.push(data[id]);
          }
        }
        return sellingItems;
      })
    );
  }
}
