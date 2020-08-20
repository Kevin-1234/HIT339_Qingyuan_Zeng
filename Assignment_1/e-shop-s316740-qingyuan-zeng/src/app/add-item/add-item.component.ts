import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent implements OnInit {
  // get a reference of the value of the form before passing it to the submit method 
  @ViewChild('Form', { static: false }) addItemForm: NgForm;
  constructor(private router: Router) { }

  ngOnInit() {
  }

  onBack() {

    this.router.navigate(['/']);

  }
  //recieve a ngForm as a parameter
  onSubmit() {
    console.log('haha');
    console.log(this.addItemForm);
  }
}
