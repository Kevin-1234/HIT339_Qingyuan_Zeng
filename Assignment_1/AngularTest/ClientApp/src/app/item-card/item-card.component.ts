import { Component, Input } from "@angular/core";

import { Item } from "../model/item";


@Component({
  selector: 'app-item-card',
  templateUrl: 'item-card.component.html',
  styleUrls: ['item-card.component.css']
}
)
export class ItemCardComponent {
// using property binding to get data from the parent "item-list.component.ts"
 @Input() item : Item
 
}
