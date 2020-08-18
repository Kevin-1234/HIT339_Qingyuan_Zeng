import { Component, OnInit } from '@angular/core';
import { EshoppingService } from '../services/eshopping.service';
import { MyItem } from './MyItem.interface';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent implements OnInit {
  //initialize variable SellRent with value 1, it will be used to determine where an item should be displayed
  SellRent = 1;
  sellingItems: Array<MyItem>;

  // inject eshopping service to fetch data
  // inject route to access the url
  constructor(private eshoppingService : EshoppingService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    // if the page url is "selling-items", SellRent = 2, which is the value of the SellRent property of selling items. 
    // That means selling items will be displayed in this page
    if (this.route.snapshot.url.toString() === "selling-items") {
      this.SellRent = 2;
    }
    // pass the value of SellRent when calling the service
    this.eshoppingService.getAllItems(this.SellRent).subscribe(
      data => {
        this.sellingItems = data;
        console.log(data);
        
      }, error => {
        console.log('httperror:');
        console.log(error);
      }
    )

    /*this.http.get('data/items.json').subscribe(
      data => {
        this.sellingItems = data
        console.log(data)
      }
    )*/
    
  }

}
