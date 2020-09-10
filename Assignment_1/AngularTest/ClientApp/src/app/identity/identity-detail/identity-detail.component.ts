import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { UserAccount } from '../../model/account';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { AlertifyService } from '../../services/alertify.service';

@Component({
  selector: 'app-identity-detail',
  templateUrl: './identity-detail.component.html',
  styleUrls: ['./identity-detail.component.css']
})
export class IdentityDetailComponent implements OnInit {
  currentUser: UserAccount;
  // FormGroup is a class to manage related form controls in a form
  registrationForm: FormGroup;
  // initialze variable account as a javascript object with type any for storing form inputs
  account: UserAccount;
  formSubmitted: boolean;
  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder,
    private alertifySerives: AlertifyService) { }

  ngOnInit() {
    this.createRegistrationForm();
    this.registrationForm.reset();
    this.currentUser = JSON.parse(localStorage.getItem('token'));
    
  }
  // apply field validators
  createRegistrationForm() {
    this.registrationForm = this.formBuilder.group({
      // control level validators
      userName: [null],
      email: [null],
      password: [null],
      confirmPassword: [null],
      mobile: [null],
      // a form level validator
    }, { validators: this.confirmPassValidator })
  }
  // customer validator to check if confirmPassword matches with password
  confirmPassValidator(fg: FormGroup): Validators {

    return fg.get('password').value === fg.get('confirmPassword').value ? null : { passwordsNotMatched: true };
  }




  // use get method to retrieve user name entered in the form
  get userName() {

    return this.registrationForm.get('userName') as FormControl;
  }

  get email() {

    return this.registrationForm.get('email') as FormControl;
  }

  get password() {

    return this.registrationForm.get('password') as FormControl;
  }

  get confirmPassword() {

    return this.registrationForm.get('confirmPassword') as FormControl;
  }

  get mobile() {

    return this.registrationForm.get('mobile') as FormControl;
  }

  onSubmit() {
    console.log(this.registrationForm.value);
    this.formSubmitted = true;
    // if the form is valid, then submit
    if (this.registrationForm.valid) {

      
      this.userService.putAccount(this.accountData());
      // reset the form when user clicks the submit button
      this.registrationForm.reset();
      this.formSubmitted = false;
      // pop up congrats message when the form submitted is valid
      this.alertifySerives.success('Your profile has been updated!')
    } else {
      this.alertifySerives.error('Please fill up all the required fields!')

    }

  }

  accountData(): UserAccount {
    return this.account = {
      // the values of each property is from the get methods defined above
      userName: this.userName.value,
      email: this.currentUser.email,
      password: this.password.value,
      mobile: this.mobile.value

    }

  }


}
