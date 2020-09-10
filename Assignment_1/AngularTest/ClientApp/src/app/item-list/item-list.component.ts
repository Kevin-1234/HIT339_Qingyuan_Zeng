import { Component, OnInit } from '@angular/core';
import { EshoppingService } from '../services/eshopping.service';

import { ActivatedRoute } from '@angular/router';
import { Item } from '../model/item';
import { SharingDataService } from '../services/sharingData.service';



@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent implements OnInit {
  //initialize variable SellRent with value 1, it will be used to determine where an item should be displayed
  //SellRent = 1;
  items: Array<Item>;

  // inject eshopping service to fetch data
  // inject route to access the url
  constructor(
    private sharingData: SharingDataService,
    private eshoppingService: EshoppingService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    // if the page url is "selling-items", SellRent = 2, which is the value of the SellRent property of selling items.
    // That means selling items will be displayed in this page
    //if (this.route.snapshot.url.toString() === "selling-items") {
     // this.SellRent = 2;
    // }
    
    this.eshoppingService.getAllItems().subscribe(
      data => {
        this.items = data;
        console.log(data);
        

      }, error => {
        console.log('httperror:');
        console.log(error);
      }
    )
   
    
  }

}
