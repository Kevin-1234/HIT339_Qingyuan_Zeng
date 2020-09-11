import { Component, Input } from "@angular/core";

import { Item } from "../model/item";
import { Router, ActivatedRoute } from "@angular/router";
import { UserService } from "../services/user.service";
import { AlertifyService } from "../services/alertify.service";
import { UserAccount } from "../model/account";
import { EshoppingService } from "../services/eshopping.service";


@Component({
  selector: 'app-item-card',
  templateUrl: 'item-card.component.html',
  styleUrls: ['item-card.component.css']
}


)
export class ItemCardComponent {
  currentUser: UserAccount;
  constructor(
    private userService: UserService,
    private eshoppingServices: EshoppingService,
    private alertifyService:AlertifyService,
    private router: Router,
    private route: ActivatedRoute) { }
// using property binding to get data from the parent "item-list.component.ts"
 @Input() item : Item

  ngOnInit() {
    this.currentUser = JSON.parse(localStorage.getItem('token'));
  }

  
  editItem() {
    // get all items 
    this.eshoppingServices.getAllItems().subscribe(
      
      (data: Array<Item>) => {
        // if the item belong to the current logedin user, enter detail page of this item
        if (data.find(i => i.itemId === this.item.itemId).userEmail === this.currentUser.email) {
          this.router.navigate(['item-detail/' + this.item.itemId]);
        }
        //if not, prompt error message
        else {
          this.alertifyService.error("You don't have the authority to edit this item! ")
        }
      }, error => {
        console.log('httperror:');
        console.log(error);
      }
    )   
  }
}
