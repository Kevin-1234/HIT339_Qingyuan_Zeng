import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  constructor() { }

  ngOnInit() {


  }

  loggingStatus() {
    // check if a token exists, return the token
    return localStorage.getItem('token');
  }
  // remove the token when user click logout
  onLogout(){
    localStorage.removeItem('token');

  }

  /*isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }*/

}
