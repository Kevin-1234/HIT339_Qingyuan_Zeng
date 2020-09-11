import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../services/alertify.service';
import { UserAccount } from '../model/account';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  // define a variable to store the information of the user logged in
  currentUser: UserAccount;
  // inject AlertifyService to create notification message box
  constructor(private alertify: AlertifyService) { }

  ngOnInit() {


  }

  loggingStatus() {
     //check if a token exists, return the token
    this.currentUser = JSON.parse(localStorage.getItem('token'));
    return this.currentUser;
  }
  // remove the token when user click logout
  onLogout(){
    localStorage.removeItem('token');
    this.alertify.success("You are logged out!")
  }

  /*isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }*/

}
