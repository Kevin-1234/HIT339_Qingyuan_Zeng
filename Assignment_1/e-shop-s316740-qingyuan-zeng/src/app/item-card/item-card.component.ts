import { Component, Input } from "@angular/core";
import { MyItem } from "../item-list/MyItem.interface";


@Component({
  selector: 'app-item-card',
  templateUrl: 'item-card.component.html',
  styleUrls: ['item-card.component.css']
}
)
export class ItemCardComponent {
// using property binding 
 @Input() item : MyItem
 
}
