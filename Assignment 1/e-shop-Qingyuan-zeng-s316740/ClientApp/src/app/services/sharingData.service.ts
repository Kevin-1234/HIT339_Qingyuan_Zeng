import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Item } from '../model/item';

@Injectable()
export class SharingDataService {
  // share items from the api call "getAllItems()" that is called by "item-list.component"
  items: Array<Item>;
  // ensure that the component always receives the most recent data.
  private dataSource = new BehaviorSubject(this.items);
  currentData = this.dataSource.asObservable();

  constructor() { }

  // call this function in "item-list component" and pass in the items it gets from the API call
  changeData(items: Item[]) {
    this.dataSource.next(items)
  }

}
