import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

constructor() { }

// check the user identity
identityCheck(identity: any){
  let accountArray = [];
  // get all the accounts data from the local storage
  // assign the data to accountArray
  if (localStorage.getItem('Accounts')){
    accountArray = JSON.parse(localStorage.getItem('Accounts'));
    console.log(accountArray[0]);
    console.log(accountArray[1]);
  }
  // find the account that matches the one submitted by the user
  return accountArray.find(a => a.email === identity.email && a.password === identity.password);
}

}
