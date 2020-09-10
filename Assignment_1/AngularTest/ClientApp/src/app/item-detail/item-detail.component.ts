import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Item } from '../model/item';
import { SharingDataService } from '../services/sharingData.service';
import { EshoppingService } from '../services/eshopping.service';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { AddItem } from '../model/addItem';
import { AlertifyService } from '../services/alertify.service';

@Component({
  selector: 'app-item-detail',
  templateUrl: './item-detail.component.html',
  styleUrls: ['./item-detail.component.css']
})
export class ItemDetailComponent implements OnInit {
 
  
  
  items: Array<Item>;
  item: Item;
  addItem: Item;
  
  public itemId: number;
  // inject activatedRoute and Router
  // using activated route to ensure right the right nav link is highlighted
  // using router to navigate the click event binded with the next page button
  constructor(
    private eshoppingServices: EshoppingService,
    private sharingData: SharingDataService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private alertifyServices: AlertifyService) { }
  addItemForm: FormGroup;
  formSubmitted: boolean;
  ngOnInit() {
    
    //get the value of 'id' from the active route and assign it to the itemId
    //the route metod returns a string, conversion is needed to make it calculable
    this.itemId = Number(this.route.snapshot.params['id']);
    this.createAddItemForm();
    
    
    //get updated route value within the same component
    this.route.params.subscribe(
      (params) => {
        this.itemId = +params['id'];
        
        this.getItem(this.itemId);
        
      }
    )

   
    
    
  }

  /*filterItemById(id) {
    return this.items.filter(x => x.itemId == id);
  }*/
  
 

  // find individual item based on id in the url
  getItem(id) {

    this.eshoppingServices.getAllItems().subscribe(
      (data: Array<Item>) => {
        console.log(data);
        this.item = data.find(i => i.itemId === id)
        console.log("this.item: " + this.item);
        // pass the items get from eshopping services to share to other components
        //this.sharingData.changeData(this.items);

      }, error => {
        console.log('httperror:');
        console.log(error);
      }
    )

  }

  // apply field validators
  createAddItemForm() {
    this.addItemForm = this.formBuilder.group(
      {
        itemName: [null, Validators.required],
        itemType: [null, Validators.required],
        itemPrice: [null, Validators.required],
        itemImage: [null, Validators.required],

      }
    )

  }

  get itemName() {
    return this.addItemForm.get('itemName') as FormControl;
  }
  get itemType() {
    return this.addItemForm.get('itemType') as FormControl;
  }
  get itemPrice() {
    return this.addItemForm.get('itemPrice') as FormControl;
  }
  get itemImage() {
    return this.addItemForm.get('itemImage') as FormControl;
  }
 
  itemData(): Item {
    return this.addItem = {
      // the values of each property is from the get methods defined above
      itemId: this.item.itemId,
      itemName: this.itemName.value,
      itemType: +this.itemType.value,
      itemPrice: +this.itemPrice.value,
      itemImage: this.itemImage.value
      
    }

  }

  onSubmit() {
    console.log(this.addItemForm.value);
    this.formSubmitted = true;
    // if the form is valid, then submit
    if (this.addItemForm.valid) {

      this.eshoppingServices.putItem(this.itemData());
      
      //this.userService.addAccount(this.accountData());
      // reset the form when user clicks the submit button
      this.addItemForm.reset();
      this.formSubmitted = false;
      // pop up congrats message when the form submitted is valid
      this.alertifyServices.success('Congradulations, The registration is successfully completed!')
    } else {
      this.alertifyServices.error('Please fill up all the required fields before submitting!')

    }
  }

  onDelete() {
    this.eshoppingServices.deleteItem(this.item);

    this.router.navigateByUrl("MyItems");
    this.alertifyServices.success('Item has been deleted!');
  }
}
