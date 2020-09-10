import { Component, Input } from "@angular/core";

import { Item } from "../model/item";
import { UserService } from "../services/user.service";
import { EshoppingService } from "../services/eshopping.service";
import { AlertifyService } from "../services/alertify.service";
import { UserAccount } from "../model/account";
import { ShoppingCart } from "../model/shoppingCart";


@Component({
  selector: 'app-item-card',
  templateUrl: 'item-card.component.html',
  styleUrls: ['item-card.component.css']
}
)
export class ItemCardComponent {
// using property binding to get data from the parent "item-list.component.ts"
 @Input() item : Item
  currentUser: UserAccount;
  currentShoppingCart: ShoppingCart;
  constructor(
    private userService: UserService,
    private eshoppingServices: EshoppingService,
    private alertifySerives: AlertifyService
  ) { }

  ngOnInit() {
    this.currentUser = JSON.parse(localStorage.getItem('token'));
    
    
   
  }
  addToShoppingCart() {
    this.eshoppingServices.getShoppingCarts().subscribe(
      data => {
        this.currentShoppingCart = data.find(c => c.userEmail === this.currentUser.email);
        this.eshoppingServices.putShoppingCart(this.item);
        console.log("current shopping cart: " + this.currentShoppingCart);
      }
    ), error => {
      console.log('httperror:');
      console.log(error);
    };
    

  }

}
