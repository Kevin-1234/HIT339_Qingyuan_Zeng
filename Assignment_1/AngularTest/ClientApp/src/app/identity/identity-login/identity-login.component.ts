import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-identity-login',
  templateUrl: './identity-login.component.html',
  styleUrls: ['./identity-login.component.css']
})
export class IdentityLoginComponent implements OnInit {
  // inject authentication service to check user identity
  // inject alertify service to create pop up message boxs
  // inject Router to navigate user back to home page after loggingin
  constructor(private authentication: AuthenticationService,
    private alertify: AlertifyService,
    private route: Router) { }

  ngOnInit() {
  }


  onLogin(loginForm: NgForm){
    // assign the result of identity check method in authentication services to the variable token
    const token = this.authentication.identityCheck(loginForm.value);
    // if the account info submitted is found in the local storage
    if(token){
      // store the account email as a token into the local storage to track the loggin status
      // print login successful message box
      // must stringify an object when uploading
      localStorage.setItem('token', JSON.stringify(token));
      this.alertify.success('Login successful');
      // jump back to home page after loggingin
      this.route.navigate(['/']);
    }else{
      this.alertify.error('Invalid account or password!');
    }
  }

}
