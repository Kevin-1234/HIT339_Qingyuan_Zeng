import { Component, OnInit } from '@angular/core';
import { EshoppingService } from '../services/eshopping.service';

import { ActivatedRoute, Router } from '@angular/router';
import { Item } from '../model/item';
import { SharingDataService } from '../services/sharingData.service';
import { UserService } from '../services/user.service';
import { UserAccount } from '../model/account';



@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent implements OnInit {
  //initialize variable SellRent with value 1, it will be used to determine where an item should be displayed
  //SellRent = 1;
  pageTitle: string;
  items: Array<Item>;

  currentUser: UserAccount;

  // inject eshopping service to fetch data
  // inject route to access the url
  constructor(
    private userService: UserService,
    private sharingData: SharingDataService,
    private eshoppingService: EshoppingService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.currentUser = JSON.parse(localStorage.getItem('token'));
    console.log("url: " + this.router.url);


    // if url is equal to the url of buying items page, show all the items from all users that are for sale
    //else show the items of the current user that are to be sold 
    if (this.router.url === "/items-for-sale") {
      this.pageTitle = "Items for sale"
      this.eshoppingService.getAllItems().subscribe(
        data => {
          this.items = data;

        }, error => {
          console.log('httperror:');
          console.log(error);
        }
      )


    } else if (this.router.url === "/Shopping-cart") {
      console.log("haha");
      let scitems = [];
      if (localStorage.getItem('items')) {
        console.log("haha");
        scitems = JSON.parse(localStorage.getItem('items'));
        console.log("haha" + scitems);
        this.items = scitems.filter(i => i.userEmail === this.currentUser.email);       
      
      } else {
        this.pageTitle = "Items to be sold"
        this.eshoppingService.getAllItems().subscribe(
          data => {
            this.items = data.filter(i => i.userEmail === this.currentUser.email);
            console.log(data);


          }, error => {
            console.log('httperror:');
            console.log(error);
          }
        )

      }



    }
  }

  addItem() {

    this.router.navigate(['add-item']);

  }

  
  

}
