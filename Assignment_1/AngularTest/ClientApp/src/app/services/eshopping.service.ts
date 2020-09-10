import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
//map operator allows passing data to a function
import { map } from 'rxjs/operators';

import { Observable } from 'rxjs';
import { Item } from '../model/item';
import { AddItem } from '../model/addItem';

@Injectable({
  providedIn: 'root'
})
export class EshoppingService {

  postId: number;
  item: Item;
  itemArray: Array<Item>;
  constructor( private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getItem(id: number) {
  
  
    /*return this.getAllItems().subscribe(
      data => {
        this.item = data.find(i => i.itemId === id);


        // pass the items get from eshopping services to share to other components


      }, error => {
        console.log('httperror:');
        console.log(error);
      }
    )
    */
    
    console.log("this.item: " + this.item);
    
  }


  putItem(item: Item) {
 
    console.log("item: " + item.itemId);
    console.log("item: " + JSON.stringify(item));
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(item);
    // "<Item>" type is needed
    this.http.put<Item>('https://localhost:44322/api/items/' + item.itemId, body, { 'headers': headers }).subscribe({
      error: error => console.error('There was an error!', error)
    })
   

    
  }

  //receive parameter 'SellRent' to determine which items to push
  getAllItems(): Observable<Item[]> {
  
    
  
    return this.http.get<Item[]>('https://localhost:44322/api/items/');
      
      
    
    //pipe method transform one object to another type of object
    //any folder that is outside of app folder need to be added in assets in angular.json
    
     
     

    

      /*.pipe(
      map(data => {
        const items: Array<Item> = [];
        for (const itemId in data) {
          //the items with the same value of SellRent as the function received will be push
          if (data.hasOwnProperty(id) && data[id].SellRent === SellRent) {
            sellingItems.push(data[id]);
          }
        }

        return items;
      })
    );*/
      
  }


  addItem(item: AddItem) {
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(item);
    this.http.post<AddItem>(this.baseUrl + 'api/items', body, { 'headers': headers } ).subscribe({
      error: error => console.error('There was an error!', error)
    })

  }


  deleteItem(item: Item) {

    console.log("item: " + item.itemId);
    console.log("item: " + JSON.stringify(item));
    const headers = { 'content-type': 'application/json' }
    // "<Item>" type is needed
    this.http.delete<Item>('https://localhost:44322/api/items/' + item.itemId, { 'headers': headers }).subscribe({
      error: error => console.error('There was an error!', error)
    })



  }
}
