import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm, FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { AlertifyService } from '../services/alertify.service';
import { EshoppingService } from '../services/eshopping.service';
import { Item } from '../model/item';
import { AddItem } from '../model/addItem';
import { UserService } from '../services/user.service';
import { UserAccount } from '../model/account';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent implements OnInit {
  item: AddItem;
  currentUser: UserAccount;
 
  //inject FormBuilder to build the form for adding items
  constructor(
    private userService: UserService,
    private eshooping: EshoppingService,
    private alertifyServices: AlertifyService,
    private router: Router,
    private formBuilder: FormBuilder) { }
  addItemForm: FormGroup;
  formSubmitted: boolean;
  // auto loaded when page starts
  ngOnInit() {
    this.createAddItemForm();
    this.currentUser = JSON.parse(localStorage.getItem('token'));
  }

  // apply field validators
  createAddItemForm() {
    this.addItemForm = this.formBuilder.group(
      {
        itemName: [null, Validators.required],
        itemType: [null, Validators.required],
        itemPrice: [null, Validators.required],
        itemImage:  [null, Validators.required],
        
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
  onBack() {

    this.router.navigate(['/']);

  }

  itemData(): AddItem {
    return this.item = {
      // the values of each property is from the get methods defined above
      
      itemName: this.itemName.value,
      itemType: +this.itemType.value,
      itemPrice: +this.itemPrice.value,
      itemImage: this.itemImage.value,
      userEmail: this.currentUser.email
    }

  }
  
  onSubmit() {
    console.log(this.addItemForm.value);
    this.formSubmitted = true;
    // if the form is valid, then submit
    if (this.addItemForm.valid) {

      this.eshooping.addItem(this.itemData());
      console.log(this.itemData());
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
}
