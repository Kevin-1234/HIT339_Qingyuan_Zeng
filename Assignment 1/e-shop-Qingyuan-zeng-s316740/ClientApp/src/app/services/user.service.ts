import { Injectable } from '@angular/core';
import { UserAccount } from '../model/account';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  //add a new account from the form into the local storage
  addAccount(account: UserAccount) {
    // define an array to store account objects
    // the let statement declares a block-scoped local variable, optionally initializing it to a value.
    let accounts = [];
    // if localStorage contains account objects
    // get them, convert them to jason obejects then put them, along with the new account, into accounts array
    if (localStorage.getItem('Accounts')) {
      accounts = JSON.parse(localStorage.getItem('Accounts'));
      // the spread operator '...' returns all elements of an array
      accounts = [account, ...accounts];
    } else {
      // if no account exists in local storage, add the new account from the form
      accounts = [account];
    }
    localStorage.setItem('Accounts', JSON.stringify(accounts));

  }

  putAccount(account: UserAccount) {
    let accounts = [];
    if (localStorage.getItem('Accounts')) {
      accounts = JSON.parse(localStorage.getItem('Accounts'));
      accounts.forEach(a => {
        // if current user's email is equal to a the email of an existed account, update this account
        if (account.email === a.email) {
          a.userName = account.userName;
          a.password = account.password;
          a.mobile = account.mobile;
        }
      });  
      localStorage.setItem('Accounts', JSON.stringify(accounts));
    }
    
  }


}
